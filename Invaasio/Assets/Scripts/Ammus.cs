using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammus : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float lifespan = 1f;

    void Start()
    {
        Destroy(gameObject, lifespan);
        Debug.Log("Bullet Destroyed in " + lifespan + " seconds.");
    }
    void Update()
    {
        this.transform.position +=  this.direction * this.speed * Time.deltaTime;
    }
}
