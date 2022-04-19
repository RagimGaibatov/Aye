using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] float jumpSpeed;


    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;


    public float score = 0;

    private float speedScore = 1.3f;

    private float copyAnimSpeed;

    public bool gameOver;

    private int counterJump = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        copyAnimSpeed = playerAnim.speed;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && counterJump > 0)
        {
            playerRb.velocity = new Vector3(0, jumpSpeed, 0);

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            counterJump--;
        }

        if (Input.GetKey(KeyCode.R) && gameOver == false)
        {
            playerAnim.speed = speedScore;
            score += Time.deltaTime * Mathf.Pow(speedScore, 5);
            speedScore += 0.015f * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.R) && gameOver == false)
        {
            playerAnim.speed = copyAnimSpeed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            counterJump = 2;
            dirtParticle.Play();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            explosionParticle.Play();
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.gameObject.SetActive(false);
        }
    }
}