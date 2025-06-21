using UnityEngine;

public abstract class StringPopupAttribute : PropertyAttribute
{
    protected string[] m_options;

    public string[] GetOptions(UnityEngine.Object targetObject)
    {
        try
        {
            GetOptionsInternal(targetObject);
        }
        catch
        {
            //Debug.LogError("String popup field failed to get options.");
            m_options = new string[]{"ERROR"};
        }

        if(null == m_options || 0 == m_options.Length)
        {
            m_options = new string[]{"NO_VALUE"};
        }
        return m_options;
    }

    protected abstract void GetOptionsInternal(UnityEngine.Object targetObject);
}
