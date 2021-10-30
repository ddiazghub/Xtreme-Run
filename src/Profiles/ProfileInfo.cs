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

    public Dictionary<int, bool> OwnedItems
    {
        get;
    }

    public Dictionary<int, int> LevelProgress
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

        this.Name = Encoding.ASCII.GetString(buffer, SaveFileInfo.PROFILE_NAME, SaveFileInfo.PROFILE_NAME_MAX_SIZE).TrimEnd();
        
        this.Avatar = new Avatar(
            Convert.ToBoolean(buffer[SaveFileInfo.AVATAR_GENDER]),
            buffer[SaveFileInfo.AVATAR_COLOR_SKIN],
            buffer[SaveFileInfo.AVATAR_COLOR_TOP],
            buffer[SaveFileInfo.AVATAR_COLOR_BOTTOM]
        );

        this.Points = BitConverter.ToUInt32(buffer, SaveFileInfo.POINTS);
        this.OwnedItems = new Dictionary<int, bool>();
        byte[] ownedItemsBuffer = new byte[SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH];
        Array.Copy(buffer, SaveFileInfo.OWNED_ITEMS, ownedItemsBuffer, 0, SaveFileInfo.OWNED_ITEMS_BUFFER_LENGTH);

        for (int i = 0; i < ownedItemsBuffer.Length; i++)
        {
            this.OwnedItems.Add(i, false);

            if (Convert.ToBoolean(ownedItemsBuffer[i]))
            {
                this.OwnedItems[i] = true;
            }
        }

        this.LevelProgress = new Dictionary<int, int>();
        this.LevelProgress.Add(0, buffer[SaveFileInfo.LEVEL1_PROGRESS]);
        this.LevelProgress.Add(1, buffer[SaveFileInfo.LEVEL2_PROGRESS]);
        this.LevelProgress.Add(2, buffer[SaveFileInfo.LEVEL3_PROGRESS]);
    }

    public byte[] ToBytes()
    {
        byte[] buffer = new byte[SaveFileInfo.SIZE];

        Encoding.ASCII.GetBytes(this.Name.PadRight(20)).CopyTo(buffer, SaveFileInfo.PROFILE_NAME);
        buffer[SaveFileInfo.AVATAR_GENDER] = Convert.ToByte(this.Avatar.male);
        buffer[SaveFileInfo.AVATAR_COLOR_SKIN] = (byte) this.Avatar.skinColor;
        buffer[SaveFileInfo.AVATAR_COLOR_TOP] = (byte) this.Avatar.topColor;
        buffer[SaveFileInfo.AVATAR_COLOR_BOTTOM] = (byte) this.Avatar.bottomColor;

        BitConverter.GetBytes(this.Points).CopyTo(buffer, SaveFileInfo.POINTS);

        foreach (int id in this.OwnedItems.Keys)
        {
            if (this.OwnedItems[id])
            {
                buffer[SaveFileInfo.OWNED_ITEMS + id] = Convert.ToByte(true);
            }
        }

        buffer[SaveFileInfo.LEVEL1_PROGRESS] = (byte) this.LevelProgress[0];
        buffer[SaveFileInfo.LEVEL2_PROGRESS] = (byte) this.LevelProgress[1];
        buffer[SaveFileInfo.LEVEL3_PROGRESS] = (byte) this.LevelProgress[2];

        return buffer;
    }
}