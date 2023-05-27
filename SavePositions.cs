using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePositions : MonoBehaviour
{
    public Transform[] squares; // Array to hold the square objects
    public string fileName = "positions.json"; // Name of the JSON file to save the positions


    public void Save()
    {
        List<Dictionary<string, object>> positions = new List<Dictionary<string, object>>();

        // Fetch all active GameObjects in the scene
        Transform[] allObjects = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];

        foreach (Transform obj in allObjects)
        {
            // Log the name of the GameObject
            Debug.Log("Found object: " + obj.name);

            // Check if the object name contains "(Clone)"
            if (obj.name.Contains("(Clone)"))
            {
                Debug.Log("dfsf");
                Dictionary<string, object> positionData = new Dictionary<string, object>();
                positionData.Add("name", obj.name);
                positionData.Add("position", new float[] { obj.position.x, obj.position.y, obj.position.z });
                positions.Add(positionData);
            }
        }

        string json = JsonUtility.ToJson(positions);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/" + fileName, json);

        if (positions.Count > 0)
        {
            Debug.Log("Positions saved successfully to " + Application.dataPath + "/" + fileName);
        }
        else
        {
            Debug.Log("No positions saved. No GameObjects with '(Clone)' in their name found.");
        }
    }

}
