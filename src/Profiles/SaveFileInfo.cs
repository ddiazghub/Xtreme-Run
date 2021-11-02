/// <summary>
///     Static class that contains some constants about save file structure.
/// </summary>
public static class SaveFileInfo
{
    // Buffer lenghts in bytes
    public static readonly int FILE_SIZE = 48;
    public static readonly int PROFILE_NAME_MAX_SIZE = 20;
    public static readonly int OWNED_ITEMS_BUFFER_LENGTH = 17;

    // Profile field offsets
    public static readonly int PROFILE_NAME = 0x00;
    public static readonly int AVATAR_GENDER = 0x14;
    public static readonly int AVATAR_COLOR_SKIN = 0x15;
    public static readonly int AVATAR_COLOR_TOP = 0x16;
    public static readonly int AVATAR_COLOR_BOTTOM = 0x17;
    public static readonly int POINTS = 0x18;
    public static readonly int OWNED_ITEMS = 0x1C;
    public static readonly int LEVEL1_PROGRESS = 0x2D;
    public static readonly int LEVEL2_PROGRESS = 0x2E;
    public static readonly int LEVEL3_PROGRESS = 0x2F;
}