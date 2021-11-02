using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
///     Class that contains the information of a player profile.
/// </summary>
public class ProfileInfo {

    /// <summary>
    ///     The profile id. Can be any number between 0 and 5.
    /// </summary>
    public int ID {
        get;
        set;
    }

    /// <summary>
    ///     The profile name.
    /// </summary>
    public string Name {
        get;
        set;
    }

    /// <summary>
    ///     The profile's avatar.
    /// </summary>
    public Avatar Avatar
    {
        get;
    }

    /// <summary>
    ///     The number of points that the profile currently owns.
    /// </summary>
    public UInt32 Points
    {
        get;
        set;
    }

    /// <summary>
    ///     An array of booleans in which each index corresponds to a store item's id.
    ///     Each element is true if the item was bought from the store and is currently owned and false otherwise.
    /// </summary>
    public bool[] OwnedItems
    {
        get;
    }

    /// <summary>
    ///     An array of ints that contains the maximum percent of progress the player has reached in each level.
    ///     Element 0 is level 1, element 1 is level 2 and element 2 is level 3.
    /// </summary>
    public int[] LevelProgress
    {
        get;
    }

    /// <summary>
    ///     The level the player is currently in, that being the first level the player hasn't completed or level 3 if all have been completed.
    /// </summary>
    public int CurrentLevel
    {
        get
        {
            if (this.LevelProgress[0] != 100 || this.LevelProgress[0] == 100 && !this.OwnedItems[15])
                return 0;
            
            if (this.LevelProgress[1] != 100 || !this.OwnedItems[16] && this.LevelProgress[1] == 100)
                return 1;

            return 2;
        }
    }

    /// <summary>
    ///     A list of the levels the player has completed.
    /// </summary>
    public List<int> CompletedLevels
    {
        get
        {
            List<int> completed = new List<int>();

            for (int i = 0; i < this.LevelProgress.Length; i++)
            {
                if (this.LevelProgress[i] >= 100)
                {
                    this.LevelProgress[i] = 100;
                    completed.Add(i);
                }
            }

            return completed;
        }
    }

    /// <summary>
    ///     The number of items the player has bought from the store.
    /// </summary>
    public int NumberOfOwnedItems
    {
        get
        {
            int owned = 0;

            for (int i = 0; i < this.OwnedItems.Length; i++)
            {
                if (this.OwnedItems[i])
                    owned++;
            }

            return owned;
        }
    }

    /// <summary>
    ///     Loads an existing profile from a file.
    ///     If the profile doesn't exist or the save file is corrupted, returns a profile with an id of 6.
    /// </summary>
    /// <param name="saveFilePath">Path to the file where the profile is saved.</param>
    public ProfileInfo(string saveFilePath)
    {
        this.ID = Convert.ToInt32(Path.GetFileNameWithoutExtension(saveFilePath));

        if (!Profile.Exists(this.ID))
        {
            this.ID = 6;
            return;
        }

        byte[] buffer = File.ReadAllBytes(saveFilePath);

        if (buffer.Length != SaveFileInfo.FILE_SIZE)
        {
            Profile.Delete(this.ID);
            this.ID = 6;
            return;
        }

        this.Name = Encoding.ASCII.GetString(buffer, SaveFileInfo.PROFILE_NAME, SaveFileInfo.PROFILE_NAME_MAX_SIZE).Replace("\0", "");
        
        this.Avatar = new Avatar(
            Convert.ToBoolean(buffer[SaveFileInfo.AVATAR_GENDER]),
            buffer[SaveFileInfo.AVATAR_COLOR_SKIN],
            buffer[SaveFileInfo.AVATAR_COLOR_TOP],
            buffer[SaveFileInfo.AVATAR_COLOR_BOTTOM]
        );

        this.Points = BitConverter.ToUInt32(buffer, SaveFileInfo.POINTS);
        byte[] ownedItemsBuffer = new byte[SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH];
        Array.Copy(buffer, SaveFileInfo.OWNED_ITEMS, ownedItemsBuffer, 0, SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH);
        this.OwnedItems = new bool[SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH];

        for (int i = 0; i < SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH; i++)
            this.OwnedItems[i] = Convert.ToBoolean(ownedItemsBuffer[i]);

        this.LevelProgress = new int[] {
            buffer[SaveFileInfo.LEVEL1_PROGRESS],
            buffer[SaveFileInfo.LEVEL2_PROGRESS],
            buffer[SaveFileInfo.LEVEL3_PROGRESS]
        };
    }

    /// <summary>
    ///     Writes the profile data to an array of bytes for saving in a file.
    /// </summary>
    /// <returns>A byte buffer containing the profile data</returns>
    public byte[] ToBytes()
    {
        byte[] buffer = new byte[SaveFileInfo.FILE_SIZE];

        Encoding.ASCII.GetBytes(this.Name.PadRight(SaveFileInfo.PROFILE_NAME_MAX_SIZE)).CopyTo(buffer, SaveFileInfo.PROFILE_NAME);
        buffer[SaveFileInfo.AVATAR_GENDER] = Convert.ToByte(this.Avatar.Male);
        buffer[SaveFileInfo.AVATAR_COLOR_SKIN] = (byte) this.Avatar.SkinColor;
        buffer[SaveFileInfo.AVATAR_COLOR_TOP] = (byte) this.Avatar.TopColor;
        buffer[SaveFileInfo.AVATAR_COLOR_BOTTOM] = (byte) this.Avatar.BottomColor;

        BitConverter.GetBytes(this.Points).CopyTo(buffer, SaveFileInfo.POINTS);

        for (int i = 0; i < this.OwnedItems.Length; i++)
        {
            if (this.OwnedItems[i])
            {
                buffer[SaveFileInfo.OWNED_ITEMS + i] = Convert.ToByte(true);
            }
        }

        for (int i = 0; i < this.LevelProgress.Length; i++)
        {
            buffer[SaveFileInfo.LEVEL1_PROGRESS + i] = (byte) this.LevelProgress[0];
        }

        return buffer;
    }

    /// <summary>
    ///     Checks if the level is unlocked, that is if the level's key has been bought from the store.
    /// </summary>
    /// <param name="level">The level's number.</param>
    /// <returns>True if the level is unlocked, else false.</returns>
    public bool LevelIsUnlocked(int level)
    {
        switch (level)
        {
            case 1:
                return true;
            
            case 2:
                return this.OwnedItems[15];

            case 3:
                return this.OwnedItems[16];
            
            default:
                return false;
        }
    }
}