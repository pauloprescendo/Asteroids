using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDinamico : MonoBehaviour
{
    private Text texto;

    private void Awake()
    {
        this.texto = this.GetComponent<Text>();
    }

    public void AtualizarTexto(int numero)
    {
        this.texto.text = numero.ToString();
    }

    public void AtualizarTexto(string novoText)
    {
        this.texto.text = novoText.ToString();
    }
}
