using CommonTools.Runtime.DependencyInjection;
using CommonTools.Runtime.Events;
using Demo.Events;
using UnityEngine.UI;

namespace Demo.Managers
{
    public class UIManager : Manager
    {
        private Text m_damageText;
        
        protected override void Bind()
        {
            DI.Bind<UIManager>(this);
        }

        protected override void OnAwake()
        {
            var gameManager = DI.Resolve<GameManager>();
            
            GameEventSystem.AddListener<LevelStartedEvent>(ShowLevelUI);
            GameEventSystem.AddListener<PlayerGotDamageEvent>(ShowPlayerDamage);
        }

        private void ShowLevelUI(object obj)
        {
            // showing in-level UI
        }

        private void ShowPlayerDamage(object obj)
        {
            var damage = (int)obj;
            m_damageText.text = $"Damage: {damage}";
        }
    }
}