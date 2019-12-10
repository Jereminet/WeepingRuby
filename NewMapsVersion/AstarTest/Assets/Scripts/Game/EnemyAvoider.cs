using UnityEngine;
using System.Collections;
using LOS.Event;
using UnityEngine.Audio;
using UnityEngine.UI;


public class EnemyAvoider : MonoBehaviour
{

    public float deathDistance = 0.5f;
    public float distanceAway;
    public Transform thisObject;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent navComponent;
    private bool freeze = false;
    public static float deathCounter = 0;
    public Text dCounter;

    public GameObject GameOverMenuUI;
    private bool gameOver;

    private AudioManager audioManager;

    [HideInInspector]
    public AudioSource beat;
    private void OnNotLit()
    {
        freeze = false;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;

    }

    private void OnLit()
    {
        freeze = true;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        beat.Pause();

    }
    private void Awake()
    {
        gameOver = false;
        beat = GetComponent<AudioSource>();
        audioManager = AudioManager.instance;
        deathCounter = audioManager.getDeaths();
        dCounter.text = deathCounter.ToString();
    }

    // Use this for initialization
    void Start()
    {

        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        LOSEventTrigger trigger = GetComponent<LOSEventTrigger>();
        trigger.OnNotTriggered += OnNotLit;
        trigger.OnTriggered += OnLit;

    }

    // Update is called once per frame
    void Update()
    {



        if (freeze)
        { gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true; }
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist < distanceAway && !beat.isPlaying && !freeze)
        {
            beat.Play();
        }

        if (target && dist < distanceAway)
        {
            navComponent.SetDestination(target.position);
        }
        else
        {
            if (target = null)
            {
                target = this.gameObject.GetComponent<Transform>();
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
        if (dist <= deathDistance)
        {
            if (!gameOver)
            {
                audioManager.die();              
                deathCounter = audioManager.getDeaths();
                dCounter.text = deathCounter.ToString();
            }
            Time.timeScale = 0;
            gameOver = true;
            GameOverMenuUI.SetActive(true);


        }
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameOverMenuUI.SetActive(false);
                gameOver = false;
                Time.timeScale = 1;
                Application.LoadLevel(Application.loadedLevel);
            }
        }

    }
    

}