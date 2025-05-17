using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EfeitoChao : MonoBehaviour
{
    [SerializeField] private float velocidade;

    private Vector3 posicaoInicial;
    private float tamanhoRealdoTilemap;

    private void Awake()
    {
        posicaoInicial = transform.position;
        float tamanhoDoTilemap = GetComponent<TilemapRenderer>().chunkSize.x;
        float escala = transform.localScale.x;
        tamanhoRealdoTilemap = tamanhoDoTilemap * escala;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deslocamento = Mathf.Repeat(velocidade * Time.time, tamanhoRealdoTilemap);
        transform.position = posicaoInicial + Vector3.left * deslocamento;
    }
}
