
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
    private float spawnz = 0f;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
        spawnPos = new Vector3(-45,0, spawnz);
        for (int i = 0; i < 10; i++) {
            SpawnRoute();
        }
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;

        if (progress >= nextDelay)
        {
            //Spawner un obstacle et reset le progrès
            progress = 0f;
            SpawnRoute();

            //Prochain délai est aléatoire autour de repeatDelay
            nextDelay = Random.Range(0.85f * repeatDelay, 1.15f * repeatDelay);
        }
    
    }

    private void SpawnRoute()
    {
        int index = Random.Range(0, routes.Length);
        GameObject route = routes[index];
        spawnz += route.GetComponent<BoxCollider>().size.z;
        spawnPos = new Vector3(-45, 0, spawnz);
        Instantiate(route, spawnPos, route.transform.rotation);
    }
}
