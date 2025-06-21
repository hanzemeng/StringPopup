using System;
using System.Reflection;

public class StringArrayPopupAttribute : StringPopupAttribute
{
    protected Type m_classType;
    protected string m_stringArrayName;

    public StringArrayPopupAttribute(string stringArrayName, Type classType=null)
    {
        m_classType = classType;
        m_stringArrayName = stringArrayName;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        if(null == m_classType)
        {
            m_classType = targetObject.GetType();
        }
        m_options = m_classType.GetField(m_stringArrayName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
        .GetValue(targetObject) as string[];
    }
}
