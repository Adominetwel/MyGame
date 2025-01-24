using UnityEngine;
using TMPro;
public class Solution : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public string[] solution;
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
}
