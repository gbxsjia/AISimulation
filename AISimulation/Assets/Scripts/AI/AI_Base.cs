using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Base : MonoBehaviour
{
    public Character_Base character;
    public CharacterState_Base state;

    public AI_Mission_Base currentMission;

    private void Awake()
    {
        PossessCharacter(gameObject);
    }
    public void PossessCharacter(GameObject target)
    {
        character = target.GetComponent<Character_Base>();
        state = target.GetComponent<CharacterState_Base>();
    }
    private void Start()
    {
        currentMission = Instantiate(currentMission);
        currentMission.MissionStart(this, character);
    }
    private void Update()
    {
        currentMission.MissionUpdate(this, character);
    }
}
