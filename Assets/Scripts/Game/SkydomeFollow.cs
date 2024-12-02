using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkydomeFollow : MonoBehaviour
{
    public Transform player;

    private IEnumerator FindPlayer()
    {
        while (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
                Debug.Log("Joueur trouv� !");
            }
            else
            {
                Debug.LogWarning("Recherche du joueur...");
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Start()
    {
        StartCoroutine(FindPlayer());
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + new Vector3(-240, -10, 100);
        }
    }
}
