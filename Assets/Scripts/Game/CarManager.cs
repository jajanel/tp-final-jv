using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject[] voitures;
    private float nextDelay = 3f;
    private float progress;
    public Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        progress = 6f;
        spawnPos = this.gameObject.transform.position;
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
            float difficulter = (GameManager.score / 10) + GameSettings.Difficulter;
            //Prochain délai est aléatoire autour de repeatDelay
            nextDelay = Random.Range(2f / difficulter, 3f / difficulter);
            if (nextDelay < 0.75) {
                nextDelay = 0.8f;
            }
        }
    }
    private void SpawnVoiture()
    {
        int index = Random.Range(0, voitures.Length);
        GameObject voiture = voitures[index];
        Instantiate(voiture, spawnPos, voiture.transform.rotation);
    }
}
