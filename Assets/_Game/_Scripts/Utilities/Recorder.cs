using UnityEngine;

public static class Recorder
{

    /// <summary>
    /// Save a key as determined value to PlayerPrefs.
    /// </summary>
    /// <param name="key">The name of recording.</param>
    /// <param name="value">The value of recording.</param>
    public static void Record(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    /// <summary>
    /// Get a recorded value from PlayerPrefs.
    /// </summary>
    /// <param name="key">The name of desired record.</param>
    /// <param name="defaultValue">Desired value. Returns zero if it has not recorded before..</param>
    /// <returns></returns>
    public static int GetRecord(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }
}
