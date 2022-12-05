using System.Collections.Generic;
enum PlayerStates {
    idle,
    run,
    grounded,
    crouch,
    drag,
    jump,
    dash,
    slide,
    climb,
    hang,
    inAir,
    fall,
    standing,
    busy,
    swing,
    swingJump
}

public class PlayerStateFactory
{
    PlayerController _context;
    Dictionary<PlayerStates, PlayerBaseState> _states = new Dictionary<PlayerStates, PlayerBaseState>();
    public PlayerStateFactory(PlayerController currentContext)
    {
        _context = currentContext;
        _states[PlayerStates.idle] = new PlayerIdleState(_context, this);
        _states[PlayerStates.run] = new PlayerRunningState(_context, this);
        _states[PlayerStates.grounded] = new PlayerGroundedState(_context, this);
        _states[PlayerStates.crouch] = new PlayerCrouchState(_context, this);
        _states[PlayerStates.drag] = new PlayerDragState(_context, this);
        _states[PlayerStates.jump] = new PlayerJumpingState(_context, this);
        _states[PlayerStates.dash] = new PlayerDashState(_context, this);
        _states[PlayerStates.slide] = new PlayerSlideState(_context, this);
        _states[PlayerStates.climb] = new PlayerClimbState(_context, this);
        _states[PlayerStates.hang] = new PlayerHangState(_context, this);
        _states[PlayerStates.inAir] = new PlayerInAirState(_context, this);
        _states[PlayerStates.fall] = new PlayerFallState(_context, this);
        _states[PlayerStates.standing] = new PlayerStandingState(_context, this);
        _states[PlayerStates.busy] = new PlayerBusyState(_context,this);
        _states[PlayerStates.swing] = new PlayerSwingState(_context, this);
        _states[PlayerStates.swingJump] = new PlayerSwingJumpState(_context, this);
    }

    public PlayerBaseState Idle()
    {
        return _states[PlayerStates.idle];
    }
    public PlayerBaseState Run()
    {
        return _states[PlayerStates.run];
    }
    public PlayerBaseState Jump()
    {
        return _states[PlayerStates.jump];
    }public PlayerBaseState Dash()
    {
        return _states[PlayerStates.dash];
    }
    public PlayerBaseState Grounded()
    {
        return _states[PlayerStates.grounded];
    }
    public PlayerBaseState Crouch()
    {
        return _states[PlayerStates.crouch];
    }
    public PlayerBaseState Drag()
    {
        return _states[PlayerStates.drag];
    }
    public PlayerBaseState Slide()
    {
        return _states[PlayerStates.slide];
    }
    public PlayerBaseState Climb()
    {
        return _states[PlayerStates.climb];
    }
    public PlayerBaseState Hang()
    {
        return _states[PlayerStates.hang];
    }
    public PlayerBaseState InAir()
    {
        return _states[PlayerStates.inAir];
    }
    public PlayerBaseState Fall()
    {
        return _states[PlayerStates.fall];
    }
    public PlayerBaseState Standing()
    {
        return _states[PlayerStates.standing];
    }
    public PlayerBaseState Busy()
    {
        return _states[PlayerStates.busy];
    }
    public PlayerBaseState Swing()
    {
        return _states[PlayerStates.swing];
    }
    public PlayerBaseState SwingJump()
    {
        return _states[PlayerStates.swingJump];
    }
}
