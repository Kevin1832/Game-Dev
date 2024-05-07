using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesController : MonoBehaviour
{
    public static event Action OnPlayerHitSpike;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        
            OnPlayerHitSpike?.Invoke(); 
            
   
        }
    }
}
