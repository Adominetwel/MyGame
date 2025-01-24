using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    public static bool TryAgain = false;
    public TMP_Text textMeshPro;
    public string[] solution;
    public static bool Generation = false;
    
    public void Help()
    {
        string displayText = "";
        solution = Movement.solution;
        foreach (string s in solution)
        {
            displayText += s + "\n";
        }
        textMeshPro.text = displayText;
    }
    public void ChangeScene(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Try_Again()
    {
        TryAgain = true;
        Movement.del_sol();
    }
    public void Generate()
    {
        Generation = true;
    }
}
