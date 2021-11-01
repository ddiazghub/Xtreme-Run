using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ProfileInfo {
    public int ID {
        get;
        set;
    }

    public string Name {
        get;
        set;
    }

    public Avatar Avatar
    {
        get;
    }

    public UInt32 Points
    {
        get;
        set;
    }

    public bool[] OwnedItems
    {
        get;
    }

    public int[] LevelProgress
    {
        get;
    }

    public int CurrentLevel
    {
        get
        {
            for (int i = 0; i < 2; i++)
            {
                if (this.LevelProgress[i] != 100)
                {
                    return i;
                }
            }

            return 2;
        }
    }

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

    public ProfileInfo(string saveFilePath)
    {
        this.ID = Convert.ToInt32(Path.GetFileNameWithoutExtension(saveFilePath));
        byte[] buffer = File.ReadAllBytes(saveFilePath);

        if (buffer.Length != SaveFileInfo.SIZE)
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

    public byte[] ToBytes()
    {
        byte[] buffer = new byte[SaveFileInfo.SIZE];

        Encoding.ASCII.GetBytes(this.Name.PadRight(SaveFileInfo.PROFILE_NAME_MAX_SIZE)).CopyTo(buffer, SaveFileInfo.PROFILE_NAME);
        buffer[SaveFileInfo.AVATAR_GENDER] = Convert.ToByte(this.Avatar.male);
        buffer[SaveFileInfo.AVATAR_COLOR_SKIN] = (byte) this.Avatar.skinColor;
        buffer[SaveFileInfo.AVATAR_COLOR_TOP] = (byte) this.Avatar.topColor;
        buffer[SaveFileInfo.AVATAR_COLOR_BOTTOM] = (byte) this.Avatar.bottomColor;

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