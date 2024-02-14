using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace GenericStatemachine {
    public delegate bool Condition<T>(T context);
}