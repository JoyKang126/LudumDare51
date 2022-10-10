using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject tutorialUI;
    public bool paused = false;
    private bool tutorial = true;
    [SerializeField] private AudioSource clickSound;

    public KeyCode enter;

    public void Awake()
    {
        Time.timeScale = 0f;
        paused = true;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(enter) && tutorial)
        {
            tutorial = false;
            tutorialUI.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.mute = false;
            }
        }
    }

    // Update is called once per frame
    public void PauseGame()
    {
        clickSound.Play();
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.mute = true;
        }
        clickSound.mute = false;
    }

    public void ResumeGame()
    {
        clickSound.Play();
        paused = false;
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.mute = false;
        }
    }

    public void BackToStart()
    {
        Time.timeScale = 1f;
        clickSound.Play();
        SceneManager.LoadScene("Scenes/StartScene");
    }
}
