using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Velocidade do movimento
    public float width = 0.5f;  // Largura do movimento

    private Vector3 startPosition;

    void Start()
    {
        // Guarda a posi��o inicial do objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula o novo valor de x usando uma fun��o senoidal
        float newX = Mathf.Sin(Time.time * speed) * width;

        // Atualiza a posi��o do objeto mantendo o eixo y e z fixos
        transform.position = new Vector3(startPosition.x + newX, startPosition.y, startPosition.z);
    }
}
