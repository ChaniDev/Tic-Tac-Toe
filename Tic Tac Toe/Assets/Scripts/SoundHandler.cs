using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundHandler : MonoBehaviour
{
    SoundHandler insSoundHandler;

    AudioSource BGSHandler;


    public SFXFiles[] SFXManager;
    public BGSFiles[] BGSManager;

    void Start()
    {
        insSoundHandler = FindObjectOfType<SoundHandler>();

        BGSHandler = insSoundHandler.gameObject.AddComponent<AudioSource>();
    }

    public void PlaySFX(string soundEffectName)
    {
        bool MatchFound = false;

        for(int i = 0; i < SFXManager.Length; i++)
        {
            if(SFXManager[i].SFXName == soundEffectName)
            {
                MatchFound = true;

                AudioSource SFXHandler;
                SFXHandler = insSoundHandler.gameObject.AddComponent<AudioSource>();

                    //-- Properties --
                SFXHandler.clip = SFXManager[i].SoundEffect;
                SFXHandler.volume = SFXManager[i].Volume;
                    //----------------
                
                SFXHandler.Play();

                Destroy(SFXHandler, SFXHandler.clip.length);
            }
        }
        if(!MatchFound)
        {
            Debug.LogWarning($"No match found In BGS - Error-{soundEffectName}-");
        }
    }

    public void PlayBGS(string backgroundSoundsName)
    {
        bool MatchFound = false;

        for(int i = 0; i < BGSManager.Length; i++)
        {
            if(BGSManager[i].BGSName == backgroundSoundsName)
            {
                MatchFound = true;

                    //-- Properties --
                BGSHandler.clip = BGSManager[i].Music;
                BGSHandler.volume = BGSManager[i].Volume;
                BGSHandler.loop = true;
                    //----------------
                
                BGSHandler.Play();
            }
        }
        if(!MatchFound)
        {
            Debug.LogWarning($"No match found In BGS - Error-{backgroundSoundsName}-");
        }
    }

}

    [System.Serializable]
public class SFXFiles 
{
    public string SFXName;
    public AudioClip SoundEffect;
    [Range(0,1)] public float Volume;
}

    [System.Serializable]
public class BGSFiles
{
    public string BGSName;
    public AudioClip Music;
    [Range(0,1)] public float Volume;
}
