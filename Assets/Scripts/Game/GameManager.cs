
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

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject animal = routes[index];
        Instantiate(animal, spawnPos, animal.transform.rotation);
    }
}
