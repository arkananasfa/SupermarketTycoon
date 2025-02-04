public class CarryState : CharacterState
{
    private float _speed;
    private float _stoppingDistance;

    public CarryState(Character character, StateMachine stateMachine, float speed, float stoppingDistance) 
        : base(character, stateMachine)
    {
        _speed = speed;
        _stoppingDistance = stoppingDistance;
    }

    public override void Enter()
    {
        character.SetAnimatorBool("IsMoving", true);
        character.SetAnimatorBool("IsCarrying", true);

        // Set NavMeshAgent parameters
        character.SetNavMeshAgentSpeed(_speed);
        character.SetNavMeshAgentStoppingDistance(_stoppingDistance);

        // Set destination
        character.SetDestination(character.targetPosition.Value);
    }

    public override void Update()
    {
        if (character.HasReachedDestination())
        {
            stateMachine.SetState<IdleState>();
        }
        else if (character.carriedObject.Value == null)
        {
            stateMachine.SetState<MoveState>();
        }
    }
}