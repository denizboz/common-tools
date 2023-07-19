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

        private void Start()
        {
            Resolve();
            OnStart();
        }

        protected virtual void Bind()
        {
            // bind self to DI or DC
        }

        protected virtual void Resolve()
        {
            // resolve dependencies
        }
        
        protected virtual void OnAwake()
        {
            // code to execute on Awake
        }

        protected virtual void OnStart()
        {
            // code to execute on Start
        }
    }
}