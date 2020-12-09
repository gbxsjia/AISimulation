using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Base : MonoBehaviour
{
    public CharacterState_Base state;
    public virtual void Move(Vector3 direction)
    {

    }

    public virtual void Attack(GameObject target,Vector3 direction)
    {
        
    }
}
