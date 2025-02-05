public class CarryState : CharacterMovementState
{
    
    public CarryState(Character character, StateMachine stateMachine, float speed, float stoppingDistance)
        : base(character, stateMachine, speed, stoppingDistance, true) {}

    public override void Update()
    {
        if (character.HasReachedDestination())
        {
            if (character is Worker worker)
            {
                worker.OnReachedShelf();
            }
            else
            {
                stateMachine.SetState<IdleState>();
            }
        }
    }
}