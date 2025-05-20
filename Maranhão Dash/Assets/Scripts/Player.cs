using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float tempoInicial;
    private int maiorDistancia;
    /*private float distancia;
    private float distanciaTotal;*/
    private int distanciaMax;
    private bool isJumping = false;
    private Rigidbody2D rig;
    private GroundCheck groundChecked;

    public Perguntas gameOverValidation;
    public bool isPlaying = true;
    public float JumpForce;
    public TextMeshProUGUI textDistancia;
    [SerializeField] private TextMeshProUGUI textMaiorDistancia;
    public bool IsJumping { get => isJumping; set => isJumping = value; }

    // Start is called before the first frame update
    void Start()
    { 
        Time.timeScale = 1f;
        rig = GetComponent<Rigidbody2D>();
        groundChecked = GetComponentInChildren<GroundCheck>();

        textDistancia = FindAnyObjectByType<TextMeshProUGUI>();
        // textMaiorDistancia = GameObject.Find("Text_MaiorDistância")?.GetComponent<TextMeshProUGUI>();
        gameOverValidation = FindAnyObjectByType<Perguntas>();

        tempoInicial = Time.time;
        maiorDistancia = PlayerPrefs.GetInt("MaiorDistancia", 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalcularDistancia();

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !IsJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }

        isJumping = !groundChecked.IsGrounded();
        // GameOver();
    }

    void CalcularDistancia()
    {
        //distanciaTotal = distancia + Time.time * 10;
        //distanciaMax = (int)distanciaTotal;
        if (isPlaying)
        {
            float tempoDecorrido = Time.time - tempoInicial;
            // distanciaMax++;
            distanciaMax = Mathf.FloorToInt(tempoDecorrido * 10);
            textDistancia.text = distanciaMax.ToString();

        } else if (!isPlaying)
        {
            Time.timeScale = 0f;
        }
    }

    public void GameOver ()
    {
        isPlaying = false;

        if (distanciaMax > maiorDistancia)
        {
            maiorDistancia = distanciaMax;
            PlayerPrefs.SetInt("MaiorDistancia", maiorDistancia);
            PlayerPrefs.Save();
        }

        if (textMaiorDistancia != null)
        {
            textMaiorDistancia.text = maiorDistancia.ToString();
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Game");
    }
}
