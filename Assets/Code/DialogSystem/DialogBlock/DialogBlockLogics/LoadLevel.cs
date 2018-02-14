using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : DialogBlockLogic
{
    public Scenes sceneName;

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
        SceneManager.LoadScene(sceneName.ToString());

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
