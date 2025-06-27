// File: Assets/Editor/RemoveMissingScripts.cs
using UnityEditor;
using UnityEngine;

public class RemoveMissingScripts
{
    [MenuItem("Tools/Cleanup/Remove Missing Scripts")]
    static void Remove()
    {
        int count = 0;
        var allGameObjects = GameObject.FindObjectsOfType<GameObject>(true);

        foreach (GameObject go in allGameObjects)
        {
            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
            if (removed > 0)
            {
                count += removed;
                Debug.Log($"Removed {removed} missing script(s) from '{go.name}'", go);
            }
        }

        Debug.Log($"✅ Done. Removed total of {count} missing script(s).");
    }
}
