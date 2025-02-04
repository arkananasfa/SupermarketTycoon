using UnityEngine;

public class CharacterMoveState : CharacterState
{
    
    public CharacterMoveState(Character @char, StateMachine stateMachine) : base(@char, stateMachine)
    {
        
    }

    private void SetToCarryState(Vector3 value)
    {
        StateMachine.SetState<CharacterCarryState>();
    }
    
}