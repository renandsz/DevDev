using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private CircleCollider2D trigger;

    public GameObject particula;

    public int pontos = 10;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out _renderer);
        TryGetComponent(out trigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _renderer.enabled = false;
            trigger.enabled = false;
            particula.SetActive(true);

            Destroy(gameObject, 0.3f);

            GameController.instance.AtualizarPontos(pontos);

        }
    }
}
