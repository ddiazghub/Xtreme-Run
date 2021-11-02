using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
///     Class that contains the the currently active profile.
/// </summary>
public class Profile {

    /// <summary>
    ///     Singleton instance.
    /// </summary>
    private static Profile session;

    /// <summary>
    ///     Directory where the profiles will be stored.
    /// </summary>
    public static readonly string SAVES_DIRECTORY = Path.Combine(Environment.GetEnvironmentVariable("HOMEPATH"), "XtremeRun", "Saves");
    
    /// <summary>
    ///     Maximum number of profiles that can be saved.
    /// </summary>
    public static readonly int MAX_NUMBER_OF_SAVES = 6;

    /// <summary>
    ///     Data of the active profile.
    /// </summary>
    public ProfileInfo Info
    {
        get;
        private set;
    }

    /// <summary>
    ///     Loads a profile with the given id and makes it the active profile.
    /// </summary>
    /// <param name="id">The id of the profile to load.</param>
    public void Load(int id)
    {
        this.Info = new ProfileInfo(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
    }

    /// <summary>
    ///     Saves the the currently active profile by writing to the save file.
    /// </summary>
    public void Save()
    {
        File.WriteAllBytes(Path.Combine(SAVES_DIRECTORY, this.Info.ID.ToString() + ".sav"), this.Info.ToBytes());
    }

    /// <summary>
    ///     Logs out of the current profile.
    /// </summary>
    public void LogOut()
    {
        this.Info = null;
    }

    /// <summary>
    ///     Gets the singleton instance of the currently active profile.
    /// </summary>
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

    /// <summary>
    ///     Loads the profile with the given id and returns it's data.
    /// </summary>
    /// <param name="id">The id of the profile to get.</param>
    /// <returns>The profile's data, null if the profile doesn't exist.</returns>
    public static ProfileInfo Get(int id)
    {
        ProfileInfo profile = new ProfileInfo(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
        
        if (profile.ID == 6)
            return null;
        else
            return profile;
    }

    /// <summary>
    ///     Creates a new profile.
    /// </summary>
    /// <param name="id">The id of the new profile.</param>
    /// <param name="name">The profile name.</param>
    public static void Create(int id, string name)
    {
        if (!Directory.Exists(SAVES_DIRECTORY))
        {
            Directory.CreateDirectory(SAVES_DIRECTORY);
        }

        byte[] buffer = new byte[SaveFileInfo.FILE_SIZE];

        Encoding.ASCII.GetBytes(name).CopyTo(buffer, SaveFileInfo.PROFILE_NAME);
        buffer[SaveFileInfo.AVATAR_GENDER] = 1;
        buffer[SaveFileInfo.AVATAR_COLOR_SKIN] = 15;
        buffer[SaveFileInfo.AVATAR_COLOR_TOP] = 15;
        buffer[SaveFileInfo.AVATAR_COLOR_BOTTOM] = 15;

        FileStream file = File.Create(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
        file.Write(buffer, 0, SaveFileInfo.FILE_SIZE);
        file.Close();
    }

    /// <summary>
    ///     Deletes an existing profile save file.
    /// </summary>
    /// <param name="id">The profile's id.</param>
    public static void Delete(int id)
    {
        File.Delete(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
    }

    /// <summary>
    ///     Checks if the profile exists.
    /// </summary>
    /// <param name="id">The profile's id.</param>
    /// <returns></returns>
    public static bool Exists(int id)
    {
        return File.Exists(Path.Combine(SAVES_DIRECTORY, id.ToString() + ".sav"));
    }

    /// <summary>
    ///     Checks if a profile name is available.
    /// </summary>
    /// <param name="name">The profile name</param>
    /// <returns>True if no profile has the name already, else false.</returns>
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