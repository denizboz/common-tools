using CommonTools.Events;
using CommonTools.Runtime.DependencyInjection;
using Demo.Events;

namespace Demo.Managers
{
    public class GameManager : Manager
    {
        protected override void Bind()
        {
            DI.Bind<GameManager>(this);
        }

        private void Start()
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