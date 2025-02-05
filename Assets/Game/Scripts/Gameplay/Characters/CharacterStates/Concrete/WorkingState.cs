using System;

public class WorkingState : CharacterState
{
    
    private readonly Action onWorkEnded;

    public WorkingState(Character character, StateMachine stateMachine, Action onWorkEnded = null) : base(character,
        stateMachine)
    {
        this.onWorkEnded += onWorkEnded;
    }

    public override void Enter()
    {
        character.SetAnimatorTrigger("Work");
    }

    public override void AnimationTriggered()
    {
        onWorkEnded?.Invoke();
    }
    
}