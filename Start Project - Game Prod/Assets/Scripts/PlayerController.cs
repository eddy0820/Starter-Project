using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject roundPrefab;
    public float totalTime = 15.0f;
    float totalStartTime = 3.0f;
    float timer;
    float startTimer;

    public Text timerText;
    public Text startText;

    public Text scoreText;

    public bool gameOver = false;

    AudioSource audioSource;
    public AudioSource backgroundSource;
    public AudioClip winSource;
    public AudioClip loseSource;

    public AudioClip shootSound;
    public AudioClip startSound;
    void Start()
    {
        timer = totalTime;
        timerText.text = timer.ToString();
        
        startTimer = totalStartTime;
        startText.text = "Left click to shoot the green targets. \nUse A and D to move left and right.";

        gameOver = false;

        audioSource = GetComponent<AudioSource>();

        PlaySound(startSound);
        backgroundSource.PlayDelayed(2);  
    }

    void Update() 
    {   
        timer -= Time.deltaTime;
        startTimer -= Time.deltaTime;

        if(startTimer < 0)
        {
            startText.text = "";
        }

        if (timer < 0)
        {
            gameOver = true;
            int score = int.Parse(scoreText.text);

            if(score <= 3)
            {
                startText.text = "Score: " + scoreText.text + " . Try better next time.";

                backgroundSource.Stop();  
                PlaySound(loseSource);
            }
            else
            {
                startText.text = "Score: " + scoreText.text + " . Good job!";
                backgroundSource.Stop();  
                PlaySound(winSource);
            }  
        }

        if(gameOver == false)
        {
            timerText.text = ((int)timer).ToString();

            float horizontal = Input.GetAxis("Horizontal");
            Vector2 position = transform.position;   
            position.x = position.x + 3.0f * horizontal * Time.deltaTime;
            transform.position = position;

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Launch();
            }
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void Launch()
    {
        GameObject roundObject = Instantiate(roundPrefab);
        roundObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        PlaySound(shootSound);

        
    }
}
