using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public AudioClip collectSound;  // Som que ser� tocado quando o player coletar a moeda
    public GameObject itemPrefab;   // Prefab que ser� gerado ao coletar a moeda (se voc� quiser)
    private bool isCollected = false;  // Garantir que a moeda n�o seja coletada mais de uma vez

    void Start()
    {
        // Garantir que o collider est� configurado corretamente
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null && collider.isTrigger)
        {
            collider.isTrigger = false;  // Se estava marcado como trigger, desmarque
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player" e se a moeda ainda n�o foi coletada
        if (collision.collider.CompareTag("Player") && !isCollected)
        {
            isCollected = true; // Marca que a moeda foi coletada

            // Toca o som de coleta da moeda, mas garante que ele s� toque uma vez
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
            }

            // Aumenta a pontua��o (garantindo que o incremento aconte�a apenas uma vez)
            ControladorDePontua��o.Pontuacao++;

            // Instancia o novo item (se houver um prefab)
            if (itemPrefab != null)
            {
                Instantiate(itemPrefab, transform.position, transform.rotation);
            }

            // Destr�i a moeda ap�s a coleta
            Destroy(gameObject, collectSound.length);  // A moeda ser� destru�da depois que o som terminar (evita cortes no �udio)
        }
    }
}





