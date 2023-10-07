using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Dinosaurio : MonoBehaviour
{
    [SerializeField] private float upForce = 5f;
    private Rigidbody2D dinoRB;
    public bool isGrounded = true;

    private Animator playeranimator;
    private bool isCrouching = false;

    [SerializeField] GameOverScreen Death;

    void Start()
    {
        dinoRB = GetComponent<Rigidbody2D>();
        playeranimator = GetComponent<Animator>();
        
    }



    // Update is called once per frame
    void Update()
    {

        playeranimator.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            dinoRB.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Cambia el estado de agacharse.
            isCrouching = !isCrouching;

            // Activa o desactiva la animación de agacharse en el Animator.
            playeranimator.SetBool("isCrouching", isCrouching);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            // Cambia el estado de agacharse.
            isCrouching = false;

            // Desactiva la animación de agacharse en el Animator.
            playeranimator.SetBool("isCrouching", isCrouching);

            // Puedes agregar aquí cualquier otra lógica que necesites al dejar de agacharte.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Death.ActiveScreen();
        }


    }

    
}

