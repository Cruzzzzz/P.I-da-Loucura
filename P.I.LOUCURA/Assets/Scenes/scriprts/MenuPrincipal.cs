using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string NomeDoLevelDeJogo;
    [SerializeField] private GameObject PainelMenuInicial;
    [SerializeField] private GameObject PainelOpcoes;
    [SerializeField] private GameObject PainelTeclas;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo);
    }
    public void AbrirOpções()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
    public void FecharOpções()
    {
        PainelOpcoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }
    public void AbrirTeclas()
    {
        PainelOpcoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");

    }
}
