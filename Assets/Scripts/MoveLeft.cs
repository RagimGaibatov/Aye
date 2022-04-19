using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float leftBound = -15;

    private PlayerController playerControllerScript;
    float dashSpeed = 1f;
    private float copyDashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        copyDashSpeed = dashSpeed;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime * dashSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (Input.GetKey(KeyCode.R))
        {
            dashSpeed = ObstacleSettings.Instance.SuperDashSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            dashSpeed = copyDashSpeed;
        }
    }
}