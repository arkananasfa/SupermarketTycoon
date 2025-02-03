public class CharacterIdleState : CharacterState
{

    private Character _character;
    
    public CharacterState(Character @char, StateMachine stateMachine) : base(stateMachine)
    {
        _character = @char;
    }
    
}