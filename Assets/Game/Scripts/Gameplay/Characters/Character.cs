using UnityEngine;

public class Character : MonoBehaviour
{

    private StateMachine _stateMachine;
    
    public void Init(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    
    
}