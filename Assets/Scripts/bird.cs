using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public bool isdead;

    public float velocity = 1f;
    public Rigidbody2D rb2D;

    public GameManager managerGame;
    public GameObject DeathScreen;
    public GameObject StartScreen;


     void Start() 
    {
        Time.timeScale = 0;
        StartScreen.SetActive(true);
    }

    void Update()
    {
        // tıklamayı al
        if(Input.GetMouseButtonDown(0))
        {
            // havada kuşu sıçrat
            rb2D.velocity = Vector2.up * velocity;
        }

        if(Time.timeScale == 1)
        {
          StartScreen.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ScoreArea")
        {
            managerGame.UpdateScore();
        }
    }

     private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag =="DeathArea")
        {
            isdead = true;
            Time.timeScale = 0;

            StartScreen.SetActive(false);

            DeathScreen.SetActive(true);
        }
    }
}
