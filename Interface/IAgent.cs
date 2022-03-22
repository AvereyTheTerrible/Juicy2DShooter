using UnityEngine;
using UnityEngine.Events;

public interface IAgent
{
    UnityEvent OnDie { get; set; }
    UnityEvent OnGetHit { get; set; }
}