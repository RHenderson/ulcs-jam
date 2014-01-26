using UnityEngine;
using System.Collections;

public class InteractiveAnimation : InteractiveObject {

    public override void Interact()
    {
        animation.Play();
    }

}
