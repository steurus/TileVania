using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int pointsForCoinPickup=100;

    bool wasCollected=false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player" &&!wasCollected)
        {
            wasCollected=true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickUpSFX,Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

}
