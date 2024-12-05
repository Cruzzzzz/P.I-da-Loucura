using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public AudioClip collectSound;  // Som que será tocado quando o player coletar a moeda
    public GameObject itemPrefab;   // Prefab que será gerado ao coletar a moeda (se você quiser)
    private bool isCollected = false;  // Garantir que a moeda não seja coletada mais de uma vez

    void Start()
    {
        // Garantir que o collider está configurado corretamente
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null && collider.isTrigger)
        {
            collider.isTrigger = false;  // Se estava marcado como trigger, desmarque
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player" e se a moeda ainda não foi coletada
        if (collision.collider.CompareTag("Player") && !isCollected)
        {
            isCollected = true; // Marca que a moeda foi coletada

            // Toca o som de coleta da moeda, mas garante que ele só toque uma vez
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
            }

            // Aumenta a pontuação (garantindo que o incremento aconteça apenas uma vez)
            ControladorDePontuação.Pontuacao++;

            // Instancia o novo item (se houver um prefab)
            if (itemPrefab != null)
            {
                Instantiate(itemPrefab, transform.position, transform.rotation);
            }

            // Destrói a moeda após a coleta
            Destroy(gameObject, collectSound.length);  // A moeda será destruída depois que o som terminar (evita cortes no áudio)
        }
    }
}





