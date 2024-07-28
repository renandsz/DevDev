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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rig);
        TryGetComponent(out animator);
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        PuloOG();
    }

    void Movimento()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        Vector3 mov = new Vector3(inputX, 0, 0);
        transform.position += mov * Time.deltaTime * velocidade;

        if(inputX > 0)
        {
            animator.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(inputX < 0)
        {
            animator.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            animator.SetBool("andando", false);
        }
        
    }

    void PuloOG()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!noAr)
            {
                rig.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
                podePuloDuplo = true;
                animator.SetBool("pulando", true);
            }
            else
            {
                if (podePuloDuplo)
                {                    
                    rig.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
                    podePuloDuplo = false;
                    animator.SetBool("pulando", true);
                }
            }



        }
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
            animator.SetBool("pulando", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            noAr = true;
            animator.SetBool("pulando", true);
        }
    }
}
