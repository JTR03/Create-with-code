using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private Prototype5GameManager gameManager;
    [SerializeField] private int difficulty;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("GameManager").GetComponent<Prototype5GameManager>();
    }

    private void SetDifficulty()
    {
        gameManager.StartBtn(difficulty);
    }
}
