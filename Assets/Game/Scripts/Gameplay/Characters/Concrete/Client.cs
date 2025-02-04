public class Client : Character
{
    public Vector3 ExitPosition;

    public override void Start()
    {
        base.Start();

        // Subscribe to carriedObject changes
        carriedObject.OnValueChanged += OnCarriedObjectChanged;
    }

    private void OnCarriedObjectChanged(GameObject newCarriedObject)
    {
        if (newCarriedObject == null)
        {
            // Notify the CashRegister when the client arrives with an item
            stateMachine.SetState<IdleState>();
        }
    }

    public void OnWorkCompleted()
    {
        // Move to the exit after the cashier finishes working
        targetPosition.Value = ExitPosition;
        stateMachine.SetState<MoveState>();
    }

    protected override void Update()
    {
        base.Update();

        // Disappear when reaching the exit
        if (stateMachine.CurrentState is MoveState && HasReachedDestination())
        {
            Destroy(gameObject);
        }
    }
}