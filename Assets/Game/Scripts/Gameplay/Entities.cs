public class Cashier : Character
{
    public CashRegister AssignedCashRegister;

    protected override void Start()
    {
        base.Start();

        // Add states with specific parameters
        _stateMachine.AddState(new MoveState(this, _stateMachine, 3.5f, 0.1f));
        _stateMachine.AddState(new CarryState(this, _stateMachine, 2.5f, 0.1f));
        _stateMachine.AddState(new WorkingState(this, _stateMachine));

        // Subscribe to work completion event
        OnWorkCompleted += OnWorkCompletedHandler;

        // Subscribe to the CashRegister's CurrentClient
        if (AssignedCashRegister != null)
        {
            AssignedCashRegister.CurrentClient.OnValueChanged += OnClientArrived;
        }
    }

    private void OnClientArrived(Client client)
    {
        if (client != null)
        {
            // Start working when a client arrives
            stateMachine.SetState<WorkingState>();
        }
    }

    private void OnWorkCompletedHandler()
    {
        // Notify the client that the work is done
        if (AssignedCashRegister.CurrentClient.Value != null)
        {
            AssignedCashRegister.CurrentClient.Value.OnWorkCompleted();
        }

        // Return to idle state
        stateMachine.SetState<IdleState>();
    }
}