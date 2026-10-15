using UnityEngine;
using NeoYokai.Core;

namespace NeoYokai.Gameplay.Traps
{
    public class LaserTrap : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 25;

        // Срабатывает, когда чужой коллайдер касается нашего триггера
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Пытаемся взять компонент IDamageable у того, кто в нас вошел
            IDamageable target = other.GetComponent<IDamageable>();
            
            // Если компонент есть (это игрок или враг, а не просто стена)
            if (target != null)
            {
                target.TakeDamage(damageAmount);
            }
        }
    }
}