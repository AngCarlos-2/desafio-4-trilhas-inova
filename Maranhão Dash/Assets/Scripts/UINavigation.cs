using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UINavigation : MonoBehaviour
{
    public GameObject panelInício;
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] border;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject b in border)
        {
            b.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("SeleçãoPersonagem");
    }

    public void SelecionarPersonagem(int index)
    {
        /*int personagem = Random.Range(0, 3);

        if (buttons != null && buttons[personagem] != null)
        {
            border[personagem].SetActive(true);
            
        } else
        {
            border[personagem].SetActive(false);
        }*/
        for (int i = 0; i < border.Length; i++)
        {
            border[i].SetActive(i == index); 
        }
    }

    public void Jogar()
    {
        //int personagem = Random.Range(0, 3);

        //if (buttons[4] != null && buttons[personagem] != null)
        //{
            SceneManager.LoadScene("Game");
        //}
    }
}
