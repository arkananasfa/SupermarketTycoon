using UnityEngine;

public class Worker : Character
{
    public GoodsTypeSection AssignedSection;

    private Shelf _shelf;

    protected override void Start()
    {
        base.Start();
        AssignSection(AssignedSection);
    }

    public void AssignSection(GoodsTypeSection section)
    {
        AssignedSection = section;
        section.AssignWorker(this);
    }

    public void RestockShelf(Shelf shelf)
    {
        _shelf = shelf;
        targetPosition.Value = AssignedSection.FreezerTransform.position;
        stateMachine.SetState<MoveState>();
    }

    public void OnReachedFreezer()
    {
        targetPosition.Value = _shelf.transform.position;
        stateMachine.SetState<CarryState>();
    }

    public void OnReachedShelf()
    {
        // Restock the shelf
        _shelf.Restock();

        if (AssignedSection.MissingGoodShelf.Value == null)
            stateMachine.SetState<IdleState>();
    }
}