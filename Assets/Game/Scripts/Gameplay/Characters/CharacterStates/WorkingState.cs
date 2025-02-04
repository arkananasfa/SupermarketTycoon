using System;

public class WorkingState : CharacterState
{
    private Action _onWorkCompleted;

    public WorkingState(Character character, StateMachine stateMachine, Action onWorkCompleted) 
        : base(character, stateMachine)
    {
        _onWorkCompleted = onWorkCompleted;
    }

    public override void Enter()
    {
        character.SetAnimatorTrigger("Work");
    }

    public override void AnimationTriggered()
    {
        // Trigger work completion callback
        _onWorkCompleted?.Invoke();
    }
}