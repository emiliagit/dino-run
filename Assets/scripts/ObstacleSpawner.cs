using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float minY = -1.0f;
    [SerializeField] private float maxY = 0.7f;


    void Start()
    {
        StartCoroutine(spawnobstacle());
    }



    private IEnumerator spawnobstacle()
    {

        while (true)
        {
            int randomindex = Random.Range(0, obstacles.Length);
            float mintime = 0.6f;
            float maxtime = 1.8f;
            float randomtime = Random.Range(mintime, maxtime);

            

            if (randomindex == obstacles.Length - 1)
            {
                Vector3 spawnPosition = transform.position;
                spawnPosition.y = Random.Range(minY, maxY) * obstacles[randomindex].transform.localScale.y;
                Instantiate(obstacles[randomindex], spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(obstacles[randomindex], transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(randomtime);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
