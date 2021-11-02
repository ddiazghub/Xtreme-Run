/// <summary>
///     This class generates states for the main class.
/// </summary>
public class PlayerStateFactory {

    /// <summary>
    ///     Creates a new persistent state from the given enum value.
    /// </summary>
    /// <param name="state">The value of the new state.</param>
    /// <returns>A new instance of a player persistent state.</returns>
    public PersistentState New(PlayerPersistentState state)
    {
        PersistentState newState = null;

        switch (state)
        {
            case PlayerPersistentState.ON_GROUND:
                newState = new OnGroundState();
                break;

            case PlayerPersistentState.ON_AIR:
                newState = new OnAirState();
                break;
        }

        return newState;
    }

    /// <summary>
    ///     Creates a new player primary action from the given enum value.
    /// </summary>
    /// <param name="state">The value of the new primary action.</param>
    /// <returns>A new instance of a player primary action.</returns>
    public MainAction New(PlayerMainAction state)
    {
        MainAction newState = null;

        switch (state)
        {
            case PlayerMainAction.JUMP:
                newState = new Jump();
                break;

            case PlayerMainAction.JETPACK:
                newState = new Jetpack();
                break;

            case PlayerMainAction.GLIDE:
                newState = new Glide();
                break;
                
            case PlayerMainAction.TELEPORT:
                newState = new Teleport();
                break;
        }

        return newState;
    }

    /// <summary>
    ///     Creates a new secondary action from the given enum value.
    /// </summary>
    /// <param name="state">The value of the new secondary action.</param>
    /// <returns>A new instance of a player secondary action.</returns>
    public SecondaryAction New(PlayerSecondaryAction state)
    {
        SecondaryAction newState = null;

        switch (state)
        {
            case PlayerSecondaryAction.FASTFALL_AND_ROLL:
                newState = new FastFallAndRoll();
                break;

            case PlayerSecondaryAction.SWITCH_GRAVITY:
                newState = new SwitchGravity();
                break;

            case PlayerSecondaryAction.TELEPORT_AND_SWITCH_GRAVITY:
                newState = new TeleportAndSwitchGravity();
                break;
                
            case PlayerSecondaryAction.SPAWN_PLATFORMS:
                newState = new SpawnPlatforms();
                break;
        }

        return newState;
    }
}