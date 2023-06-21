using UnityEngine;

namespace Demo.Managers
{
    public abstract class Manager : MonoBehaviour
    {
        private void Awake()
        {
            Bind();
            OnAwake();
        }

        protected abstract void Bind();
        protected abstract void OnAwake();
    }
}