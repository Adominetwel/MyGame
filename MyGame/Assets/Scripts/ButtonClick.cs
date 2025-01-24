using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Destroy(button.gameObject);
    }
}

