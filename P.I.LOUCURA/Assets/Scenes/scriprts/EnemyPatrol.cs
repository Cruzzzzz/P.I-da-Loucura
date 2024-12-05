using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 6f; // Velocidade do inimigo
    public Transform pointA; // Ponto A da patrulha
    public Transform pointB; // Ponto B da patrulha

    private Vector3 target; // Próximo ponto pra onde o inimigo vai

    void Start()
    {
        // Começa indo pro ponto A
        target = pointA.position;
    }

    void Update()
    {
        // Move o inimigo em direção ao ponto alvo
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Quando o inimigo chega no alvo, troca o destino
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }
}
