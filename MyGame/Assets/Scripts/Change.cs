using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

