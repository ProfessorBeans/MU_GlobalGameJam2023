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
    
    //Other sound effects
    public AudioClip vines;
    
    public AudioClip node1;
    public AudioClip node2;
    public AudioClip node3;
    
    
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
    
    public void playVines()
    {
        _audioSource.clip = vines;
        
        _audioSource.Play();
    }
    
    public void playNode()
    {
        int randomNumber = UnityEngine.Random.Range(1, 4);

        if (randomNumber == 1)
        {
            _audioSource.clip = node1;
        }
        else if (randomNumber == 2)
        {
            _audioSource.clip = node2;
        }
        else
        {
            _audioSource.clip = node3;
        }

        _audioSource.Play();
    }
}
