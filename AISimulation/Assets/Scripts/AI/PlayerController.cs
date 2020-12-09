using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Character_Base character;
    private void Update()
    {
        Vector3 InputDirection = Vector3.forward;
        InputDirection.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        character.Move(InputDirection);
    }
}
