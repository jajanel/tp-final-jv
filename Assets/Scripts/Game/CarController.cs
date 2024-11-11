using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] voitures;
    private float repeatDelay = 2f;
    private float nextDelay = 5f;
    private float progress;
    public Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
        spawnPos = new Vector3(-123, 0, 22);


    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        if (progress >= nextDelay)
        {
            //Spawner un obstacle et reset le progrès
            progress = 0f;
            SpawnVoiture();

            //Prochain délai est aléatoire autour de repeatDelay
            nextDelay = Random.Range(0.85f * repeatDelay, 1.15f * repeatDelay);
        }
    }
    private void SpawnVoiture()
    {
        int index = Random.Range(0, voitures.Length);
        repeatDelay *= 0.99f;
        GameObject voiture = voitures[index];
        Instantiate(voiture, spawnPos, voiture.transform.rotation);
    }
}
