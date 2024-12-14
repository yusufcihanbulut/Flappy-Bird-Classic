using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Birdy BirdScript;
    public GameObject Borular;
    public float height;
    public float spawnInterval = 2.5f;
    public float startDelay = 1.5f;

    public float pipeSpeed = 2f;
    public float speedIncreaseRate = 0.2f; 
    public float speedIncreaseInterval = 10f; 


    private void Start()
    {
        StartCoroutine(SpawnerObject());
        StartCoroutine(IncreaseSpeedOverTime());
    }

    private IEnumerator SpawnerObject()
    {
        yield return new WaitForSeconds(startDelay);

        while (!BirdScript.IsDead)
        {
            GameObject newPipe = Instantiate(Borular, new Vector3(3, Random.Range(-height, height), 0), Quaternion.identity);

           
            Move moveScript = newPipe.GetComponent<Move>();
            if (moveScript != null)
            {
                moveScript.speed = pipeSpeed;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator IncreaseSpeedOverTime()
    {
        while (!BirdScript.IsDead)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);
            pipeSpeed += speedIncreaseRate; 
        }
    }
}
