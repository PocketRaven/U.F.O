using System;
using UnityEngine;

public class Ammus : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public int damage = 1; 


    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        UFO ufo = other.gameObject.GetComponent<UFO>();
        if (ufo != null)
        {
            ufo.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}