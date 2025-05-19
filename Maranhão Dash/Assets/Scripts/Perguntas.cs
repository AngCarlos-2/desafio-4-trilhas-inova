using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perguntas : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject panelQuiz;
    public GameObject GameOverScreen;
    public Player player;
    private bool isRight;
    private bool gameover = false;
    public bool IsRight { get => isRight; set => isRight = value; }
    public bool Gameover { get => gameover; set => gameover = value; }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        respawnPoint = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (panelQuiz != null) {
            Time.timeScale = 0;
        }
    }

    public void RespostaCerta()
    {
        panelQuiz.SetActive(false);
        Time.timeScale = 1;
        player.transform.position = respawnPoint.transform.position;
        IsRight = true;
    }

    public void RespostaErrada() 
    {
        panelQuiz.SetActive(false);
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(true);
            Gameover = true;
        }
    }
}
