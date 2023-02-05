using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Outlet
    private AudioSource _audioSource;
    

    //Voice Clips
    public AudioClip voice_jump;
    public AudioClip voice_die;
    public AudioClip voice_lose_puzzle;
    public AudioClip voice_mound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void playJumpVoice()
    {
        _audioSource.clip = voice_jump;
        
        _audioSource.Play();
    }
    
    public void playDieVoice()
    {
        _audioSource.clip = voice_die;
        
        _audioSource.Play();
    }
    
    public void playLoseVoice()
    {
        _audioSource.clip = voice_lose_puzzle;
        
        _audioSource.Play();
    }
    
    public void playMoundVoice()
    {
        _audioSource.clip = voice_mound;
        
        _audioSource.Play();
    }
}
