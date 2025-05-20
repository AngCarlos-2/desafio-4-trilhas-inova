using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouroEncantado : MonoBehaviour
{
    public GameObject [] quizPanel;
    private int pergunta;
    [SerializeField] private Perguntas[] validacaoPergunta;

    // Start is called before the first frame update
    void Start()
    {
       pergunta = Random.Range(0, 4);
       validacaoPergunta = FindObjectsOfType<Perguntas>(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (quizPanel != null) {
            quizPanel[pergunta].SetActive(true);

            if (validacaoPergunta[pergunta].IsRight)
            {
                validacaoPergunta[pergunta].RespostaCerta();
            } else
            {
                validacaoPergunta[pergunta].RespostaErrada();
            }
        }
    }
}
