using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum AudioGroup { 
    Master,
    Musics,
    SFX,
    None
}
public class AudioSettings : MonoBehaviour
{
    [Header("Mixers")]
    public AudioMixer mixer;

    [Header("Groups")]
    public AudioMixerGroup MasterGroup;
    public AudioMixerGroup MusicsGroup;
    public AudioMixerGroup SFXGroup;

    [Header("Snapshots")]
    public AudioMixerSnapshot pausedSnapshot;
    public AudioMixerSnapshot unpausedSnapshot;

    public static float CalculateAudio(float source) => Mathf.Log10(source) * 20;

    
}
