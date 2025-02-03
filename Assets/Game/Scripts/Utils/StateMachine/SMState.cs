public abstract class SMState
{

    protected StateMachine StateMachine;
    
    public SMState(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }
    
    public virtual void Enter() {}
    public virtual void Exit() {}
    
    public virtual void Update() {}
    public virtual void FixedUpdate() {}
    public virtual void AnimationTriggered() {}
    
}