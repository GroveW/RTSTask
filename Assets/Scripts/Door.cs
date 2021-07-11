using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();

        anim.SetTrigger("Open");
    }

    public void MeetRestrictions()
    {
        restrictionsMet = true;
    }
}
