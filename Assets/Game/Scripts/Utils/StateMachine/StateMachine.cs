using System;
using System.Collections.Generic;

public class StateMachine
{
    
    public SMState CurrentState { get; private set; }
    public Dictionary<Type, SMState> States { get; private set; }

    public void AddState<T>(T state) where T : SMState
    {
        States.Add(typeof(T), state);
    }

    public void SetState<T>()
    {
        if (CurrentState is T)
            return;

        if (States.TryGetValue(typeof(T), out SMState state))
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }

    public void AnimationTriggered()
    {
        CurrentState?.AnimationTriggered();
    }
    
}