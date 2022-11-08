using UnityEngine;

/// <summary>
/// Create a singleton instance of desired class.
/// </summary>
/// <typeparam name="T">Class to create a singleton instance.</typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static volatile T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                return instance;

            }
            return instance;
        }
    }
}
