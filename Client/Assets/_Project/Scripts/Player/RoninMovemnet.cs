using UnityEngine;
using UnityEngine.InputSystem;

namespace NeoYokai.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RoninMovement : MonoBehaviour
    {
        [Header("Настройки бега")]
        [SerializeField] private float moveSpeed = 7f;

        [Header("Настройки рывка (Dash)")]
        [SerializeField] private float dashSpeed = 22f;
        [SerializeField] private float dashDuration = 0.15f;
        [SerializeField] private float dashCooldown = 0.8f;

        private Rigidbody2D _rb;
        private Vector2 _moveInput;
        private Vector2 _lastMoveDirection = Vector2.right;

        private bool _isDashing;
        private bool _canDash = true;

        // Свойство для ловушек и врагов: во время рывка самурай неуязвим!
        public bool IsInvulnerable => _isDashing;

        private InputAction _moveAction;
        private InputAction _dashAction;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            // Находим глобальные действия из стандартного InputSystem_Actions в Unity 6
            _moveAction = InputSystem.actions.FindAction("Move");
            // Для рывка используем действие Jump (Пробел на ПК / кнопка геймпада)
            _dashAction = InputSystem.actions.FindAction("Jump");
        }

        private void OnEnable()
        {
            if (_dashAction != null)
                _dashAction.performed += OnDashPerformed;
        }

        private void OnDisable()
        {
            if (_dashAction != null)
                _dashAction.performed -= OnDashPerformed;
        }

        private void Update()
        {
            if (_isDashing) return;

            // Считываем вектор движения (WASD / Стик)
            if (_moveAction != null)
            {
                _moveInput = _moveAction.ReadValue<Vector2>();
                
                // Запоминаем последнее направление, чтобы рывок работал даже с места
                if (_moveInput.sqrMagnitude > 0.01f)
                {
                    _lastMoveDirection = _moveInput.normalized;
                }
            }
        }

        private void FixedUpdate()
        {
            // Во время рывка обычное управление не перезаписывает скорость
            if (_isDashing) return;

            // В Unity 6 используем linearVelocity вместо устаревшего velocity
            _rb.linearVelocity = _moveInput.normalized * moveSpeed;
        }

        private void OnDashPerformed(InputAction.CallbackContext context)
        {
            if (_canDash && !_isDashing)
            {
                _ = PerformDashAsync();
            }
        }

        // Современная асинхронность Unity 6 через Awaitable (без старых корутин!)
        private async Awaitable PerformDashAsync()
        {
            _isDashing = true;
            _canDash = false;

            // Выстреливаем персонажа в направлении движения
            _rb.linearVelocity = _lastMoveDirection * dashSpeed;

            // Ждем длительность рывка
            await Awaitable.WaitForSecondsAsync(dashDuration);

            _rb.linearVelocity = Vector2.zero;
            _isDashing = false;

            // Ждем перезарядку рывка
            await Awaitable.WaitForSecondsAsync(dashCooldown);
            _canDash = true;
        }
    }
}