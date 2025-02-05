using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public ObservableValue<Vector3> targetPosition = new ObservableValue<Vector3>();
    public ObservableValue<GameObject> carriedObject = new ObservableValue<GameObject>();

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    protected StateMachine stateMachine;

    protected virtual void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        stateMachine = new StateMachine();
        stateMachine.AddState(new IdleState(this, stateMachine));
        stateMachine.AddState(new MoveState(this, stateMachine, 3.5f, 0.1f)); // Example speed and stopping distance
        stateMachine.AddState(new CarryState(this, stateMachine, 2.5f, 0.1f)); // Slower speed when carrying
        stateMachine.AddState(new WorkingState(this, stateMachine));

        stateMachine.SetState<IdleState>();
    }

    private void SetTarget(GameObject target)
    {
        targetPosition.Value = target.transform.position;
        _navMeshAgent.SetDestination(targetPosition.Value);
    }

    protected virtual void Update()
    {
        stateMachine.Update();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void AnimationTriggered()
    {
        stateMachine.AnimationTriggered();
    }

    public bool HasReachedDestination()
    {
        return _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;
    }

    public void SetNavMeshAgentSpeed(float speed)
    {
        _navMeshAgent.speed = speed;
    }

    public void SetNavMeshAgentStoppingDistance(float distance)
    {
        _navMeshAgent.stoppingDistance = distance;
    }

    public void SetAnimatorBool(string parameter, bool value)
    {
        _animator.SetBool(parameter, value);
    }

    public void SetAnimatorTrigger(string parameter)
    {
        _animator.SetTrigger(parameter);
    }
}