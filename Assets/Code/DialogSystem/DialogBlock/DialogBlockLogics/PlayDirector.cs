using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayDirector : DialogBlockLogic {

	[SerializeField] private PlayableDirector director;
		
	public override void execute(IDialogLogicComplete callback)
	{
		base.execute(callback);
		execute();
	}
	
	public override void execute()
	{
		base.execute();
		director.Play();
		LogicComplete();
	}
}
