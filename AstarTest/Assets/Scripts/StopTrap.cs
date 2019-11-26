using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StopTrap : MonoBehaviour
{

    //[SerializeField] private string loadLevel;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player pl = other.GetComponent<Player>();
            pl.canMove = false;
            yield return new WaitForSeconds(1.0f);
            pl.canMove = true;

        }
    }
}
