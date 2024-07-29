using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhaDeChegada : MonoBehaviour
{
    public string proxFase;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.instance.CarregarCena(proxFase);
        }
    }
}
