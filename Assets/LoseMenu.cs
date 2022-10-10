using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ScoreScriptableObject score;
    [SerializeField] private AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "You fixed " + score.tubs.ToString() + " haunted tubs, "+ score.lights.ToString() +" haunted lights, "+score.beds.ToString()+" haunted beds, "+score.doors.ToString()+" haunted doors, "+score.windows.ToString()+" haunted windows, "+score.tvs.ToString()+" haunted tvs, and "+score.cakes.ToString()+" haunted ghost cakes.";
    }

    public void BackToStart()
    {
        clickSound.Play();
        SceneManager.LoadScene("Scenes/StartScene");
    }
}
