using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicaInstancia : MonoBehaviour
{
    [SerializeField]
    private bool sobrescreverExistente;
    private void Start()
    {
        var outrasInstancias = GameObject.FindGameObjectsWithTag(this.tag);
        foreach (var instancia in outrasInstancias)
        {
            if(instancia != this.gameObject)
            {
                if (this.sobrescreverExistente)
                {
                    GameObject.Destroy(instancia.gameObject);
                }
                else
                {
                    GameObject.Destroy(this.gameObject);
                }
            }
        }
    }
}
