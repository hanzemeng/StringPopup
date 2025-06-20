#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(StringPopupAttribute), true)]
public class StringPopupAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        StringPopupAttribute stringDropdownAttribute = attribute as StringPopupAttribute;
        string[] options = stringDropdownAttribute.GetOptions();
        string oldStr = property.stringValue;
        int oldIndex = Array.FindIndex(options, i=>string.Equals(i, oldStr));
        if(oldIndex < 0)
        {
            oldIndex = 0;
        }

        int newIndex = EditorGUI.Popup(position, property.name, oldIndex, options);
        property.stringValue = options[newIndex];
    }
}

#endif
