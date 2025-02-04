using UnityEngine;

public class Character : MonoBehaviour
{
    public ObservableValue<Vector3> targetPosition;
    public ObservableValue<GameObject> carriedObject;
    public ObservableValue<bool> isWorking;
    
    private StateMachine _stateMachine;
    
    public void SetStateMachine(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }    
    
}