using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //prefab for spawning
    public AsteroidScript asteroidPrefab;

    private float initSpawn = 5.0f;
    private float spawnRate = 20.0f;
    private int spawnAmount = 1;
    private float spawnDistance = 9.0f; //this is a hard code number, I want to change this to be relative to the screen bounds, maybe screen.width, screen.height
    private float trajectoryVarience = 15.0f;
    private void Start()
    {
        //on start will call named method, at the time of the second argument at the rate of the third
        InvokeRepeating(nameof(Spawn),this.initSpawn, this.spawnRate );
    }

    private void Spawn()
    {
        //changes spawn amount to a random number between 1 and 3
        this.spawnAmount = Random.Range(1, 4);

        //logic for actually spawning them
        for ( int i = 0; i < this.spawnAmount; i++)
        {
            //for spawn point
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = spawnDirection + this.transform.position;

            float varience = Random.Range(-trajectoryVarience, trajectoryVarience);
            Quaternion rotation = Quaternion.AngleAxis(varience, Vector3.forward);
            AsteroidScript asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }

    //setter for private spawn rate variable
    public void setSpawnRate(float nSpawnRate)
    {
        this.spawnRate = nSpawnRate;
    }
}
