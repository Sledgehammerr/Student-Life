#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(StoreButton))]
public class StoreButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        StoreButton t = (StoreButton)target;
    }
}
#endif
