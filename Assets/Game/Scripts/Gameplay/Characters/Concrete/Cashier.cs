public class Cashier : Character
{
    public CashRegister AssignedCashRegister;

    protected override void Start()
    {
        base.Start();

        // Add states with specific parameters
        stateMachine.AddState(new MoveState(this, stateMachine, 3.5f, 0.1f));
        stateMachine.AddState(new CarryState(this, stateMachine, 2.5f, 0.1f));
        stateMachine.AddState(new WorkingState(this, stateMachine, OnWorkCompletedHandler));

        // Subscribe to the CashRegister's CurrentClient
        if (AssignedCashRegister != null)
        {
            AssignedCashRegister.CurrentClient.OnValueChanged += OnClientArrived;
        }
    }

    private void OnClientArrived(Client client)
    {
        if (client != null)
            stateMachine.SetState<WorkingState>();
    }

    private void OnWorkCompletedHandler()
    {
        if (AssignedCashRegister.CurrentClient.Value != null)
            AssignedCashRegister.CompleteTransaction();

        if (AssignedCashRegister.CurrentClient.Value == null)
            stateMachine.SetState<IdleState>();
    }
}