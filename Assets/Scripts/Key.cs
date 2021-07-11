using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public Door door;

    public override void Interact()
    {
        base.Interact();

        GameObject.Find("CameraObj").GetComponent<Player>().TakeKey();

        door.MeetRestrictions();

        Destroy(gameObject);
    }
}
