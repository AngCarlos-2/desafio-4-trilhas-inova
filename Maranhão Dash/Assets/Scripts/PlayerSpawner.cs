using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Player[] personagens; 
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        int index = PlayerPrefs.GetInt("PersonagemSelecionado", 0); 
        if (index >= 0 && index < personagens.Length)
        {
            Instantiate(personagens[index].gameObject, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Índice de personagem inválido!");
        }
    }
}
