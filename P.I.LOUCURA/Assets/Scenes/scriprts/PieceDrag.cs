using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDrag : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;

    public Transform targetPosition; // Define a posi��o de encaixe no Inspector
    public float moveSpeed = 10f; // Velocidade de movimenta��o para a posi��o de encaixe
    public float snapDistance = 0.5f; // Dist�ncia m�nima para encaixar a pe�a automaticamente

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + offset;
    }

    void OnMouseUp()
    {
        // Verifica se a pe�a est� dentro da dist�ncia m�nima para encaixar
        if (Vector3.Distance(transform.position, targetPosition.position) <= snapDistance)
        {
            // Move diretamente para a posi��o do alvo
            transform.position = targetPosition.position;
        }
    }
}
