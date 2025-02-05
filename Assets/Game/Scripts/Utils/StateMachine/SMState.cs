public abstract class SMState
{

    protected StateMachine stateMachine;
    
    public SMState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    
    public virtual void Enter() {}
    public virtual void Exit() {}
    
    public virtual void Update() {}
    public virtual void FixedUpdate() {}
    public virtual void AnimationTriggered() {}
    
}