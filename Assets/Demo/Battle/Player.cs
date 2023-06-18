using CommonTools.Events;
using CommonTools.Runtime.TaskManagement;
using Demo.Events;
using UnityEngine;

namespace Demo.Battle
{
    public class Player : MonoBehaviour
    {
        private GameTask m_damageTask;
        
        
        public void OnDamage(int damageTaken)
        {
            m_damageTask?.Kill();

            m_damageTask = GameTask.Wait(0.5f).Do((() => NotifyDamageUI(damageTaken)));
        }

        private void NotifyDamageUI(int damageTaken)
        {
            GameEventSystem.Invoke<PlayerGotDamageEvent>(damageTaken);
        }
    }
}