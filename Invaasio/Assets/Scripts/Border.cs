using UnityEngine;

public class Border : MonoBehaviour
{
    private int invadersPassed = 0;
    private int invadersPerHitPoint = 6; // Number of invaders required to reduce one hit point

    void OnTriggerEnter2D(Collider2D other)
    {
        InvaderUnit invader = other.gameObject.GetComponent<InvaderUnit>();
        if (invader != null)
        {
            invadersPassed++;
            if (invadersPassed >= invadersPerHitPoint)
            {
                Player player = FindObjectOfType<Player>();
                if (player != null)
                {
                    player.InvaderPassed();
                }
                invadersPassed = 0; // Reset the counter after reducing hit points
            }
            Destroy(other.gameObject);
        }
    }
}