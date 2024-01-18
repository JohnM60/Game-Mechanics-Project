using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /*
     * singleton class,
     * can create a array of audio clips according to the category
     * searched by string name
     */
    public static SoundManager instance;
    public AudioSource _musicSource, _genericSource, _playerSource, _enemySource;
    public Sound[] musicAudio, genericSFX, playerSFX, enemySFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string soundName)
    {
        Sound s = Array.Find(musicAudio, x => x._name == soundName);

        if (s == null)
        {
            Debug.LogError("Audio clip " + soundName + " not found.");
        }
        else
        {
            _musicSource.PlayOneShot(s._clip);
        }
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(genericSFX, x => x._name == soundName);

        if (s == null)
        {
            Debug.LogError("Audio clip " +  soundName + " not found.");
        }
        else
        {
            _genericSource.PlayOneShot(s._clip);
        }
    }

    public void PlayPlayerSound(string soundName)
    {
        Sound s = Array.Find(playerSFX, x => x._name == soundName);

        if (s == null)
        {
            Debug.LogError("Audio clip " + soundName + " not found.");
        }
        else
        {
            _playerSource.PlayOneShot(s._clip);
        }
    }

    public void PlayEnemySound(string soundName)
    {
        Sound s = Array.Find(enemySFX, x => x._name == soundName);
        
        if (s == null)
        {
            Debug.LogError("Audio clip " + soundName + " not found.");
        }
        else
        {
            _enemySource.PlayOneShot(s._clip);
        }
    }
}
