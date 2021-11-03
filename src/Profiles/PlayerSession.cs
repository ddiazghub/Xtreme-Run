using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
///     Class that contains the the currently active profile.
/// </summary>
public class PlayerSession
{

    /// <summary>
    ///     Singleton instance.
    /// </summary>
    private static PlayerSession activeSession;

    /// <summary>
    ///     Data of the active profile.
    /// </summary>
    public Profile Profile
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
        this.Profile = Profile.Get(id);
    }

    /// <summary>
    ///     Saves the the currently active profile by writing to the save file.
    /// </summary>
    public void Save()
    {
        File.WriteAllBytes(Path.Combine(Profile.SAVES_DIRECTORY, this.Profile.ID.ToString() + ".sav"), this.Profile.ToBytes());
    }

    /// <summary>
    ///     Logs out of the current profile.
    /// </summary>
    public void LogOut()
    {
        this.Profile = null;
    }

    /// <summary>
    ///     Gets the singleton instance of the currently active profile.
    /// </summary>
    public static PlayerSession ActiveSession
    {
        get
        {
            if (activeSession == null)
            {
                activeSession = new PlayerSession();
            }

            return activeSession;
        }
    }
}