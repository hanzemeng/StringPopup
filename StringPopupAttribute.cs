using UnityEngine;

public class StringPopupAttribute : PropertyAttribute
{
    protected string[] m_options;

    public string[] GetOptions()
    {
        return m_options;
    }
}
