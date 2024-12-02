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
    private Vector3 position;
    Rigidbody rb;
    public ParticleSystem particuleMort;
    private AudioSource sonMort;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Spawn Manager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
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
                //rb.MovePosition(transform.position + Vector3.forward * speed * horizontalInput * Time.deltaTime);
                //transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime, Space.World);
            }
            position = transform.position;
        }
        else
        {
            transform.position = position;
        }
        sonMort = GetComponent<AudioSource>();
        sonMort.volume = GameSettings.SoundVolume;
    }

    private void FixedUpdate()
    {
        if (!GameOverController.GetGameOver())
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput == 0)
            {
                playerAnim.SetBool("walk_b", false);
                rb.velocity = Vector3.zero;
            }
            else
            {
                playerAnim.SetBool("walk_b", true);
                rb.MovePosition(transform.position + Vector3.forward * speed * horizontalInput * Time.fixedDeltaTime);
                //transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime, Space.World);
            }
            position = transform.position;
        }
        else
        {
            transform.position = position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("voiture") )
        {
            //pk parfois l'animation est faite et quand la voiture nous frole, l'animation de marche continue
            playerAnim.SetBool("walk_b", false);
            playerAnim.SetBool("Death_b", true);
            GameOverController.GameOver();
            sonMort.Play();
            if(GameSettings.ParticuleBool)
            {
                StartCoroutine(MortCoroutine());
            }
            
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
        Debug.Log("on trigger exit");
    }
    private IEnumerator MortCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        ParticleSystem particleMort = Instantiate(particuleMort, this.gameObject.transform.position + new Vector3(0, 1, -3), particuleMort.transform.rotation);
        particleMort.Play();
        Destroy(gameObject);
        
    }
}
