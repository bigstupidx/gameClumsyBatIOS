using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BossData", menuName = "Custom/Boss", order = 1)]
public class BossCreator : ScriptableObject
{
    public string BossName;
    public GameObject BossPrefab; 
    public MonoScript[] AbilitySet;
    
    public enum BossActions
    {
        Wait,
        Speak,
        Die
    }
    public List<BossActions> things;
    public List<BaseNode> Nodes;

    [OnOpenAssetAttribute(1)]
    private static bool LoadBossEditorIfBossCreatorObjectSelected(int instanceID, int line)
    {
        Object obj = EditorUtility.InstanceIDToObject(instanceID);
        if (EditorUtility.InstanceIDToObject(instanceID).GetType() == typeof(BossCreator))
        {
            BossEditor editor = EditorWindow.GetWindow<BossEditor>(desiredDockNextTo: typeof(SceneView));
            editor.BossCreatorObject = (BossCreator)obj;
            editor.LoadBoss();
            foreach(var node in editor.BossCreatorObject.Nodes)
            {
                Debug.Log(node.WindowTitle);
            }
        }
        return false;
    }
}
