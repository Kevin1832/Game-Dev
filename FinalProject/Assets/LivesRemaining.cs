using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesRemaining : MonoBehaviour
{

    
    public int lives = 3;
    public TextMeshProUGUI livesText;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
         
            if (lives > 0)
            {
                lives--;
                UpdateLivesText();
                if (lives <= 0)
                {
                 
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }


    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}

