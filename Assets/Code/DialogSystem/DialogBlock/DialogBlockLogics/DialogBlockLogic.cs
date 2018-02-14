using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBlockLogic : MonoBehaviour {

    protected IDialogLogicComplete CompleteCallback = null;

    public virtual void execute()
    {

    }

    public virtual void execute(IDialogLogicComplete callback)
    {
        CompleteCallback = callback;
    }

    protected virtual void LogicComplete()
    {
        if(CompleteCallback != null)
        {
            CompleteCallback.LogicComplete();
        }
    }

}
