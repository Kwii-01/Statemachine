using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace GenericStatemachine {
    public class Statemachine<T> {
        private IState<T> _currentState;
        private List<Transition<T>> _transitions;
        private Dictionary<IState<T>, List<Transition<T>>> _focusedTransitions;

        public Statemachine(IState<T> initialState) {
            this._currentState = initialState;
        }

        public void AddTransition(Transition<T> transition) {
            this._transitions.Add(transition);
        }

        public void AddTransition(IState<T> state, Transition<T> transition) {
            if (this._focusedTransitions.ContainsKey(state) == false) {
                this._focusedTransitions[state] = new List<Transition<T>>();
            }
            this._focusedTransitions[state].Add(transition);
        }

        public void ChangeState(IState<T> state, T context) {
            if (state == this._currentState) {
                return;
            }
            this._currentState.OnExit(context);
            this._currentState = state;
            this._currentState.OnEnter(context);
        }

        public void Update(T context) {
            if (this.CheckTransitions(this._transitions, context) == false && this._focusedTransitions.TryGetValue(this._currentState, out List<Transition<T>> transitions)) {
                this.CheckTransitions(transitions, context);
            }
            this._currentState.OnUpdate(context);
        }

        private bool CheckTransitions(List<Transition<T>> transitions, T context) {
            foreach (Transition<T> transition in transitions) {
                if (transition.Condition(context)) {
                    this.ChangeState(transition.State, context);
                    return true;
                }
            }
            return false;
        }
    }
}