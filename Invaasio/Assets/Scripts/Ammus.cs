using UnityEngine;

public class Ammus : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    private float lifespan = 1f; 

    public void SetLifespan(float newLifespan)
    {
        lifespan = newLifespan;
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}