using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip game_music;
    public GameOverDisplay gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelWin() {

    }

    public void LevelLose() {
        Time.timeScale = 0;
        gameOverScreen.Setup();
    }
}
