﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Rigidbody Object")]
    public Rigidbody2D rb;
    [Header("Default Down Speed")]
    public float downSpeed = 20f;
    [Header("Default Movement Speed")]
    public float movementSpeed = 10f;
    [Header("Default Directional Movement Speed")]
    public float movement = 0f;
    [Header("Score Text")]
    public Text scoreText;
    private float topScore = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if(movement < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }
    void FixedUpdate()
    {
        Vector2 velocity  = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        //GameObject.Find("DoodleHead").SetActive(false);
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }
}
