using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] int startingLives = 3;
    private int currentLives;

    private void Start()
    {
        currentLives = startingLives;
        UpdateLivesUI();
    }

    public void UpdateLives(int amount)
    {
        currentLives += amount;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
     
            ResetPlayer();
        }
    }

    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }

    private void ResetPlayer()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        SpikesController.OnPlayerHitSpike += PlayerHitSpike;
    }

    private void OnDisable()
    {
        SpikesController.OnPlayerHitSpike -= PlayerHitSpike;
    }

    private void PlayerHitSpike()
    {

        UpdateLives(-1);
    }
}
