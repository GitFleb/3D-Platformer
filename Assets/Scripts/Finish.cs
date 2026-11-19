using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GetComponent<ItemCollecter>();
        ItemCollecter IC;

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Finish line crossed!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
