using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int pontuacaoTotal;

    public static GameController instance;

    public TextMeshProUGUI textoPontuacao;

    public GameObject painelGameOver;

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

    public void GameOver()
    {
        painelGameOver.SetActive(true);
    }

    public void Recomecar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    
}
