using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    public Animator animator;
    // Start is called before the first frame update
    public void StartGame()
    {
        clickSound.Play();
        SceneManager.LoadScene("Scenes/SampleScene");
        //animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
