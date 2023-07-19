using CommonTools.Runtime.DependencyInjection;
using CommonTools.Runtime.Events;
using Demo.Events;

namespace Demo.Managers
{
    public class GameManager : Manager
    {
        private UIManager m_uiManager;
        
        protected override void Bind()
        {
            DI.Bind<GameManager>(this);
        }

        protected override void Resolve()
        {
            m_uiManager = DI.Resolve<UIManager>();
        }
        
        protected override void OnAwake()
        {
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