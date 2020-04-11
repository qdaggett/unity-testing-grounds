using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;

// Quinn Daggett - 100618734
// 2020-01-29

public class DoorManager : MonoBehaviour
{

    // File readings
    public FileInfo source = null;
    public StreamReader fileReader = null;
    public string text = " ";

    // Arrays for doors and their spawn positions
    public GameObject[] doorPositions;
    public GameObject[] doors;
    
    // Prefab for spawning doors
    public GameObject doorPrefab;

    // References for disabling UI elements
    public InputField pathInput;
    public Button goButton;
    public Text chancesList;

    // Temporary variables for assigning to doors
    bool tempHot;
    bool tempNoisy;
    bool tempSafe;
    float probability;

    // Variable for door spawning
    int totalDoors = 0;

    // Function called by button
    public void TextInput()
    {
        DoorSetup(pathInput.text);
    }

    public void DoorSetup(string path)
    {
        // If the file exists
        if(System.IO.File.Exists(path))
        {
            // Disable input field and button 
            pathInput.gameObject.SetActive(false);
            goButton.gameObject.SetActive(false);

            // Door positions
            doorPositions = GameObject.FindGameObjectsWithTag("DoorPosition"); // Getting array of door positions by tag

            doors = new GameObject[20]; // Array to store door positions

            // File reading
            source = new FileInfo(path);
            fileReader = source.OpenText();

            string[] text = System.IO.File.ReadAllLines(path); // Read all lines in the file sequentially

            for (int i = 1; i < text.Length; i++) // For each line in the file
            {
                //Debug.Log(text[i]);

                string[] components = text[i].Split(null); // This will split each "component" of a line into individual strings (is hot, is noisy, is safe, percentage)

                if (components[0] == "Y") // First component contains hot = Y/N
                {
                    tempHot = true;
                }
                else
                {
                    tempHot = false;
                }

                if (components[1] == "Y") // Second component contains noisy = Y/N
                {
                    tempNoisy = true;
                }
                else
                {
                    tempNoisy = false;
                }

                if (components[2] == "Y") // Third component contains safe = Y/N
                {
                    tempSafe = true;
                }
                else
                {
                    tempSafe = false;
                }

                probability = float.Parse(components[3]); // Fourth component contains probability


                for (int k = 0; k < Convert.ToInt32(probability * 20); k++) // Determining how many doors should be created based on probability
                {
                    Debug.Log(probability * 20);
                    if (totalDoors < doors.Length) // Creating and applying properties to doors in order
                    {
                        doors[totalDoors] = Instantiate(doorPrefab, doorPositions[totalDoors].transform.position, doorPrefab.transform.rotation); // Spawn in door from prefab
                        doors[totalDoors].GetComponent<Door>().InitDoor(tempHot, tempNoisy, tempSafe); // Set up properties of door from temp variables

                        totalDoors++;
                    }

                }

                chancesList.text += components[0] + " ";
                chancesList.text += components[1] + " ";
                chancesList.text += components[2] + " ";
                chancesList.text += components[3] + " ";
                chancesList.text += Convert.ToInt32(probability * 20) + " ";
                chancesList.text += "\r\n";

                Array.Clear(components, 0, components.Length); // Clear array each loop

            }

        }

        else
        {
            Debug.Log("Invalid path!"); // Invalid path
        }

        
    }

}
