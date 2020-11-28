using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Popup<T> : MonoBehaviour where T : ScriptableObject
{
    public abstract void Display(T displayayyyy);
}
