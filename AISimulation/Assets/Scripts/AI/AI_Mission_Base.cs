using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Mission")]
public class AI_Mission_Base:ScriptableObject
{
    public int Priorit;

    public List<AI_Action_Base> ActionList;
    private AI_Action_Base currentAction;

    public virtual void MissionStart(AI_Base brain, Character_Base character)
    {
        currentAction = ActionList[0];
    }
    public virtual void MissionUpdate(AI_Base brain, Character_Base character)
    {
        currentAction.ActionUpdate(brain, character);
    }

    public virtual void MissionEnd(AI_Base brain, Character_Base character)
    {

    }

    public virtual void MissionAbort(AI_Base brain, Character_Base character, AI_Mission_Base newMission)
    {

    }

    public virtual void ActionFinish(AI_Action_Base action, bool success)
    {

    }
}
