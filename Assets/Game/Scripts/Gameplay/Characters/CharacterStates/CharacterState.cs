public class CharacterState : SMState
{

    protected Character character;
    
    public CharacterState(Character @char, StateMachine stateMachine) : base(stateMachine)
    {
        _character = @char;
    }
    
}