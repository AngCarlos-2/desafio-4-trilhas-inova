using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMaiorDistancia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textMaiorDistancia != null)
        {
            textMaiorDistancia.text = PlayerPrefs.GetInt("MaiorDistancia").ToString();
        }
    }
}
