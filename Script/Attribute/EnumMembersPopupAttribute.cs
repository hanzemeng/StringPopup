using System;

public class EnumMembersPopupAttribute : StringPopupAttribute
{
    protected Type m_classType;

    public EnumMembersPopupAttribute(Type classType)
    {
        m_classType = classType;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        m_options = Enum.GetNames(m_classType);
    }
}
