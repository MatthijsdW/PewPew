using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        // Navigate to Player
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
            GetComponent<NavMeshAgent>().destination = target.transform.position;
        else
            target = GameObject.FindGameObjectWithTag("Player");
    }
}
