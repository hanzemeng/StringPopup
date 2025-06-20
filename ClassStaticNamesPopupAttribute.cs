using System;
using System.Reflection;

public class ClassStaticNamesPopupAttribute : StringPopupAttribute
{
    public ClassStaticNamesPopupAttribute(Type classType, string optionsFieldName)
    {
        m_options = classType.GetField(optionsFieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
        .GetValue(null) as string[];
    }
}
