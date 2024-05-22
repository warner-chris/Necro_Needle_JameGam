using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateRunner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private List<State<T>> _states;
        private readonly Dictionary<Type, State<T>> _stateByType = new Dictionary<Type, State<T>>();
        private State<T> _activeState;

        [SerializeField] private List<SubState<T>> _actions;
        private readonly Dictionary<Type, SubState<T>> _actionByType = new Dictionary<Type, SubState<T>>();
        private SubState<T> _activeAction;

        protected virtual void Awake()
        {
            _states.ForEach(s => _stateByType.Add(s.GetType(), s));
            _actions.ForEach(a => _actionByType.Add(a.GetType(), a));
            SetState(_states[0].GetType());

        }

        private void Update()
        {
            _activeState.Update();
            _activeState.ChangeState();
        }

        private void FixedUpdate()
        {
            _activeState.FixedUpdate();
        }


        public SubState<T> GetActiveAction()
        {
            return _activeAction;
        }


        public void SetState(Type newStateType)
        {
            if (_activeState != null)
            {
                _activeState.Exit();
            }

            _activeState = _stateByType[newStateType];
            _activeState.Init(GetComponent<T>());
        }

        public void SetAction(Type newActionType)
        {
            if (_activeAction != null)
            {
                _activeAction.Exit();
            }

            _activeAction = _actionByType[newActionType];
            _activeAction.Init(GetComponent<T>());
        }
    }
}
