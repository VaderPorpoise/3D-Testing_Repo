using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_ShortSword : MeleeBluePrint
{
    // Start is called before the first frame update
    void Start()
    {
        setUpWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            swing();
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            block();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            Throw();
        }
        else
        {
            WeaponsManager.TargetAnimator.changeAnimationState(IdleNoMotion, 1);
            WeaponsManager.TargetAnimator.changeAnimationState(Ragdoll_Idle, 0);

        }
    }

}
