using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public float cooldown = 1;

    private float elapsedTime = 0;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > cooldown)
        {
            float x = Random.Range(-24, 24);
            float z = Random.Range(-24, 24);

            GameObject enemy = Instantiate(monster);
            enemy.transform.position = new Vector3(x, 3, z);
            elapsedTime = 0;
        }
    }
}
