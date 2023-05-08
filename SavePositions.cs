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

        foreach (Transform square in squares)
        {
            if (square.name.Contains("Square(2)(Clone)")) // Check if the object name contains "Square(2)(Clone)"
            {
                Dictionary<string, object> positionData = new Dictionary<string, object>(); 
                positionData.Add("name", square.name);
                positionData.Add("position", new float[] { square.position.x, square.position.y, square.position.z });
                positions.Add(positionData);
            }
        }

        string json = JsonUtility.ToJson(positions); // Convert list to JSON string
        File.WriteAllText(Application.dataPath + "/" + fileName, json); // Write JSON string to file
    }
}
