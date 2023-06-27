using UnityEditor;

namespace Hydroponical
{
    [CustomEditor(typeof(NestedScriptableObjectBehaviour))]
    public class NestedScriptableObjectEditor : Editor
    {
        private Editor NestedEditor { get; set; } = null;

        public NestedScriptableObjectBehaviour TargetScriptableObject => target as NestedScriptableObjectBehaviour;

        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI();

            if (TargetScriptableObject.CurrentScriptableObject != null)
            {
                EditorGUILayout.LabelField(TargetScriptableObject.CurrentScriptableObject.name, EditorStyles.boldLabel);

                if (NestedEditor == null)
                {
                    NestedEditor = Editor.CreateEditor(TargetScriptableObject.CurrentScriptableObject);
                }

                NestedEditor.OnInspectorGUI();
            }
        }
    }
}