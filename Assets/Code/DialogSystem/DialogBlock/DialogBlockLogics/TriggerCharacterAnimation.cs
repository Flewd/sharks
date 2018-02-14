using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCharacterAnimation : DialogBlockLogic {

    public Animator character;
    public AnimationTriggers animationTrigger;

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
        character.SetTrigger(animationTrigger.ToString());
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
