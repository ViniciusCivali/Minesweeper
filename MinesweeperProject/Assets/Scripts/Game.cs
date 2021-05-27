using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //CRIAR ESTRUCTS DE ACORDO COM AS DIFICULDADES, JÁ CONTERNDO AS INFORMAÇÕES DO TAMANHO DO CAMPO, QUANTIDADE DE BOMBAS.

    //Grid which represent our board
    public GameObject[,] grid = new GameObject[9, 9];

    //Start is called before the first frame update
    void Start()
    {
        PlaceMines(10);
        PlaceClues();
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
    private void PlaceMines(int nMines)
    {
        if((grid.GetLength(0) * grid.GetLength(1)) >= nMines)
        {
            int i = 0;
            while (i < nMines)
            {
                //fazer uma chacagem para quantidade de espaços que há para se colocar minas; Evitar loop infinito

                int x = UnityEngine.Random.Range(0, 9);
                int y = UnityEngine.Random.Range(0, 9);

                if (grid[x, y] == null)
                {
                    GameObject mineTile = Instantiate(Resources.Load("Prefabs/mine", typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;

                    grid[x, y] = mineTile;

                    Debug.Log("(" + x + ", " + y + ")");

                    i++;
                }
            }
        }
        else
        {
            Debug.Log("More mines selected than number of fields");
        }

    }

    private void PlaceClues()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (null == grid[x,y])
                {
                    //Nothing is here, can't be a mine...
                    int nMines = 0;

                    //North
                    if (y+1 <9)
                    {
                        if (grid[x, y+1] != null)
                        {
                            nMines++;
                        }
                    }

                    //NorthEast
                    if (x+1 < 9 && y+1 < 9)
                    {
                        if (grid[x+1, y+1] != null)
                        {
                            nMines++;
                        }
                    }
                    
                    //East
                    if (x+1 < 9)
                    {
                        if (grid[x+1, y] != null)
                        {
                            nMines++;
                        }
                    }

                    //EastSouth
                    if (x+1 < 9 && y-1 >= 0)
                    {
                        if (grid[x+1, y-1] != null)
                        {
                            nMines++;
                        }
                    }
                    //South
                    if (y-1 >= 0)
                    {
                        if (grid[x, y-1] != null)
                        {
                            nMines++;
                        }
                    }
                    
                    //SouthWest
                    if (x-1 >= 0 && y-1 >= 0)
                    {
                        if (grid[x-1, y-1] != null)
                        {
                            nMines++;
                        }
                    }
                    
                    //West
                    if (x-1 >= 0)
                    {
                        if (grid[x-1, y] != null)
                        {
                            nMines++;
                        }
                    }
                    
                    //WestNorth
                    if (x-1 >= 0 && y+1 < 9)
                    {
                        if (grid[x-1, y+1] != null)
                        {
                            nMines++;
                        }
                    }

                    if (nMines > 0)
                    {
                        GameObject clueTile = Instantiate(Resources.Load("Prefabs/" + nMines, typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                    }
                }
            }
        }
    }
}
