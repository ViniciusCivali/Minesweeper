using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //Grid which represent our board
    public GameObject[,] grid = new GameObject[9, 9];

    //Start is called before the first frame update
    void Start()
    {
        PlaceMines(10);
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Function that place the nMines on the board (grid)
    /// </summary>
    /// <param name="nMines">
    ///     integer that represent the number of minas in the board
    /// </param>
    void PlaceMines(int nMines)
    {
        int i = 0;
        while(i < nMines)
        {
            //fazer uma chacagem para quantidade de espaços que há para se colocar mina; Evitar loop infinito

            int x = UnityEngine.Random.Range(0, 9);
            int y = UnityEngine.Random.Range(0, 9);

            if (grid[x, y] == null)
            {
                GameObject mineTile = Instantiate(Resources.Load("Prefabs/mine", typeof(GameObject)), new Vector3(x,y,0), Quaternion.identity) as GameObject;

                grid[x, y] = mineTile;

                Debug.Log("(" + x + ", " + y + ")");

                i++;
            }
        }
    }
}
