using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Variables for player HP, the max hp a player can have and the health bar image
    public float playerHP;
    public float maxHP;
    public Image healthBar;
    void Start()
    {
        // Set max HP to the current starting player HP
        maxHP = playerHP;
    }

    void Update()
    {
        // Fill the health bar clamped between 0f and 1f
        healthBar.fillAmount = Mathf.Clamp(playerHP / maxHP, 0f , 1f);
    }

    // If the player collides with a projectile -1 HP
    // If the player has 0 HP or below, destroy the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            playerHP -= 1f;
            if (playerHP <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
