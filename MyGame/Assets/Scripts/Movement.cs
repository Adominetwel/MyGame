using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;




public class Movement : MonoBehaviour
{

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
    }


    public static int[,] mas = new int[,]
{
        {0,0,0,0,0,0},
        {0,0,0,0,0,0},
        {0,0,0,0,0,0},
        {0,0,0,0,0,0},
        {0,0,0,0,0,0},
        {0,0,0,0,0,0}
};
    private bool showConsole = true;
    private bool WithKey = false;
    private string currentInput = "";
    private string output = "";
    protected string [] arr = new string[100];
    public static float speed = 3.8f;
    private int j = 0;
    float KeyPositionX;
    float KeyPositionY;
    float PlayerPositionX;
    float PlayerPositionY;
    float DoorPositionX;
    float DoorPositionY;
    public static float KPX, KPY, PPX, PPY, PDX, PDY;
    bool OpenDoor = false;
    bool beg = false;
    public static bool Borders = false, LongCode = false, ODoor = false, Code = false;
    int count_y;
    int q = 1;
    int count_x;
    int asd = 0;
    float CX;
    int w;
    float CY;
    GameObject Key;
    GameObject Player;
    public GameObject player;
    GameObject Door;
    List<Node> Move;
    private bool isUpdateEnabled = true;
    public static string[] solution = new string [100];
    void WaitForSeconds(int seconds)
    {
        Thread.Sleep(seconds);
    }
    private void move()
    {
        //Vector3 position = new Vector3(PlayerPositionX, PlayerPositionY, 0);
        //Instantiate(player, position, Quaternion.identity);
        WaitForSeconds(1);

    }
    public static void del_sol()
    {
        int p = 0; 
        while (solution[p] != null)
        {
            solution[p] = null;
            p++;
        }
    }
    private void Border()
    {
        if (Math.Abs(PlayerPositionX) > speed * 2.51 || Math.Abs(PlayerPositionY) > speed * 2.51)
        {
            Borders = true;
            SceneManager.LoadScene("LoseWindow");
        }
    }
    private void Solution(int count_x, int count_y)
    {
        solution[0] = "Begin";
        while (count_x != 0 || count_y != 0)
            if (Math.Abs(count_x) == 1 || Math.Abs(count_y) == 1)
            {
                if (count_x == 1)
                {
                    solution[q] = "Left";
                    q++;
                    count_x--;
                }
                if (count_x == -1)
                {
                    solution[q] = "Right";
                    q++;
                    count_x++;
                }
                if (count_y == 1)
                {
                    solution[q] = "Up";
                    q++;
                    count_y--;
                }
                if (count_y == -1)
                {
                    solution[q] = "Down";
                    q++;
                    count_y++;
                }
            }
            else if (count_x == count_y && count_x > 0)
            {
                solution[q] = "Up";
                solution[q + 1] = "and";
                solution[q + 2] = "Left";
                solution[q + 3] = "for";
                solution[q + 4] = count_x.ToString();
                count_x = 0;
                count_y = 0;
                q += 5;
            }
            else if (count_x == count_y && count_x < 0)
            {
                solution[q] = "Down";
                solution[q + 1] = "and";
                solution[q + 2] = "Right";
                solution[q + 3] = "for";
                solution[q + 4] = Math.Abs(count_x).ToString();
                count_x = 0;
                count_y = 0;
                q += 5;
            }
            else if (Math.Abs(count_x) == count_y)
            {
                solution[q] = "Up";
                solution[q + 1] = "and";
                solution[q + 2] = "Right";
                solution[q + 3] = "for";
                solution[q + 4] = Math.Abs(count_x).ToString();
                count_x = 0;
                count_y = 0;
                q += 5;
            }
            else if (Math.Abs(count_y) == count_x)
            {
                solution[q] = "Down";
                solution[q + 1] = "and";
                solution[q + 2] = "Left";
                solution[q + 3] = "for";
                solution[q + 4] = Math.Abs(count_x).ToString();
                count_x = 0;
                count_y = 0;
                q += 5;
            }
            else
            {
                if (count_x == Math.Max(count_y, count_x) && count_x >= 0 && count_y >= 0)
                {
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (count_x - count_y == 1)
                        {
                            solution[q] = "Left";
                            q++;
                            count_x--;
                        }
                        else
                        {
                            solution[q] = "Left";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_x) - Math.Abs(count_y)).ToString();
                            count_x = count_y;
                            q += 3;
                        }
                    }
                }
                else if (count_y == Math.Max(count_y, count_x) && count_x >= 0 && count_y >= 0)
                {
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (count_y - count_x == 1)
                        {
                            solution[q] = "Up";
                            q++;
                            count_y--;
                        }
                        else
                        {
                            solution[q] = "Up";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_y) - Math.Abs(count_x)).ToString();
                            count_y = count_x;
                            q += 3;
                        }
                    }
                }
                else if (Math.Abs(count_x) == Math.Max(Math.Abs(count_y), Math.Abs(count_x)) && count_x <= 0 && count_y <= 0)
                {
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (Math.Abs(count_x) - Math.Abs(count_y) == 1)
                        {
                            solution[q] = "Right";
                            q++;
                            count_x++;
                        }
                        else
                        {
                            solution[q] = "Right";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_x) - Math.Abs(count_y)).ToString();
                            count_x = count_y;
                            q += 3;
                        }
                    }
                }
                else if (Math.Abs(count_y) == Math.Max(Math.Abs(count_y), Math.Abs(count_x)) && count_x <= 0 && count_y <= 0)
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (Math.Abs(count_y) - Math.Abs(count_x) == 1)
                        {
                            solution[q] = "Down";
                            q++;
                            count_y++;
                        }
                        else
                        {
                            solution[q] = "Down";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_y) - Math.Abs(count_x)).ToString();
                            count_y = count_x;
                            q += 3;
                        }
                    }
                else if (Math.Abs(count_y) == Math.Max(Math.Abs(count_y), Math.Abs(count_x)) && count_x >= 0 && count_y <= 0)
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (Math.Abs(count_y) - Math.Abs(count_x) == 1)
                        {
                            solution[q] = "Down";
                            q++;
                            count_y++;
                        }
                        else
                        {
                            solution[q] = "Down";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_y) - Math.Abs(count_x)).ToString();
                            count_y += Math.Abs(count_y) - Math.Abs(count_x);
                            q += 3;
                        }
                    }
                else if (Math.Abs(count_x) == Math.Max(Math.Abs(count_y), Math.Abs(count_x)) && count_x >= 0 && count_y <= 0)
                {
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (Math.Abs(count_x) - Math.Abs(count_y) == 1)
                        {
                            solution[q] = "Left";
                            q++;    
                            count_x--;
                        }
                        else
                        {
                            solution[q] = "Left";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_x) - Math.Abs(count_y)).ToString();
                            count_x -= Math.Abs(count_x) - Math.Abs(count_y);
                            q += 3;
                        }
                    }
                }
                else if (Math.Abs(count_y) == Math.Max(Math.Abs(count_y), Math.Abs(count_x)) && count_x <= 0 && count_y >= 0)
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (Math.Abs(count_y) - Math.Abs(count_x) == 1)
                        {
                            solution[q] = "Up";
                            q++;
                            count_y--;
                        }
                        else
                        {
                            solution[q] = "Up";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_y) - Math.Abs(count_x)).ToString();
                            count_y -= Math.Abs(count_y) - Math.Abs(count_x);
                            q += 3;
                        }
                    }
                else if (Math.Abs(count_x) == Math.Max(Math.Abs(count_y), Math.Abs(count_x)) && count_x <= 0 && count_y >= 0)
                {
                    while (Math.Abs(count_x) != Math.Abs(count_y))
                    {
                        if (Math.Abs(count_x) - Math.Abs(count_y) == 1)
                        {
                            solution[q] = "Right";
                            q++;
                            count_x++;
                        }
                        else
                        {
                            solution[q] = "Right";
                            solution[q + 1] = "for";
                            solution[q + 2] = (Math.Abs(count_x) - Math.Abs(count_y)).ToString();
                            count_x += Math.Abs(count_x) - Math.Abs(count_y);
                            q += 3;
                        }
                    }
                }
            }
    }
    private void Generate()
    {
        {
            if (!Scenes.TryAgain)
            {
                KeyPositionX = RandomObjectGenerator.PosKX1;
                KeyPositionY = RandomObjectGenerator.PosKY1;
                PlayerPositionX = RandomObjectGenerator.PosPX1;
                PlayerPositionY = RandomObjectGenerator.PosPY1;
                DoorPositionX = RandomObjectGenerator.PosDX1;
                DoorPositionY = RandomObjectGenerator.PosDY1;
            }
            else
            {
                KeyPositionX = KPX;
                KeyPositionY = KPY;
                PlayerPositionX = PPX;
                PlayerPositionY = PPY;
                DoorPositionX = PDX;
                DoorPositionY = PDY;
            }
            KPX = KeyPositionX;
            KPY = KeyPositionY;
            PPX = PlayerPositionX;
            PPY = PlayerPositionY;
            PDX = DoorPositionX;
            PDY = DoorPositionY;
            for (int j = 0; j < 2; j++)
            {

                if (asd == 0)
                {
                    Node Key1 = new Node((int)Math.Round((9.5 + KeyPositionX) / speed), (int)Math.Round((9.5 + (-KeyPositionY)) / speed));
                    Node Player = new Node((int)Math.Round((9.5 + PlayerPositionX) / speed), (int)Math.Round((9.5 + (-PlayerPositionY)) / speed));
                    Move = AStar.FindPath(mas, Player, Key1);
                    for (int i = 0; i < (Move.Count - 1); i++)
                    {
                        if (Move[i].x - Move[i + 1].x > 0) { count_x++; } // Y направлен вверх; Х направлен влево
                        if (Move[i].y - Move[i + 1].y > 0) { count_y++; }
                        if (Move[i].x - Move[i + 1].x < 0) { count_x--; }
                        if (Move[i].y - Move[i + 1].y < 0) { count_y--; }
                    }
                    Solution(count_x, count_y);
                    solution[q] = "Pick";
                    q++;
                    count_x = 0;
                    count_y = 0;
                    CX = KeyPositionX;
                    CY = KeyPositionY;
                    asd++;
                }
                else
                {
                    Node Door1 = new Node((int)Math.Round((9.5 + DoorPositionX) / speed), (int)Math.Round((9.5 + (-DoorPositionY)) / speed));
                    Node Player = new Node((int)Math.Round((9.5 + CX) / speed), (int)Math.Round((9.5 + (-CY)) / speed));
                    Move = AStar.FindPath(mas, Player, Door1);
                    for (int i = 0; i < (Move.Count - 1); i++)
                    {
                        if (Move[i].x - Move[i + 1].x > 0) { count_x++; } // Y направлен вверх; Х направлен влево
                        if (Move[i].y - Move[i + 1].y > 0) { count_y++; }
                        if (Move[i].x - Move[i + 1].x < 0) { count_x--; }
                        if (Move[i].y - Move[i + 1].y < 0) { count_y--; }
                    }
                    Solution(count_x, count_y);
                    if (!solution.Contains("OpenTheDoor"))
                    {
                        solution[q] = "OpenTheDoor";
                    }
                    q++;
                    count_x = 0;
                    count_y = 0;
                    while (solution[w] != null)
                    {
                        w++;
                    }
                }
            }
        }
    }
    public void StopUpdate()
    {
        isUpdateEnabled = false;
    }
    /// <summary>
    /// //////////////////////////////
    /// </summary>
    private void Start()
    {
        RandomObjectGenerator randomObjectGenerator = GetComponent<RandomObjectGenerator>();
        randomObjectGenerator.GenerateRandomObjects();
    }   
    //private void Start()
    //{
    //    if (!Scenes.TryAgain)
    //    {
    //        KeyPositionX = RandomObjectGenerator.PosKX1;
    //        KeyPositionY = RandomObjectGenerator.PosKY1;
    //        PlayerPositionX = RandomObjectGenerator.PosPX1;
    //        PlayerPositionY = RandomObjectGenerator.PosPY1;
    //    }
    //    else
    //    {
    //        KeyPositionX = KPX;
    //        KeyPositionY = KPY;
    //        PlayerPositionX = PPX;
    //        PlayerPositionY = PPY;

    //    }
    //    KPX = KeyPositionX;
    //    KPY = KeyPositionY;
    //    PPX = PlayerPositionX;
    //    PPY = PlayerPositionY;
    //    for (int j = 0; j < 2; j++)
    //    {

    //        if (asd == 0)
    //        {
    //            Key = GameObject.FindGameObjectWithTag("Key");// ???????    ????????????????????????????????????????????????????????
    //            Node Key1 = new Node((int)Math.Round((9.5 + KeyPositionX) / 3.8), (int)Math.Round((9.5 + (-KeyPositionY)) / 3.8));
    //            Node Player = new Node((int)Math.Round((9.5 + PlayerPositionX) / 3.8), (int)Math.Round((9.5 + (-PlayerPositionY)) / 3.8));
    //            Move = AStar.FindPath(mas, Player, Key1);
    //            for (int i = 0; i < (Move.Count - 1); i++)
    //            {
    //                if (Move[i].x - Move[i + 1].x > 0) { count_x++; } // Y направлен вверх; Х направлен влево
    //                if (Move[i].y - Move[i + 1].y > 0) { count_y++; }
    //                if (Move[i].x - Move[i + 1].x < 0) { count_x--; }
    //                if (Move[i].y - Move[i + 1].y < 0) { count_y--; }
    //            }
    //            Solution(count_x, count_y);
    //            solution[q] = "Pick";
    //            q++;
    //            count_x = 0;
    //            count_y = 0;
    //            CX = KeyPositionX;
    //            CY = KeyPositionY;
    //            asd++;
    //        }
    //        else
    //        {
    //            Door = GameObject.FindGameObjectWithTag("Door");
    //            Node Door1 = new Node((int)Math.Round((9.5 + GivePositionDoor.PosX1) / 3.8), (int)Math.Round((9.5 + (-GivePositionDoor.PosY1)) / 3.8));
    //            Node Player = new Node((int)Math.Round((9.5 + CX) / 3.8), (int)Math.Round((9.5 + (-CY)) / 3.8));
    //            Move = AStar.FindPath(mas, Player, Door1);
    //            for (int i = 0; i < (Move.Count - 1); i++)
    //            {
    //                if (Move[i].x - Move[i + 1].x > 0) { count_x++; } // Y направлен вверх; Х направлен влево
    //                if (Move[i].y - Move[i + 1].y > 0) { count_y++; }
    //                if (Move[i].x - Move[i + 1].x < 0) { count_x--; }
    //                if (Move[i].y - Move[i + 1].y < 0) { count_y--; }
    //            }
    //            Solution(count_x, count_y);
    //            solution[q] = "OpenTheDoor";
    //            q++;
    //            count_x = 0;
    //            count_y = 0;
    //            while (solution[w] != null)
    //            {
    //                w++;
    //            }
    //        }
    //    }
    //}
    private void Update()
    {

        //if (Scenes.Generation)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        arr[i] = null;
        //        solution[i] = null;
        //    }
        //    Key = GameObject.Find("Key");
        //    Player = GameObject.Find("Player");
        //    Destroy(Key);
        //    Destroy(Player);
        //    q = 0;
        //    WithKey = false;
        //    OpenDoor = false;
        //    Scenes.Generation = false;
        //    asd = 0;
        //    j = 0;
        //    Generate();
        //}
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        Vector3 objectPosition = transform.position;
            //if (Input.GetKeyDown(KeyCode.Z))
            //{
            //    showConsole = !showConsole;
            //    if (showConsole)
            //    { 
            //        currentInput = "";
            //        output = "Console Opened";
            //    }
            //    else
            //    {
            //        output = "";
            //    }
            //}

            if (showConsole)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) // Обработка ввода команды по нажатию Enter
                {
                    ProcessCommand(currentInput);
                    currentInput = "";
                }
                else if (Input.GetKeyDown(KeyCode.Backspace) && currentInput.Length > 0) // Удаление символов по нажатию Backspace
                {
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                }
                else
                {
                    foreach (char c in Input.inputString)
                    {
                        if (c == "\b"[0]) // Игнорируем символы, такие как Backspace вводимые пользователем
                        {
                            if (currentInput.Length != 0)
                            {
                                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                            }
                        }
                        else if (c == "\n"[0] || c == "\r"[0]) // Ввод команды по нажатию Enter
                        {
                            ProcessCommand(currentInput);
                            currentInput = "";
                        }
                        else
                        {
                            currentInput += c; // Добавление символов к строке ввода
                        }
                    }
                }
            }
    }
    private void Complite()
    {
        if (Code || Borders || ODoor || LongCode)
        {
            SceneManager.LoadScene("LoseWindow");
        }
        Generate();
        int i = 0;
        if (beg)
            i++;
        while (i < j)
        {
            Border();
            if (arr[i + 1] == "and")
            {
                    switch (arr[i])
                    {
                        case "Up":
                            if (arr[i + 3] == "for")
                            {
                                for (int w = 0; w < Int32.Parse(arr[i + 4]); w++)
                                {
                                    move();
                                    PlayerPositionY += speed;
                                }
                                i += 2;
                                break;
                            }
                            else
                            {
                                PlayerPositionY += speed;
                                move();
                                i++;
                                break;
                            }
                        case "Down":
                            if (arr[i + 3] == "for")
                            {
                                for (int w = 0; w < Int32.Parse(arr[i + 4]); w++)
                                {
                                    move();
                                    PlayerPositionY -= speed;
                                }
                                i += 2;
                                break;
                            }
                            else
                            {
                                PlayerPositionY -= speed;
                                move();
                                i++;
                                break;
                            }
                        case "Right":
                            if (arr[i + 3] == "for")
                            {
                                for (int w = 0; w < Int32.Parse(arr[i + 4]); w++)
                                {
                                    move();
                                    PlayerPositionX += speed;
                                }
                                i += 2;
                                break;
                            }
                            else
                            {
                                PlayerPositionX += speed;
                                move();
                                i++;
                                break;
                            }
                        case "Left":
                            if (arr[i + 3] == "for")
                            {
                                for (int w = 0; w < Int32.Parse(arr[i + 4]); w++)
                                {
                                    move();
                                    PlayerPositionX -= speed;
                                }
                                i += 2;
                                break;
                            }
                            else
                            {
                                PlayerPositionX -= speed;
                                move();
                                i++;
                                break;
                            }
                     default:
                        {
                            Code = true;
                            SceneManager.LoadScene("LoseWindow");
                            i++;
                            break;
                        }
                }
            }
            else
                switch (arr[i])
                {
                    case "Up":
                        if (arr[i + 1] == "for")
                        {
                            for (int w = 0; w < Int32.Parse(arr[i + 2]); w++)
                            {
                                move();
                                PlayerPositionY += speed;
                            }
                            i += 3;
                            break;
                        }
                        else
                        {
                            PlayerPositionY += speed;
                            move();
                            i++;
                            break;
                        }
                    case "Down":
                        if (arr[i + 1] == "for")
                        {
                            for (int w = 0; w < Int32.Parse(arr[i + 2]); w++)
                            {
                                move();
                                PlayerPositionY -= speed;
                            }
                            i += 3;
                            break;
                        }
                        else
                        {
                            PlayerPositionY -= speed;
                            move();
                            i++;
                            break;
                        }
                    case "Right":
                        if (arr[i + 1] == "for")
                        {
                            for (int w = 0; w < Int32.Parse(arr[i + 2]); w++)
                            {
                                move();
                                PlayerPositionX += speed;
                            }
                            i += 3;
                            break;
                        }
                        else
                        {
                            PlayerPositionX += speed;
                            move();
                            i++;
                            break;
                        }
                    case "Left":
                        if (arr[i + 1] == "for")
                        {
                            for (int w = 0; w < Int32.Parse(arr[i + 2]); w++)
                            {
                                move();
                                PlayerPositionX -= speed;
                            }
                            i += 3;
                            break;
                        }
                        else
                        {
                            PlayerPositionX -= speed;
                            move();
                            i++;
                            break;
                        }
                    case "Pick":
                        {
                            if (KeyPositionX == PlayerPositionX && KeyPositionY == PlayerPositionY)
                            {
                                Destroy(Key);
                                WithKey = true;
                            }
                            i++;
                            break;
                        }
                    case "OpenTheDoor":
                        {
                            if (WithKey && PlayerPositionX == DoorPositionX && PlayerPositionY == DoorPositionY)
                            {
                                OpenDoor = true;
                                if (arr[w] != null)
                                {
                                    LongCode = true;
                                    SceneManager.LoadScene("LoseWindow");
                                    return;
                                }
                                else
                                {
                                    SceneManager.LoadScene("YouWin");
                                    return;
                                }
                            }
                            i++;
                            break;
                        }
                    default:
                        {
                            Code = true;
                            SceneManager.LoadScene("LoseWindow");
                            i++;
                            break;
                        }
                }
        }
        Border();
    }
    private void ProcessCommand(string command)
    {
        output += "\n" + command;
        if (command != "" && command != "End")
        {
            if (beg)
            {
                arr[j] = command;
                j++;
            }
            else if (command == "Begin")
            {
                beg = true;
                arr[j] = command;
                j++;
            }
        }
        else if (command == "End")
        {
            StartCoroutine(Wait());
            Complite();
        }
    }
    private void OnGUI()
    {
        if (showConsole)
        {
            GUI.TextArea(new Rect(0, Screen.height - 290, 270, 300), output + "\n> " + currentInput); //fix
        }
    }
}
