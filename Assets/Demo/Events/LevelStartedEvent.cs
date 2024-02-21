using CommonTools.Runtime.Events;

namespace Demo.Events
{
    public class LevelStartedEvent : IEvent
    {
        public static LevelStartedEvent New()
        {
            return new LevelStartedEvent();
        }
    }
}