using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesRemaining : MonoBehaviour
{

    // Lives settings
    public int lives = 3;
    public TextMeshProUGUI livesText;

    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            // Decrement lives only if there are remaining lives
            if (lives > 0)
            {
                lives--;
                UpdateLivesText();
                if (lives <= 0)
                {
                    // Player is out of lives, perform game over logic here
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }

    // Update lives text
    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}

