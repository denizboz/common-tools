using CommonTools.Runtime.DependencyInjection;
using CommonTools.Runtime.Events;
using Demo.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Managers
{
    public class UIManager : MonoBehaviour
    {
        private GameManager m_gameManager;
        private Text m_damageText;

        private void Bind()
        {
            DI.Bind(this);
        }

        private void Resolve()
        {
            m_gameManager = DI.Resolve<GameManager>();
        }

        private void OnEnable()
        {
            EventManager.AddListener<LevelStartedEvent>(ShowLevelUI);
            EventManager.AddListener<PlayerGotDamageEvent>(ShowPlayerDamage);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<LevelStartedEvent>(ShowLevelUI);
            EventManager.RemoveListener<PlayerGotDamageEvent>(ShowPlayerDamage);
        }

        private void ShowLevelUI(object obj)
        {
            // showing in-level UI
        }

        private void ShowPlayerDamage(object obj)
        {
            var damage = (int)obj;
            m_damageText.text = $"Damage: {damage.ToString()}";
        }
    }
}