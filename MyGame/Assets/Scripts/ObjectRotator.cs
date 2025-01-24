using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject Door;
    public bool rotateCondition;
    public static bool r90 = false, r180 = false, r270 = false;
    private void Start()
    {
        if (r90)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90f);
            r90 = false;
        }
        if (r180)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180f);
            r180 = false;
        }
        if (r270)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270f);
            r270 = false;
        }
    }
}