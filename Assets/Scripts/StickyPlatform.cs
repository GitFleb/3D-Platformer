using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    Vector3 lastposition;
    Rigidbody playerRb;

    void Start()
    {
        lastposition = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 platformMove = transform.position - lastposition;
        if (playerRb != null)
        {
            playerRb.MovePosition(playerRb.position + platformMove);
        }

        lastposition = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = collision.rigidbody;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = null;
        }
    }
}
