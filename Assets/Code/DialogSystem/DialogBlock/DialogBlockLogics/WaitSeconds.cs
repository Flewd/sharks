using UnityEngine;
using System.Collections;

public class WaitSeconds : DialogBlockLogic
{
    public float waitTime = 1;

    // Use this for initialization
    void Start()
    {

    }

    public override void execute(IDialogLogicComplete callback)
    {
        base.execute(callback);
        execute();
    }

    public override void execute()
    {
        base.execute();
        StartCoroutine(waitAndTriggerEnd(waitTime));
    }

    IEnumerator waitAndTriggerEnd(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        LogicComplete();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
