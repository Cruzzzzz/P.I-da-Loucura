using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Importa o namespace para usar TextMeshPro

public class EndGame : MonoBehaviour
{
    public Image endGameImage;
    public Player player;
    public TMP_Text contadorPontos; // Referência para o contador de pontos

    void Start()
    {
        endGameImage.gameObject.SetActive(false);
    }

    public void ShowEndGameImage()
    {
        endGameImage.gameObject.SetActive(true);
        contadorPontos.gameObject.SetActive(false); // Oculta o contador de pontos quando a imagem aparece
    }

    void Update()
    {
        if (player.score >= 10)
        {
            ShowEndGameImage();
        }
    }

    public void Next()
    {
        SceneManager.LoadScene("Biblioteca");
    }
}