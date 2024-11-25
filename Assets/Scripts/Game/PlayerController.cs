using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    private float speed = 5f;
    public TextMeshProUGUI scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = $"Score:{score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOverController.GetGameOver()) { 
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime,Space.World);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("voiture") )
        {
            GameOverController.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("routeFini"))
        {
            score++;
            scoreText.text = $"Score:{score}";
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        other.isTrigger = false;
    }
}
