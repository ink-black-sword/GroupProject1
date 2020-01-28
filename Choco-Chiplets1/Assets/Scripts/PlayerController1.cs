using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public Text livesText;
    public Text levelText;
    public Text snacksText;

    private Rigidbody2D rb2d;
    private int lives;
    private int level;
    private int snacks;
    private bool gameOver;
    private bool restart;
    private bool nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lives = 3;
        level = 1;
        snacks = 0;
        livesText.text = "";
        levelText.text = "";
        snacksText.text = "";
        SetLivesText ();
        SetLevelText ();
        SetSnacksText ();
        gameOver = false;
        nextLevel = false;
        restart = false;

    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = ("" + lives/3);
        levelText.text = ("" + level/2);
        snacksText.text = ("" + snacks/330);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

/*
        if (Input.GetKey("r"))
        {
            GameObject.Find("MainCamera").transform.position = new Vector3(21.5f, 16, -10);
            transform.position = new Vector2(14.75f, 14);
        }
*/

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level 2");
            }

        }

        /*
        if (nextLevel)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("Level 1");
            }
        }
        */
    }

    void FixedUpdate()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            snacks = snacks + 1;
            SetScoreText();

        }

        if (other.gameObject.CompareTag("Pickup1"))
        {
            other.gameObject.SetActive(false);
            snacks = snacks + 1;
            SetSnacksText();



            if (other.gameObject.CompareTag("Enemy"))
            {
                lives = lives - 1;
                
                if (gameOver == true)
                {
                    other.gameObject.SetActive(false);
                }


            }
        }
     
    }

    void SetScoreText()
    {
        snacksText.text = snacks.ToString();

        if (snacks == 330)
        {
            //
        }
    }

    void SetLivesText()
    {
        livesText.text = lives.ToString();
        if (lives == 0)
        {
            gameOver = true;
        }
    }

    void SetLevelText()
    {
        levelText.text = level.ToString();
    }

    void SetSnacksText()
    {
        snacksText.text = snacks.ToString();
    }

    public void GameOver()
    {
        if (gameOver == true)
        {
            restart = true;
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
            if (Input.GetKey("enter"))
            {
                //resetGameData();
            }
        }
    }
}
