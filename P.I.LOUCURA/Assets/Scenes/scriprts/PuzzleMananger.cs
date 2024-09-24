using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleMananger : MonoBehaviour
{
    public PieceDrag[] pieces; // Refer�ncia para todas as pe�as
    public string nextSceneName; // Nome da cena para trocar
    public Button nextButton; // Refer�ncia para o bot�o que aparece quando as pe�as estiverem encaixadas

    void Start()
    {
        // Esconde o bot�o no in�cio
        nextButton.gameObject.SetActive(false);
    }
    
    void Update()
    {
        CheckAllPieces();
    }

    void CheckAllPieces()
    {
        // Verifica se todas as pe�as est�o encaixadas corretamente
        foreach (PieceDrag piece in pieces)
        {
            if (Vector3.Distance(piece.transform.position, piece.targetPosition.position) > piece.snapDistance)
            {
                return; // Se alguma pe�a n�o estiver encaixada, sai da fun��o
            }
        }

        // Se todas as pe�as est�o encaixadas, mostra o bot�o
        ShowNextButton();
    }

    void ShowNextButton()
    {
        // Ativa o bot�o
        nextButton.gameObject.SetActive(true);
    }
    public void NextButton()
    {

        SceneManager.LoadScene("Final");
    }
}