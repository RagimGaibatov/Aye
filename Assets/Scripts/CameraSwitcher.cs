using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;

    private PlayerController playerController;
    [SerializeField] private float maxTime = 1f;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver)
        {
            time += Time.deltaTime;
            if (maxTime <= time)
            {
                cameras[0].gameObject.SetActive(false);
                cameras[1].gameObject.SetActive(true);
                cameras[1].transform.Rotate(Vector3.forward, 25f * Time.deltaTime);
                cameras[1].transform.Translate(0, 1f * Time.deltaTime, 0, Space.World);
            }
        }
    }
}