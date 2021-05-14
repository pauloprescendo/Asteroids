using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaPontuacao : MonoBehaviour
{
    [SerializeField]
    private TextoDinamico textoPontuacao;
    [SerializeField]
    private TextoDinamico textoNome;
    [SerializeField]
    private Ranking ranking;
    private Pontuacao pontuacao;
    private string id;

    private void Start()
    {
        int totalDePontos = this.GetPontuacao();
        string nomedaPessoa = this.GetNome();
        this.textoPontuacao.AtualizarTexto(totalDePontos);
        this.textoNome.AtualizarTexto(nomedaPessoa);
        this.id = this.ranking.AdicionarPontuacao(totalDePontos, nomedaPessoa);
    }

    private int GetPontuacao()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        var totalDePontos = -1;
        if (this.pontuacao != null)
        {
            totalDePontos = this.pontuacao.Pontos;
        }

        return totalDePontos;
    }

    private string GetNome()
    {
        if (PlayerPrefs.HasKey("UltimoNome"))
        {
            return PlayerPrefs.GetString("UltimoNome");
        }
        return "Nome";
    }

    public void AlterarNome(string nome)
    {
        this.ranking.AlterarNome(nome, this.id);
        PlayerPrefs.SetString("UltimoNome", nome);
    }
}
