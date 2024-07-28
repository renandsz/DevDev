using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private SpriteRenderer renderer;

    private CircleCollider2D trigger;

    public GameObject particula;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out renderer);
        TryGetComponent(out trigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            renderer.enabled = false;
            trigger.enabled = false;
            particula.SetActive(true);

            Destroy(gameObject, 0.3f);

        }
    }
}
