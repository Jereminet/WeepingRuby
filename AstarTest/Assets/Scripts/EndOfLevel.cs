using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{

    [SerializeField] private string loadLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("triggered");
            SceneManager.LoadScene(loadLevel);
        }
    }
}
