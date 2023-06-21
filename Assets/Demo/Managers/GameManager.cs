using CommonTools.Runtime.DependencyInjection;
using CommonTools.Runtime.Events;
using Demo.Events;

namespace Demo.Managers
{
    public class GameManager : Manager
    {
        protected override void Bind()
        {
            DI.Bind<GameManager>(this);
        }

        protected override void OnAwake()
        {
            var uiManager = DI.Resolve<UIManager>();
            
            GameEventSystem.AddListener<PlayerGotDamageEvent>(FinishLevel);
        }

        private void StartLevel()
        {
            // starting level
            
            GameEventSystem.Invoke<LevelStartedEvent>();
        }

        private void FinishLevel(object obj)
        {
            // ending level
        }
    }
}