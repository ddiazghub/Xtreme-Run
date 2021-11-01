using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Profile {
    private static Profile session;
    public static readonly string SAVES_DIRECTORY = Path.Combine(Environment.GetEnvironmentVariable("HOMEPATH"), "XtremeRun", "Saves");

    public ProfileInfo Info
    {
        get;
        private set;
    }

    public void Load(int id)
    {
        this.Info = new ProfileInfo(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
    }

    public void Save()
    {
        File.WriteAllBytes(Path.Combine(SAVES_DIRECTORY, this.Info.ID.ToString() + ".sav"), this.Info.ToBytes());
    }

    public void LogOut()
    {
        this.Info = null;
    }

    public static Profile CurrentSession
    {
        get
        {
            if (session == null)
            {
                session = new Profile();
            }

            return session;
        }
    }

    public static ProfileInfo Get(int id)
    {
        ProfileInfo profile = new ProfileInfo(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
        
        if (profile.ID == 6)
            return null;
        else
            return profile;
    }

    public static void Create(int id, string name)
    {
        if (!Directory.Exists(SAVES_DIRECTORY))
        {
            Directory.CreateDirectory(SAVES_DIRECTORY);
        }

        byte[] buffer = new byte[SaveFileInfo.SIZE];

        Encoding.ASCII.GetBytes(name).CopyTo(buffer, SaveFileInfo.PROFILE_NAME);
        buffer[SaveFileInfo.AVATAR_GENDER] = 1;
        buffer[SaveFileInfo.AVATAR_COLOR_SKIN] = 15;
        buffer[SaveFileInfo.AVATAR_COLOR_TOP] = 15;
        buffer[SaveFileInfo.AVATAR_COLOR_BOTTOM] = 15;

        FileStream file = File.Create(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
        file.Write(buffer, 0, SaveFileInfo.SIZE);
        file.Close();
    }

    public static void Delete(int id)
    {
        File.Delete(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
    }

    public static bool Exists(int id)
    {
        return File.Exists(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
    }

    public static bool NameIsAvailable(string name)
    {
        for (int i = 0; i < 6; i++)
        {   
            if (Profile.Exists(i))
            {
                ProfileInfo profile = Profile.Get(i);
                
                if (profile != null && profile.Name.Equals(name))
                    return false;
            }
        }

        return true;
    }
}