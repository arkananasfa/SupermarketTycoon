public class CharacterMovementState : CharacterState
{
    private readonly bool _isCarrying;
    private readonly float _speed;
    private readonly float _stoppingDistance;

    public CharacterMovementState(Character character, StateMachine stateMachine, float speed, float stoppingDistance,
        bool isCarrying) : base(character, stateMachine)
    {
        _speed = speed;
        _stoppingDistance = stoppingDistance;
        _isCarrying = isCarrying;
    }

    public override void Enter()
    {
        character.SetAnimatorBool("IsMoving", true);
        character.SetAnimatorBool("IsCarrying", _isCarrying);
        
        character.SetNavMeshAgentSpeed(_speed);
        character.SetNavMeshAgentStoppingDistance(_stoppingDistance);
    }
}