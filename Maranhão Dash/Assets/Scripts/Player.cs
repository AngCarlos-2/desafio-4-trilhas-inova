using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float distancia;
    private bool isJumping = false;
    private Rigidbody2D rig;
    private GroundCheck groundChecked;

    public bool isPlaying = true;
    public float JumpForce;
    public TextMeshProUGUI textDistancia;
    public bool IsJumping { get => isJumping; set => isJumping = value; }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        groundChecked = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {   
        CalcularDistancia();

        if (Input.GetKey(KeyCode.UpArrow) && !IsJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }

        isJumping = !groundChecked.IsGrounded();
    }

    void CalcularDistancia()
    {
        if (isPlaying)
        {
            float distanciaTotal = distancia + Time.time * 10;
            int distanciaTotalInteira = (int) distanciaTotal;
            distanciaTotalInteira++;
            textDistancia.text = distanciaTotalInteira.ToString();

        } else
        {
            Time.timeScale = 0;
        }
    }
}
