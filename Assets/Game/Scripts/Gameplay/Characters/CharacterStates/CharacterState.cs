public class CharacterState : SMState
{

    private Character _character;
    
    public CharacterState(Character @char, StateMachine stateMachine) : base(stateMachine)
    {
        _character = @char;
    }
    
}