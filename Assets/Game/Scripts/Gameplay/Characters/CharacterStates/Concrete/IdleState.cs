public class IdleState : CharacterState
{
    public IdleState(Character character, StateMachine stateMachine) : base(character, stateMachine) {}

    public override void Enter()
    {
        character.SetAnimatorBool("IsMoving", false);
        character.SetAnimatorBool("IsCarrying", false);
    }

    public override void Update()
    {
        // Transition to MoveState or CarryState based on carriedObject
        if (character.carriedObject.Value != null)
        {
            stateMachine.SetState<CarryState>();
        }
        else if (character.targetPosition.Value != character.transform.position)
        {
            stateMachine.SetState<MoveState>();
        }
    }
}