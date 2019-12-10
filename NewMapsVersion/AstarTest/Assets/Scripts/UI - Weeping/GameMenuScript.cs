using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{

    public GameObject player;
    public GameObject goal;
    public Text distanceText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, goal.transform.position);
        distanceText.text = dist.ToString();  
    }
}
