using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource environmentMusic;
    public AudioSource backgroundMusic;
    public AudioSource soundEffects;
    public AudioSource mainMenu;
    public AudioSource soundEffectsEnemy;

    public AudioClip environmentMusicClip;
    public AudioClip backgroundMusicClip;
    public AudioClip levelCompleteClip;
    public AudioClip levelFailedClip;
    public AudioClip levelThemeClip;
    public AudioClip loadOutClip;
    public AudioClip mainMenuClip;
    public AudioClip newUnlockClip;
    public AudioClip nextLevelClip;
    public AudioClip selectCharacterClip;
    public AudioClip startNewGameClip;
    public AudioClip upgradeCharacterClip;
    public AudioClip voiceOversClip;
    public AudioClip uziClip;
    public AudioClip enemyUziClip;

    public static SoundManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }



    public void StopSoundEffect()
    {
        soundEffects.Stop();
    }

   

    public void PlayLevelComplete()
    {
        soundEffects.clip = levelCompleteClip;
        soundEffects.Play();
    }

    public void PlayLevelFailed()
    {
        soundEffects.clip = levelFailedClip;
        soundEffects.Play();
    }

    public void PlayLevelTheme()
    {
        backgroundMusic.clip = levelThemeClip;
        backgroundMusic.Play();
    }

    public void PlayLoadOut()
    {
        soundEffects.clip = loadOutClip;
        soundEffects.Play();
    }

    public void PlayMainMenu()
    {
        mainMenu.clip = mainMenuClip;
        mainMenu.Play();
    }

    public void PlayNewUnlock()
    {
        soundEffects.clip = newUnlockClip;
        soundEffects.Play();
    }

    public void PlayNextLevel()
    {
        soundEffects.clip = nextLevelClip;
        soundEffects.Play();
    }

    public void PlaySelectCharacter()
    {
        soundEffects.clip = selectCharacterClip;
        soundEffects.Play();
    }

    public void PlayStartNewGame()
    {
        soundEffects.clip = startNewGameClip;
        soundEffects.Play();
    }

    public void PlayUpgradeCharacter()
    {
        soundEffects.clip = upgradeCharacterClip;
        soundEffects.Play();
    }

    public void PlayVoiceOvers()
    {
        soundEffects.clip = voiceOversClip;
        soundEffects.Play();
    }

    public void PlayUzi()
    {
        soundEffects.clip = uziClip;
        soundEffects.Play();
    }

    public void PlayEnemyUzi()
    {
        soundEffectsEnemy.clip = enemyUziClip;
        soundEffectsEnemy.Play();
    }
}