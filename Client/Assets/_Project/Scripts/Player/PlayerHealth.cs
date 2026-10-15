using UnityEngine;
using NeoYokai.Core; // Подключаем наше ядро

namespace NeoYokai.Gameplay.Player
{
    // Наследуем MonoBehaviour для работы в Unity, и IDamageable для получения урона
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 100;
        private int _currentHealth;
        
        private RoninMovement _movement;

        private void Awake()
        {
            _currentHealth = maxHealth;
            _movement = GetComponent<RoninMovement>();
        }

        public void TakeDamage(int amount)
        {
            // МАГИЯ РЫВКА: Если самурай делает Dash, он неуязвим (i-frames)
            if (_movement != null && _movement.IsInvulnerable)
            {
                Debug.Log("УКЛОНЕНИЕ! Урон прошел мимо.");
                return;
            }

            _currentHealth -= amount;
            Debug.Log($"ПОЛУЧЕН УРОН: {amount}. Осталось HP: {_currentHealth}");

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("СИГНАЛ ПРЕРВАН. Ронин уничтожен.");
            gameObject.SetActive(false); // Временно просто прячем квадрат
        }
    }
}