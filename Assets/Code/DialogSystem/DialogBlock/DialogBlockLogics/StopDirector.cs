using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StopDirector : DialogBlockLogic {

	[SerializeField] private PlayableDirector director;
		
	public override void execute(IDialogLogicComplete callback)
	{
		base.execute(callback);
		execute();
	}
	
	public override void execute()
	{
		base.execute();
		director.time = 0;
		director.Stop();
		LogicComplete();
	}
}
