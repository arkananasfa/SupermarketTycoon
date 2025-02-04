using UnityEngine;

public class CharacterIdleState : CharacterState
{
    
    public CharacterIdleState(Character @char, StateMachine stateMachine) : base(@char, stateMachine)
    {
        @char.targetPosition.OnValueChanged += SetToMoveState;
    }

    private void SetToMoveState(Vector3 value)
    {
        StateMachine.SetState<CharacterMoveState>();
    }
    
}