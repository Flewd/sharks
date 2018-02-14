using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject :  DialogBlockLogic
{

	[SerializeField] private GameObject ObjectToEnable;
		
	public override void execute(IDialogLogicComplete callback)
	{
		base.execute(callback);
		execute();
	}
	
	public override void execute()
	{
		base.execute();
		ObjectToEnable.SetActive(false);
		LogicComplete();
	}
}
