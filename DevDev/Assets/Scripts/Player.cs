using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 5f;

    public bool noAr = false;
    public bool podePuloDuplo = false;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rig);
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Pulo();
    }

    void Movimento()
    {
        Vector3 mov = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += mov * Time.deltaTime * velocidade;
    }

    void Pulo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!noAr)
            {
                rig.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
                podePuloDuplo = true;
            }
            else
            {
                if (podePuloDuplo)
                {
                    rig.velocity = new Vector3(rig.velocity.x, 0);
                    rig.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
                    podePuloDuplo = false;
                }
            }
            
            
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && rig.velocity.y > 0)
        {            
            rig.velocity = new Vector3(rig.velocity.x, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            noAr = false;
            podePuloDuplo = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            noAr = true;
        }
    }
}
