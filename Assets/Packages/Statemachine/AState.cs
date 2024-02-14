using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace GenericStatemachine {
    public interface IState<T> {
        public void OnEnter(T context);
        public void OnUpdate(T context);
        public void OnExit(T context);
    }
}