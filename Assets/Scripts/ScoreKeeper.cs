using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private PlayerController playercontroller;

    // Start is called before the first frame update
    void Start()
    {
        playercontroller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Score :\n" + (int) playercontroller.score;
    }
}