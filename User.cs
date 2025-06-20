using UnityEngine;

public static class UserType
{
    public static string[] options = new string[]
    {
        "a",
        "b",
        "c",
        "d",
        "g",
        "z",
        "h",
    };
}

public class User : MonoBehaviour
{
    [ClassStaticNamesPopup(typeof(UserType), nameof(UserType.options))] public string m_myValue;
    [SceneNamesPopup] public string m_scenes;
}
