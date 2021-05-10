using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "Ranking.json";

    [SerializeField]
    private List<int> pontos;
    private void Awake()
    {
        this.pontos = new List<int>();
    }

    public void AdicionarPontuacao(int ponto)
    {
        this.pontos.Add(ponto);
        this.SalvarRanking();
    }

    private void SalvarRanking()
    {
        var textoJson = JsonUtility.ToJson(this);
        var caminhoParaOArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        File.WriteAllText(caminhoParaOArquivo, textoJson);
    }
}
