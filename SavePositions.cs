//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;

// public class SavePositions : MonoBehaviour
// {
//     public Transform[] squares; // Array to hold the square objects
//     public string fileName = "positions.json"; // Name of the JSON file to save the positions


//     public void Save()
//     {
//         List<Dictionary<string, object>> positions = new List<Dictionary<string, object>>();

//         // Fetch all active GameObjects in the scene
//         Transform[] allObjects = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];

//         foreach (Transform obj in allObjects)
//         {
//             // Log the name of the GameObject
//             Debug.Log("Found object: " + obj.name);

//             // Check if the object name contains "(Clone)"
//             if (obj.name.Contains("(Clone)"))
//             {
//                 Debug.Log("dfsf");
//                 Dictionary<string, object> positionData = new Dictionary<string, object>();
//                 positionData.Add("name", obj.name);
//                 positionData.Add("position", new float[] { obj.position.x, obj.position.y, obj.position.z });
//                 positions.Add(positionData);
//             }
//         }

//         string json = JsonUtility.ToJson(positions);
//         Debug.Log(json);
//         File.WriteAllText(Application.dataPath + "/" + fileName, json);

//         if (positions.Count > 0)
//         {
//             Debug.Log("Positions saved successfully to " + Application.dataPath + "/" + fileName);
//         }
//         else
//         {
//             Debug.Log("No positions saved. No GameObjects with '(Clone)' in their name found.");
//         }
//     }

// }

//    using System.Collections;
//    using System.Collections.Generic;
//    using UnityEngine;
//    using System.IO;
//
//    [System.Serializable]
//    public class PositionData
//    {
//        public string name;
//        public float[] position;
//    }
//
//    public class SavePositions : MonoBehaviour
//    {
//        public Transform[] squares; // Array to hold the square objects
//        public string fileName = "positions.json"; // Name of the JSON file to save the positions
//
//        public void Save()
//        {
//            List<PositionData> positions = new List<PositionData>();
//
//            // Fetch all active GameObjects in the scene
//            Transform[] allObjects = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];
//
//            foreach (Transform obj in allObjects)
//            {
//                // Log the name of the GameObject
//                Debug.Log("Found object: " + obj.name);
//
//                // Check if the object name contains "(Clone)"
//                if (obj.name.Contains("(Clone)"))
//                {
//                    Debug.Log("dfsf");
//                    PositionData positionData = new PositionData();
//                    positionData.name = obj.name;
//                    positionData.position = new float[] { obj.position.x, obj.position.y, obj.position.z };
//                    positions.Add(positionData);
//                }
//            }
//
//            // Wrap positions list into a wrapper object
//            var wrapper = new
//            {
//                Positions = positions
//            };
//
//            string json = JsonUtility.ToJson(wrapper);
//            Debug.Log(json);
//            File.WriteAllText(Application.dataPath + "/" + fileName, json);
//
//            if (positions.Count > 0)
//            {
//                Debug.Log("Positions saved successfully to " + Application.dataPath + "/" + fileName);
//            }
//            else
//            {
//                Debug.Log("No positions saved. No GameObjects with '(Clone)' in their name found.");
//            }
//        }
//
//    }
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;

// [System.Serializable]
// public class PositionData
// {
//     public string name;
//     public float[] position;
// }

// public class SavePositions : MonoBehaviour
// {
//     public Transform[] squares; // Array to hold the square objects
//     public string fileName = "positions.json"; // Name of the JSON file to save the positions

//     public void Save()
//     {
//         List<PositionData> positions = new List<PositionData>();

//         // Fetch all active GameObjects in the scene
//         Transform[] allObjects = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];

//         foreach (Transform obj in allObjects)
//         {
//             // Log the name of the GameObject
//             Debug.Log("Found object: " + obj.name);

//             // Check if the object name contains "(Clone)"
//             if (obj.name.Contains("(Clone)"))
//             {
//                 Debug.Log("dfsf");
//                 PositionData positionData = new PositionData();
//                 positionData.name = obj.name;
//                 positionData.position = new float[] { obj.position.x, obj.position.y, obj.position.z };
//                 positions.Add(positionData);
//             }
//         }

//         using (StreamWriter file = new StreamWriter(Application.dataPath + "/" + fileName))
//         {
//             file.Write("[\n");

//             for (int i = 0; i < positions.Count; i++)
//             {
//                 file.Write("  {\n");
//                 file.Write($"    \"name\": \"{positions[i].name}\",\n");
//                 file.Write($"    \"position\": [{positions[i].position[0]}, {positions[i].position[1]}, {positions[i].position[2]}]\n");
//                 if (i < positions.Count - 1)
//                     file.Write("  },\n");
//                 else
//                     file.Write("  }\n");
//             }

//             file.Write("]\n");
//         }

//         if (positions.Count > 0)
//         {
//             Debug.Log("Positions saved successfully to " + Application.dataPath + "/" + fileName);
//         }
//         else
//         {
//             Debug.Log("No positions saved. No GameObjects with '(Clone)' in their name found.");
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
[System.Serializable]
public class PositionData
{
    public string name;
    public float[] position;
    public float[] color;
}

public class SavePositions : MonoBehaviour
{
    public Transform[] squares; // Array to hold the square objects
    public TMP_InputField inputField;
    public string fileName = inputField.text + ".json"; // Name of the JSON file to save the positions

    public void Save()
    {
        List<PositionData> positions = new List<PositionData>();

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
                PositionData positionData = new PositionData();
                positionData.name = obj.name;
                positionData.position = new float[] { obj.position.x, obj.position.y, obj.position.z };
                Renderer renderer = obj.GetComponent<Renderer>();
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
                Color color;
                if (renderer != null) // Check if the GameObject has a Renderer component
                    {
                        color = renderer.material.color; // Get the color of the material
                    }
                    else if (spriteRenderer != null) // Check if the GameObject has a SpriteRenderer component
                    {
                        color = spriteRenderer.color; // Get the color of the sprite
                    }
                    else
                    {
                        // Default color (white) in case the GameObject has no Renderer or SpriteRenderer component
                        color = Color.white;
                    }
                     positionData.color = new float[] { color.r, color.g, color.b, color.a };
                positions.Add(positionData);
            }
        }

        using (StreamWriter file = new StreamWriter(Application.dataPath + "/" + fileName))
        {
            file.Write("[\n");

            for (int i = 0; i < positions.Count; i++)
            {
                file.Write("  {\n");
                file.Write($"    \"name\": \"{positions[i].name}\",\n");
                file.Write($"    \"position\": [{positions[i].position[0]}, {positions[i].position[1]}, {positions[i].position[2]}]\n");
                file.Write($"    \"color\": [{positions[i].color[0]}, {positions[i].color[1]}, {positions[i].color[2]}, {positions[i].color[3]}]\n");
                if (i < positions.Count - 1)
                    file.Write("  },\n");
                else
                    file.Write("  }\n");
            }

            file.Write("]\n");
        }

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
