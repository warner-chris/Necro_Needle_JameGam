using UnityEngine;

namespace StateMachine
{
    public abstract class SubState<T> : ScriptableObject where T : MonoBehaviour
    {
        protected T _runner;

        public virtual void Init(T parent)
        {
            _runner = parent;
        }


        public abstract void PlayAction();

        public abstract void ChangeAction();

        public abstract void Exit();
    }
}
