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
    private List<int> pontos;

    private void Awake()
    {
        this.caminhoParaOArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        var textoJson = File.ReadAllText(caminhoParaOArquivo);
        JsonUtility.FromJsonOverwrite(textoJson, this);
    }

    private void SalvarRanking()
    {
        var textoJson = JsonUtility.ToJson(this);
        File.WriteAllText(this.caminhoParaOArquivo, textoJson);
    }

    public void AdicionarPontuacao(int ponto)
    {
        this.pontos.Add(ponto);
        this.SalvarRanking();
    }

    public int Quantidade()
    {
        return this.pontos.Count;
    }

    public ReadOnlyCollection<int> getPontos()
    {
        return this.pontos.AsReadOnly();
    }
}
