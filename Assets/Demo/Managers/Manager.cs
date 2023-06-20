using UnityEngine;

namespace Demo.Managers
{
    public abstract class Manager : MonoBehaviour
    {
        private void Awake()
        {
            Bind();
        }

        protected abstract void Bind();
    }
}