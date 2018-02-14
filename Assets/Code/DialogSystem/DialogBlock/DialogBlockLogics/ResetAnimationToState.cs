using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimationToState : DialogBlockLogic
{
    public Animator character;
    public AnimationStates animationState;

    // Use this for initialization
    void Start () {
		
	}

    public override void execute(IDialogLogicComplete callback)
    {
        base.execute(callback);
        execute();
    }

    public override void execute()
    {
        base.execute();
        character.Play(animationState.ToString());
        StartCoroutine(waitAndTriggerEnd(character.GetCurrentAnimatorClipInfo(0).Length));

    }

    IEnumerator waitAndTriggerEnd(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        LogicComplete();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
