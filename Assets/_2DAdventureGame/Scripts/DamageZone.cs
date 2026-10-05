using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Поле для завдання "Спробувати більше": "ультразона", яка знімає більше здоров'я
    public int damageAmount = -1; // Значення має бути від'ємним!

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            // Передаємо значення шкоди (наприклад, -1 або -2)
            controller.ChangeHealth(damageAmount);
        }
    }
}