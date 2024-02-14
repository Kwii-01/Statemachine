using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace GenericStatemachine {
    [Serializable]
    public struct Transition<T> {
        public Condition<T> Condition;
        public IState<T> State;
    }
}