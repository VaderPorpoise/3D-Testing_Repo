using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeBluePrint : MonoBehaviour
{


    //here would go th string values for the states( running, crouching, inAir)
    //as const strings

    [Header("weaponStats")]

    public static int numWeapons;

    public int meleeDmg;

    public string WeaponTag;
    protected bool isGun = true;

    protected float hitRate;
    float knockBack = 100f;

    [Header("animationClips")]
    public AnimationClip IdleMeeleAnimation;
    public AnimationClip swingAnimation;
    public AnimationClip BlockAnimation;
    public AnimationClip ThrowAnimation;
    [SerializeField]
    protected AnimationClip Ragdoll_Idle;

    [Header("weapon Components")]

    protected mouseLook mouseLook;

    protected GameObject playerObject;

    [HideInInspector]

    public PlayerWeaponsManager WeaponsManager;

    protected bool isBlocking = false;
    protected bool isSwinging = false;
    protected void setUpWeapon()
    {
        WeaponsManager = FindObjectOfType<PlayerWeaponsManager>();

        mouseLook = FindObjectOfType<mouseLook>();
        playerObject = WeaponsManager.gameObject;
        WeaponsManager.TargetAnimator.changeAnimationState(IdleMeeleAnimation.name, 1);


    }

    protected void swing()
    {

        if (isSwinging) return;
        StartCoroutine(SwingCoroutine(swingAnimation));
    
        WeaponsManager.TargetAnimator.changeAnimationState(swingAnimation.name, 1);
        //animator mask must contain the animationclip/action and must be weight 1
     




    }
    protected void block()
    {

       
        //animator mask must contain the animationclip/action and must be weight 1




    }
    protected void Throw()
    {

        //animator mask must contain the animationclip/action and must be weight 1





    }
    public IEnumerator SwingCoroutine(AnimationClip animation)
    {
        isSwinging = true;
        
        yield return new WaitForSeconds(animation.length);
        
        isSwinging = false;
        WeaponsManager.TargetAnimator.changeAnimationState(IdleMeeleAnimation.name, 1);
    }
    protected void applyKnockBack()
    {
        WeaponsManager.knockBackPart.AddForce(-knockBack * WeaponsManager.knockBackPart.transform.up, ForceMode.Impulse);

    }

    void timer(float timerTime)
    {

        //do something untill time = 0
    }
}
