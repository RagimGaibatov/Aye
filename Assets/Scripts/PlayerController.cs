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
    [SerializeField] float jumpForce = 10f;
    [SerializeField] private float gravityModifier = 2;


    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    private float superDashSpeed = 1.3f;

    private float score = 0;

    private float copyDashSpeed;
    private float copyAnimSpeed;

    public bool gameOver;

    private int counterJump = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        copyDashSpeed = MoveLeft.dashSpeed;
        copyAnimSpeed = playerAnim.speed;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && counterJump > 0)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            counterJump--;
        }

        if (Input.GetKey(KeyCode.R) && gameOver == false)
        {
            MoveLeft.dashSpeed = superDashSpeed;
            playerAnim.speed = 2f;
            score += 20 * Time.deltaTime * superDashSpeed;
            superDashSpeed += 0.02f * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.R) && gameOver == false)
        {
            MoveLeft.dashSpeed = copyDashSpeed;
            playerAnim.speed = copyAnimSpeed;
            Debug.Log(score);
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
            dirtParticle.Stop();
            Debug.Log(score);
        }
    }
}