using UnityEngine;

public class Client : Character
{
    private GoodsType _desiredGoodsType;
    private Shelf _targetShelf;
    private CashRegister _targetCashRegister;
    private ClientsSpawner _spawner;
    private Transform _exitPoint;
    
    [SerializeField] 
    private Transform carryObjectParent;

    private bool _isRunningAway = false;

    protected void Init(ClientsSpawner spawner, Transform exitPoint, GoodsType goodsType, Shelf shelf, CashRegister targetCashRegister)
    {
        base.Start();

        _spawner = spawner;
        _desiredGoodsType = goodsType;
        _targetShelf = shelf;
        _targetCashRegister = targetCashRegister;
        _exitPoint = exitPoint;
    }

    public void StopMove()
    {
        if (!_isRunningAway)
            TakeGoods();
        else
            _spawner.Kill(this);
    }

    public void TakeGoods()
    {
        _isRunningAway = true;
        if (_targetShelf != null && _targetShelf.TakeGood())
        {
            carriedObject.Value = Instantiate(_targetShelf.goodGameObject, carryObjectParent);
            MoveToCashRegister();
        }
    }

    private void MoveToCashRegister()
    {
        targetPosition.Value = _targetCashRegister.transform.position;
        stateMachine.SetState<CarryState>();
    }

    public void OnTransactionComplete()
    {
        targetPosition.Value = _exitPoint.position;
        stateMachine.SetState<MoveState>();
    }
    
}