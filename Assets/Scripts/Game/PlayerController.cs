using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float horizontalInput;
    private float speed = 5f;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Spawn Manager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOverController.GetGameOver()) { 
            horizontalInput = Input.GetAxis("Horizontal");
            if(horizontalInput == 0)
            {
                playerAnim.SetBool("walk_b", false);
            }
            else
            {
                playerAnim.SetBool("walk_b", true);
                transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime, Space.World);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("voiture") )
        {
            //pk parfois l'animation est faite et quand la voiture nous frole, l'animation de marche continue
            playerAnim.SetBool("Death_b", true);
            GameOverController.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("routeFini"))
        {
           gameManager.compteScore();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        other.isTrigger = false;
    }
}
