using UnityEngine;
using UnityEditor;

public class AutoRounder : EditorWindow
{
    [MenuItem("Utility/Auto Rounder")]
    static void Init()
    {
        var window = GetWindow<AutoRounder>();
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("AUTO ROUNDER");

        Separator(2);

        GUILayout.Label("Round to:");

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Nearest"))
        {
            Round("Nearest");
        }

        if (GUILayout.Button("Highest"))
        {
            Round("Highest");
        }

        if (GUILayout.Button("Lowest"))
        {
            Round("Lowest");
        }

        GUILayout.EndHorizontal();

        Separator(2);

        GUILayout.Label("INSTRUCTION");
        GUILayout.Label("1) Select all the sprites that you want to round its position");
        GUILayout.Label("2) Click on the button that best describes how you want the position to be rounded to");
    }


    void Round(string roundType)
    {
        GameObject[] selectedGOs = Selection.gameObjects;

        foreach(GameObject curGO in selectedGOs)
        {
            float targetPosX = curGO.transform.position.x;
            float targetPosY = curGO.transform.position.y;

            switch (roundType)
            {
                case "Nearest":
                    targetPosX = Mathf.Round(targetPosX);
                    targetPosY = Mathf.Round(targetPosY);
                    break;

                case "Highest":
                    targetPosX = Mathf.Ceil(targetPosX);
                    targetPosY = Mathf.Ceil(targetPosY);
                    break;

                case "Lowest":
                    targetPosX = Mathf.Floor(targetPosX);
                    targetPosY = Mathf.Floor(targetPosY);
                    break;
            }

            curGO.transform.position = new Vector3(targetPosX, targetPosY, curGO.transform.position.z);
        }
    }


    void Separator(int height)
    {
        for(int i=0; i<height; i++)
        {
            EditorGUILayout.Separator();
        }
    }

}
