public class MoveState : CharacterMovementState
{
    private float _speed;
    private float _stoppingDistance;

    public MoveState(Character character, StateMachine stateMachine, float speed, float stoppingDistance)
        : base(character, stateMachine, speed, stoppingDistance, false) {}

    public override void Update()
    {
        if (character.HasReachedDestination())
        {
            if (character is Worker worker)
            {
                if (worker.carriedObject.Value == null)
                {
                    worker.OnReachedFreezer();
                }
                else
                {
                    worker.OnReachedShelf();
                }
            }
            else if (character is Client client)
            {
                client.StopMove();
            }
            else
            {
                stateMachine.SetState<IdleState>();
            }
        }
    }
}