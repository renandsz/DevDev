using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int pontuacaoTotal;

    public static GameController instance;

    public TextMeshProUGUI textoPontuacao;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AtualizarPontos(int valor)
    {
        pontuacaoTotal += valor;
        textoPontuacao.text = $"x {pontuacaoTotal}";
    }
    
}
