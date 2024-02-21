using CommonTools.Runtime.DependencyInjection;
using CommonTools.Runtime.Events;
using Demo.Events;
using UnityEngine;

namespace Demo.Managers
{
    public class GameManager : MonoBehaviour
    {
        private UIManager m_uiManager;
        
        private void Bind()
        {
            DI.Bind(this);
        }

        private void Resolve()
        {
            m_uiManager = DI.Resolve<UIManager>();
        }
        
        private void Awake()
        {
            EventManager.AddListener<PlayerGotDamageEvent>(FinishLevel);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<PlayerGotDamageEvent>(FinishLevel);
        }

        private void StartLevel()
        {
            // starting level
            EventManager.Invoke(LevelStartedEvent.New());
        }

        private void FinishLevel(PlayerGotDamageEvent _)
        {
            // ending level
        }
    }
}