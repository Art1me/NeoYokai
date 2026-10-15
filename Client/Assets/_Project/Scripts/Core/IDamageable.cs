namespace NeoYokai.Core
{
    // Интерфейс — это контракт. Любой класс, который его подключит, обязан иметь метод TakeDamage.
    public interface IDamageable
    {
        void TakeDamage(int amount);
    }
}