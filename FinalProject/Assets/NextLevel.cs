using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NextLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelCounterText;

    public void OnTriggerEnter2D(Collider2D other)
    {
   
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");
            GetComponent<SpriteRenderer>().color = Color.blue; 

        
            if (levelCounterText != null)
            {
                levelCounterText.text = "Congratulations! \nYou've reached a new level!";
      
            }
        }
    }
}