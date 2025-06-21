using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor.Animations;

public class AnimatorStatesNamesAttribute : StringPopupAttribute
{
    protected string m_animatorName;
    protected char m_stateLayerDelimiter;

    public AnimatorStatesNamesAttribute(string animatorName, char stateLayerDelimiter=(char)0x00)
    {
        m_animatorName = animatorName;
        m_stateLayerDelimiter = stateLayerDelimiter;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        object obj = targetObject.GetType().GetField(m_animatorName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
        .GetValue(targetObject);

        AnimatorController animatorController;
        if(obj is Animator)
        {
            animatorController = (obj as Animator).runtimeAnimatorController as AnimatorController;
        }
        else
        {
            animatorController = obj as AnimatorController;
        }

        List<string> statesLayers = new List<string>();
        AnimatorControllerLayer[] animatorControllerLayer = animatorController.layers;
        int layer;

        void AddStatesInStateMachine(AnimatorStateMachine animatorStateMachine)
        {
            foreach(ChildAnimatorState childAnimatorState in animatorStateMachine.states)
            {
                if(char.IsControl(m_stateLayerDelimiter))
                {
                    statesLayers.Add($"{childAnimatorState.state.name}");
                }
                else
                {
                    statesLayers.Add($"{childAnimatorState.state.name}{m_stateLayerDelimiter}{layer}");
                }
            }

            foreach(ChildAnimatorStateMachine childAnimatorStateMachine in animatorStateMachine.stateMachines)
            {
                AddStatesInStateMachine(childAnimatorStateMachine.stateMachine);
            }
        }

        for(layer=0; layer<animatorControllerLayer.Length; layer++)
        {
            AddStatesInStateMachine(animatorControllerLayer[layer].stateMachine);
        }
        
        m_options = statesLayers.ToArray();
    }
}
