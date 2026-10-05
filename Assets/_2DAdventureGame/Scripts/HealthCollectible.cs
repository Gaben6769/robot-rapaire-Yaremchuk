using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Поле для завдання "Спробувати більше": сильніші аптечки
    public int healthAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        // Перевіряємо, чи це гравець і чи його здоров'я менше за максимальне
        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(healthAmount);
            Destroy(gameObject); // Знищуємо аптечку після використання
        }
    }
}