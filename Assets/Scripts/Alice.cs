using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : CharacterBase
{
    override public void jumpSpecially()
    {
        Vector2 Scaler = transform.localScale;
        transform.position = new Vector2(transform.position.x + Scaler.x * 4, transform.position.y);
        jumpSpecialityIsUsable = false;
    }
}
