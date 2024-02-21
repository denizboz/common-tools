using CommonTools.Runtime.Events;

namespace Demo.Events
{
    public class PlayerGotDamageEvent : IEvent
    {
        public int Damage { get; }

        private PlayerGotDamageEvent(int damage)
        {
            Damage = damage;
        }

        public static PlayerGotDamageEvent New(int damage)
        {
            return new PlayerGotDamageEvent(damage);
        }
    }
}