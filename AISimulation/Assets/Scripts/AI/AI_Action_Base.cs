using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action")]
public class AI_Action_Base : ScriptableObject
{
    public AI_Mission_Base Mission;

    public virtual void ActionStart(AI_Mission_Base mission, AI_Base brain, Character_Base character)
    {
        Mission = mission;
    }
    public virtual void ActionEnd(AI_Base brain, Character_Base character)
    {
        Mission.ActionFinish(this, true);
    }
    public virtual void ActionUpdate(AI_Base brain, Character_Base character)
    {

    }
}
