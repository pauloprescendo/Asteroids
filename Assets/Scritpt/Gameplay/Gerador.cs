﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private Pontuacao pontuacao;
    [SerializeField]
    private GameObject prefabInimigo;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private float raio;

    private void Start()
    {
        InvokeRepeating("Instanciar", 0f, this.tempo);
    }

    private void Instanciar()
    {
        var inimigo = GameObject.Instantiate(this.prefabInimigo);
        this.DefinirPosicaoInimigo(inimigo);
        inimigo.GetComponent<Seguir>().SetAlvo(this.alvo);
        inimigo.GetComponent<Pontuavel>().SetPontuacao(this.pontuacao);
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = new Vector3(
                        Random.Range(-this.raio, this.raio),
                        Random.Range(-this.raio, this.raio),
                        0);

        var posicaoInimigo = this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }
}
