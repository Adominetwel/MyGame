using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TMP_Text textMeshPro;
    private void Start()
    {
        if (Movement.Code)
        {
            textMeshPro.text = "SYNTAX ERROR";
            Movement.Code = false;
        }
        else if (Movement.Borders)
        {
            textMeshPro.text = "YOU HAVE GONE BEYONG BORDERS OF THE MAP";
            Movement.Borders = false;
        }
        else if (Movement.ODoor)
        {
            textMeshPro.text = "YOU HAVEN'T REACHED THE DOOR";
            Movement.ODoor = false;
        }
        else if (Movement.ODoor)
        {
            textMeshPro.text = "YOU HAVEN'T REACHED THE DOOR";
            Movement.ODoor = false;
        }
        else if (Movement.LongCode)
        {
            textMeshPro.text = "YOUR CODE IS SO LONG";
            Movement.LongCode = false;
        }
        else
        {
            textMeshPro.text = "UNKOWN ERROR";
        }
    }
}
