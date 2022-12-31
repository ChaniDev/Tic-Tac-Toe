using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundHandler : MonoBehaviour
{
    public SoundPanel[] Audio;


    void PlaySound(string soundName)
    {
        foreach(SoundPanel i in Audio)
        {
            if(i.SoundName == soundName)
            {
                i.SoundFile.Play();
            }
        }
    }
}


    [System.Serializable]
public class SoundPanel 
{
    public string SoundName;
    public AudioSource SoundFile;
}
