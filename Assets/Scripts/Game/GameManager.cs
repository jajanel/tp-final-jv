
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] routes;

    public Vector3 spawnPos;
    private float nextDelay = 5f;
    private float progress;
    private float repeatDelay = 2f;
    private float spawnz = 23.8f;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
        spawnPos = new Vector3(0,0, spawnz);
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;

        if (progress >= nextDelay)
        {
            //Spawner un obstacle et reset le progr�s
            progress = 0f;
            SpawnRoute();

            //Prochain d�lai est al�atoire autour de repeatDelay
            nextDelay = Random.Range(0.85f * repeatDelay, 1.15f * repeatDelay);
        }
    
    }

    private void SpawnRoute()
    {
        int index = Random.Range(0, routes.Length);
        GameObject route = routes[index];
        spawnz += route.GetComponent<BoxCollider>().size.z;
        spawnPos = new Vector3(0, 0, spawnz);
        Instantiate(route, spawnPos, route.transform.rotation);
    }
}
