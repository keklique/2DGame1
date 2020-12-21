using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : CharacterBase
{
    override public void jumpSpecially()
    {
        rb.velocity = new Vector2(rb.velocity.x, -10);
        jumpSpecialityIsUsable = false;
        animator.SetBool("isSpeciallyJumped", true);
    }
}
