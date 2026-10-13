using UnityEngine;
using TMPro;

public class ItemCollecter : MonoBehaviour
{
    public int score = 0; // Initialize coin count

    [SerializeField] TMP_Text scoreText;
    [SerializeField] AudioSource collectSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // Collect the item
            Destroy(other.gameObject);
            score++; // Increment coin count
            scoreText.text = "Score: " + score;
            collectSound.Play(); // Play the collection sound
            Debug.Log("Coin collected! Score: " + score);
        }

    }
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            score += 1; // Increment score when enemy is defeated
            scoreText.text = "Score: " + score;
            Debug.Log("Enemy defeated! Score: " + score);
        }
    }
}
