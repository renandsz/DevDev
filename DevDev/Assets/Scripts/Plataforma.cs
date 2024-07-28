using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float tempoCair = 0.3f;

    private TargetJoint2D joint;
    private BoxCollider2D colisor;
    private SpriteRenderer renderer;

    private Vector3 posicaoOriginal;
    private void Awake()
    {
        TryGetComponent(out joint);
        TryGetComponent(out colisor);
        TryGetComponent(out  renderer);
        posicaoOriginal = transform.position;
    }

    void Inicializar()
    {
        joint.enabled = true;
        colisor.isTrigger = false;
        renderer.enabled = true;
        transform.position = posicaoOriginal;
    }

    // Start is called before the first frame update
    void Start()
    {
        Inicializar();
    }

    public void Cair()
    {
        joint.enabled = false;
        colisor.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Cair), tempoCair);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.layer == LayerMask.NameToLayer("GameOver"))
        {
            //Destroy(gameObject);
            renderer.enabled = false;
            Invoke(nameof(Inicializar), tempoCair);
        }
    }

}
