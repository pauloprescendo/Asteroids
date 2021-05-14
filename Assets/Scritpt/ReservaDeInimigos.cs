using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaDeInimigos : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int quantidade;

    private Stack<GameObject> reservaDeInimigos;

    private void Start()
    {
        this.reservaDeInimigos = new Stack<GameObject>();
        this.CriarTodosOsInimigos();
    }

    private void CriarTodosOsInimigos()
    {
        for (int i = 0; i < this.quantidade; i++)
        {
            var inimigo = GameObject.Instantiate(this.prefab, this.transform);
            var objetoDaReserva = inimigo.GetComponent<ObjetoDaReservaDeInimigos>();
            objetoDaReserva.SetReserva(this);
            inimigo.SetActive(false);
            this.reservaDeInimigos.Push(inimigo);
        }
    }

    public GameObject PegarInimigo()
    {
        var inimigo = this.reservaDeInimigos.Pop();
        inimigo.SetActive(true);
        return inimigo;
    }

    public void DevolverInimigo(GameObject inimigo)
    {
        inimigo.SetActive(false);
        this.reservaDeInimigos.Push(inimigo);
    }

    public bool TemInimigo()
    {
        return this.reservaDeInimigos.Count > 0;
    }
}
