using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouroEncantado : MonoBehaviour
{
    public GameObject [] quizPanel;
    private int pergunta;
    private Perguntas validacaoPergunta;

    // Start is called before the first frame update
    void Start()
    {
        pergunta = Random.Range(1, 5);
        validacaoPergunta = FindObjectOfType<Perguntas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (quizPanel != null) {
            quizPanel[pergunta].SetActive(true);

            if (validacaoPergunta.IsRight)
            {
                validacaoPergunta.RespostaCerta();
            } else
            {
                validacaoPergunta.RespostaErrada();
            }
        }
    }
}
