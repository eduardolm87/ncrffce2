using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SoundManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public List<AudioSource> SoundSource = new List<AudioSource>();

    public List<AudioClip> Sounds = new List<AudioClip>();
    public List<AudioClip> Musics = new List<AudioClip>();


    public void PlaySound(string zSoundName)
    {
        AudioClip soundToPlay = Sounds.FirstOrDefault(s => s.name == zSoundName);
        if (soundToPlay == null)
        {
            Debug.LogError("Error. Sound effect not found: " + zSoundName);
            return;
        }

        //Find first source not busy
        AudioSource source = SoundSource.FirstOrDefault(s => !s.isPlaying);
        if (source == null)
        {
            source = SoundSource[0];
        }

        //Swap to the end of the list for priority
        SoundSource.RemoveAt(0);
        SoundSource.Add(source);



        source.clip = soundToPlay;
        source.Play();
    }

    public void PlayMusic(string zSoundName)
    {
        AudioClip soundToPlay = Musics.FirstOrDefault(s => s.name == zSoundName);
        if (soundToPlay == null)
        {
            Debug.LogError("Error. Music not found: " + zSoundName);
            return;
        }

        MusicSource.clip = soundToPlay;
        MusicSource.Play();
    }
}
