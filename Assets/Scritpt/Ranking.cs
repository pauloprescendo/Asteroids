using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "Ranking.json";
    private string caminhoParaOArquivo;

    [SerializeField]
    private List<Colocado> listaDeColocados;

    private void Awake()
    {
        this.caminhoParaOArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        if (File.Exists(this.caminhoParaOArquivo))
        {
            var textoJson = File.ReadAllText(caminhoParaOArquivo);
            JsonUtility.FromJsonOverwrite(textoJson, this);
        }
        else
        {
            this.listaDeColocados = new List<Colocado>();
        }
    }

    private void SalvarRanking()
    {
        var textoJson = JsonUtility.ToJson(this);
        File.WriteAllText(this.caminhoParaOArquivo, textoJson);
    }

    public string AdicionarPontuacao(int pontos, string nome)
    {
        var id = Guid.NewGuid().ToString();
        var novoColocado = new Colocado(nome, pontos, id);
        this.listaDeColocados.Add(novoColocado);
        this.listaDeColocados.Sort();
        this.SalvarRanking();
        return id;
    }

    public int Quantidade()
    {
        return this.listaDeColocados.Count;
    }

    public ReadOnlyCollection<Colocado> GetColocados()
    {
        return this.listaDeColocados.AsReadOnly();
    }

    public void AlterarNome(string novoNome, string id)
    {
        foreach (var item in this.listaDeColocados)
        {
            if (item.id == id)
            {
                item.nome = novoNome;
                break;
            }
        }
        SalvarRanking();
    }
}
[Serializable]
public class Colocado : IComparable
{
    public string nome;
    public int pontos;
    public string id;

    public Colocado(string nome, int pontos, string id)
    {
        this.nome = nome;
        this.pontos = pontos;
        this.id = id;
    }

    public int CompareTo(object obj)
    {
        var outroObjeto = obj as Colocado;
        return outroObjeto.pontos.CompareTo(this.pontos);
    }
}