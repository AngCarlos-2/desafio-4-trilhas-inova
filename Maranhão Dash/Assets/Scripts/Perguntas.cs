using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perguntas : MonoBehaviour
{
    public GameObject panelQuiz;
    public GameObject GameOverScreen;
    public Player player;
    public PlayerSpawner spawner;
    private bool isRight;
    private bool gameover = false;
    public bool IsRight { get => isRight; set => isRight = value; }
    public bool Gameover { get => gameover; set => gameover = value; }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (panelQuiz != null && panelQuiz.activeInHierarchy) {
            Time.timeScale = 0;
        }
    }

    public void RespostaCerta()
    {
        panelQuiz.SetActive(false);
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
        IsRight = true;

        int index = PlayerPrefs.GetInt("PersonagemSelecionado", 0);

        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        if (player != null)
        {
            Vector3 novaPosicao = player.transform.position + new Vector3(5f, 0f, 0f);
            player.transform.position = novaPosicao;
        }
        else
        {
            Debug.LogWarning("Player não foi encontrado.");
        }
    }

    public void RespostaErrada() 
    {
        isRight = false;
        if (!IsRight)
        {
            panelQuiz.SetActive(false);
            Gameover = true;
            if (GameOverScreen != null && Gameover)
            {
                GameOverScreen.SetActive(true);
                player.GameOver();
            }
        }
    }
}
