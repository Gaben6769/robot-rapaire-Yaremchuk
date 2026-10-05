using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Налаштування керування та фізики
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    // Налаштування здоров'я
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    // Налаштування невразливості після отримання шкоди
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();

        // Встановлюємо повне здоров'я на початку гри
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Читаємо ввід гравця у щокадровому Update
        move = MoveAction.ReadValue<Vector2>();

        // Відлік таймера невразливості
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate()
    {
        // Фізичний рух виконуємо у FixedUpdate із використанням поля speed
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        // Перевірка: якщо передано від'ємне значення — це шкода
        if (amount < 0)
        {
            if (isInvincible)
            {
                return; // Якщо робот вже невразливий, виходимо й не знімаємо здоров'я
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }

        // Обмежуємо значення здоров'я в межах від 0 до maxHealth
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}