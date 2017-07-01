using UnityEngine;
using UnityEditor;

public class MenuItems {

  [MenuItem("Window/Window_01 &g", false, 11)]
  static void OpenWindow_01() { OpenEditorWindow<Window_01>(new Vector2(800, 600)); }

  [MenuItem("Window/Window_02 &h", false, 11)]
  static void OpenWindow_02() { OpenEditorWindow<Window_02>(new Vector2(320, 50)); }

  static void OpenEditorWindow<T>(Vector2 windowMinSize) where T : EditorWindow {
    var currentWindow = Resources.FindObjectsOfTypeAll<T>();
    if(currentWindow.Length > 0) {
      Debug.Log("There is already a " + typeof(T).ToString() + " window open.");
      EditorWindow.FocusWindowIfItsOpen<T>();
    } else {
      Debug.Log("There is no  " + typeof(T).ToString() + " window currently open. Creating...");
      var thisWin = ScriptableObject.CreateInstance<T>();
      thisWin.titleContent = new GUIContent(typeof(T).ToString() + " Editor");
      thisWin.ShowUtility();
      thisWin.minSize = windowMinSize;
      thisWin.maxSize = new Vector2(thisWin.minSize.x + .1f, thisWin.minSize.y + .1f);
    }
  }
}
