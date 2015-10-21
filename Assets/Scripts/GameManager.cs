using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [HideInInspector]
    public SoundManager SoundManager;

    [HideInInspector]
    public ReferenceManager References;

    public List<ControlScheme> ControlSchemes = new List<ControlScheme>();

    [SerializeField]
    GameObject PlayerPrefab;

    [HideInInspector]
    public List<Character> PlayerCharacters = new List<Character>();

    public bool DebugHitbox = true;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SoundManager = GetComponentInChildren<SoundManager>();
        if (SoundManager == null)
        {
            Debug.LogError("SoundManager is Missing!");
        }

        References = GetComponentInChildren<ReferenceManager>();
        if (References == null)
        {
            Debug.LogError("References component is Missing!");
        }
    }

    void Start()
    {
        if (Application.loadedLevelName == "Main")
        {
            Debug.Log("STARTING GAME IN DEBUG MODE");
            StartGame();
        }
    }

    public void SpawnPlayer(Vector3 zPosition, ControlScheme zControlScheme)
    {
        GameObject playerInstance = GameObject.Instantiate(PlayerPrefab, zPosition, Quaternion.identity) as GameObject;

        Character newCharacter = playerInstance.GetComponent<Character>();

        int newID = PlayerCharacters.Count;

        newCharacter.playerID = newID;

        newCharacter.Status = Character.Statuses.DISABLED;

        (newCharacter.Brain as BrainPlayer).ControlScheme = zControlScheme;

        PlayerCharacters.Add(newCharacter);

        newCharacter.Locomotor.FaceDirection(Locomotor.FacingDirections.RIGHT);

        iTween.ScaleFrom(playerInstance, iTween.Hash("scale", Vector3.zero, "easetype", iTween.EaseType.easeOutCubic, "time", 1, "oncompletetarget", playerInstance, "oncomplete", "OnSpawn"));
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    public IEnumerator StartGameCoroutine()
    {
        PlayerCharacters.Clear();

        if (Application.loadedLevelName != "Main")
        {
            Application.LoadLevel("Main");
            while (Application.isLoadingLevel)
                yield return new WaitForSeconds(0.1f);
        }

        //SoundManager.PlayMusic("background");

        yield return new WaitForSeconds(0.25f);

        SpawnPlayer(Vector3.zero, GetControlScheme("Joystick 2")); //todo: set here the chosen control scheme
    }

    ControlScheme GetControlScheme(string zName)
    {
        return ControlSchemes.FirstOrDefault(c => c.Name == zName);
    }
}
