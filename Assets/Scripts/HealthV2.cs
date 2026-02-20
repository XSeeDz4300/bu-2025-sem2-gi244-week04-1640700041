using UnityEngine;

public class HealthV2 : MonoBehaviour
{
    public int maxHp = 100;
    private int accumdamage = 0;

    public void TakeDamage(int damage)
    {
        accumdamage += damage;
        if (accumdamage >= maxHp)
        {
            Destroy(gameObject);
        }
    }
}
