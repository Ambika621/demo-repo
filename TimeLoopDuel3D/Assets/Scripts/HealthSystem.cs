using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public Image healthBar;
    public Transform spawnPoint;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        transform.position = spawnPoint.position;
        ResetHealth();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
}
