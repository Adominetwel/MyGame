using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomObjectGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject key;
    public static float PosPX1;
    public static float PosPY1;
    public static float PosKX1;
    public static float PosKY1;
    public static float PosDX1;
    public static float PosDY1;
    float x, y;
    public GameObject door;
    public GameObject Generator;
    float x1, y1, x2, y2;
    bool m;
    public void GenerateRandomObjects()
    {
        if (!Scenes.TryAgain)   
        {
            //GenGrid.Gen_Grid();





            x = -9.5f + Random.Range(0, 6) * 3.8f;
            y = -9.5f + Random.Range(0, 6) * 3.8f;
            Vector3 position = new Vector3(x, y, 0);
            Instantiate(player, position, Quaternion.identity);
            PosPX1 = x;
            PosPY1 = y;
            x1 = x;
            y1 = y;
            while (true)
            {
                x = -9.5f + Random.Range(0, 6) * 3.8f;
                y = -9.5f + Random.Range(0, 6) * 3.8f;
                //if (x != x1)
                //    x = -9.5f + Random.Range(0, 5) * 3.8f;
                //if (y != y1)
                //    y = -9.5f + Random.Range(0, 5) * 3.8f;
                if (x != x1 || y != y1)
                {
                    PosKX1 = x;
                    PosKY1 = y;
                    break;
                }
            }
            position = new Vector3(x, y, 0);
            Instantiate(key, position, Quaternion.identity);
            while (true)
            {
                    x = -10.5f + Random.Range(0, 7) * 3.5f;
                //y = -10.5f + Random.Range(0, 7) * 3.5f;
                y = -10.5f;
                    if (x == 10.5)
                    {
                        y = -9.5f + Random.Range(0, 6) * 3.8f;
                    PosDX1 = x - 1;
                    PosDY1 = y;
                    m = true;
                    }
                    else if (x == -10.5)
                    {
                    y = -9.5f + Random.Range(0, 6) * 3.8f;
                    PosDX1 = x + 1;
                    PosDY1 = y;
                    m = true;
                    }
                    else if (y == -10.5)
                    {
                        x = -9.5f + Random.Range(0, 6) * 3.8f;
                    PosDX1 = x;
                    PosDY1 = y + 1;
                    m = true;
                    }
                    else if (y == 10.5)
                    {
                        x = -9.5f + Random.Range(0, 6) * 3.8f;
                    PosDX1 = x;
                    PosDY1 = y - 1;
                    m = true;
                    }
                    if (m)
                        break;
            }
            position = new Vector3(x, y, 0);
            Instantiate(door, position, Quaternion.identity);
            if (x == -10.5f)  
                ObjectRotator.r180 = true;
            else if (y == -10.5f)
                ObjectRotator.r270 = true;
            else if (y == 10.5f)
                ObjectRotator.r90 = true;
            Instantiate(Generator, position, Quaternion.identity);
        }
        else
        {
            PosPX1 = Movement.PPX;
            PosPY1 = Movement.PPY;
            PosKX1 = Movement.KPX;
            PosKY1 = Movement.KPY;
            PosDX1 = Movement.PDX;
            PosDY1 = Movement.PDY;
            Vector3 position = new Vector3(Movement.PPX, Movement.PPY, 0);
            Instantiate(player, position, Quaternion.identity);
            position = new Vector3(Movement.KPX, Movement.KPY, 0);
            Instantiate(key, position, Quaternion.identity);
            position = new Vector3(Movement.PDX, Movement.PDY, 0);
            Instantiate(door, position, Quaternion.identity);
            Scenes.TryAgain = false;
        }
    }
}
