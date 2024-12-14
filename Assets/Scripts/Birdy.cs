using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdy : MonoBehaviour
{
    public float velocity = 1f;
    public Rigidbody2D rb2D;
    public bool IsDead;

    public GameManager managerGame;
    public GameObject DeathScreen;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Start()
    {
        Time.timeScale = 1;
        rb2D.freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")
        {
            managerGame.UpdateScore();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadArea")
        {
            IsDead = true;
            Time.timeScale = 0;

            DeathScreen.SetActive(true);
        }
    }
}
