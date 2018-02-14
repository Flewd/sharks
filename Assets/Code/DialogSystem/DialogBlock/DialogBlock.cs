using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogLogicComplete{
        void LogicComplete();
    }

public class DialogBlock : MonoBehaviour,
    IDialogLogicComplete
{

    [TextArea(5, 10)]
    public string text;

    [SerializeField]
    private float textSpeed = 0.01f;

    public Sprite textBoxImage;
    
    public DialogBlock[] nextBlocks;
    public string[] nextBlockButtonLabels;

    private DialogBlockLogic[] instantLogics;
    private DialogBlockLogic[] orderedLogics;
    int orderedLogicIndex = 0;
    private DialogBlockLogic[] exitLogics;

    // Use this for initialization
    void Start () {

        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            if (go.gameObject.tag == "InstantLogics")
            {
                GetLogicsFromChildren(go, ref instantLogics);
            }
            else if(go.gameObject.tag == "OrderedLogics")
            {
                GetLogicsFromChildren(go, ref orderedLogics);
            }
            else if (go.gameObject.tag == "ExitLogics")
            {
                GetLogicsFromChildren(go, ref exitLogics);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetLogicsFromChildren(GameObject container, ref DialogBlockLogic[] storage)
    {
        storage = container.GetComponents<DialogBlockLogic>();
    }

    public void ExecuteLogics()
    {
        orderedLogicIndex = 0;
        ExecuteInstantLogics();
        ExecuteOrderedLogic(orderedLogicIndex);
    }

    public void ExecuteInstantLogics()
    {
        foreach (DialogBlockLogic logic in instantLogics)
        {
            logic.execute();
        }
    }

    public void ExecuteOrderedLogic(int index)
    {
        if (index < orderedLogics.Length)
        {
            orderedLogics[index].execute(this);
        }
    }

    public void ExecuteExitLogics()
    {
        foreach (DialogBlockLogic logic in exitLogics)
        {
            logic.execute();
        }
    }

    void IDialogLogicComplete.LogicComplete()
    {
        orderedLogicIndex++;
        ExecuteOrderedLogic(orderedLogicIndex);
    }

    public DialogBlock GetNextBlock(int pathIndex)
    {
        orderedLogicIndex = orderedLogics.Length;
        ExecuteExitLogics();
        return nextBlocks[pathIndex];
    }

    string addNewLines(string text)
    {
        int index = 30;

        while (index < text.Length)
        {
            text = text.Insert(index, "\n");
            index += 30;
        }
        return text;
    }

    public float getTextSpeed()
    {
        return textSpeed;
    }

#if UNITY_EDITOR

    void OnDrawGizmos()
    {
        drawString(addNewLines(text), transform.position, Color.blue);

        if (nextBlocks != null)
        {
            foreach (DialogBlock block in nextBlocks)
            {
                if (block != null)
                {
                    Gizmos.DrawLine(transform.position, block.transform.position);
                }
            }
        }
    }

    static public void drawString(string text, Vector3 worldPos, Color? colour = null)
    {
        UnityEditor.Handles.BeginGUI();

        var restoreColor = GUI.color;

        if (colour.HasValue) GUI.color = colour.Value;
        var view = UnityEditor.SceneView.currentDrawingSceneView;
        Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);

        if (screenPos.y < 0 || screenPos.y > Screen.height || screenPos.x < 0 || screenPos.x > Screen.width || screenPos.z < 0)
        {
            GUI.color = restoreColor;
            UnityEditor.Handles.EndGUI();
            return;
        }

        Vector2 size = GUI.skin.label.CalcSize(new GUIContent(text));
        GUI.Label(new Rect(screenPos.x - (size.x / 2), -screenPos.y + view.position.height + 4, size.x, size.y), text);
        GUI.color = restoreColor;
        UnityEditor.Handles.EndGUI();
    }
#endif

}
