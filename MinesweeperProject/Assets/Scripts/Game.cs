using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //CRIAR ESTRUCTS DE ACORDO COM AS DIFICULDADES, JÁ CONTERNDO AS INFORMAÇÕES DO TAMANHO DO CAMPO, QUANTIDADE DE BOMBAS.

    //Grid which represent our board
    public Tile[,] grid = new Tile[9, 9];

    //Start is called before the first frame update
    void Start()
    {
        PlaceMines(10);
        PlaceClues();
        PlaceBlanks();
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Function that place the nMines on the board (grid)
    /// </summary>
    /// <param name="nMines">
    ///     integer that represent the number of minas in the board, between the inclusive interval (82 > nMines > 0)
    /// </param>
    private void PlaceMines(int nMines)
    {
        if ( nMines > 0 && nMines <= ( grid.GetLength(0) * grid.GetLength(1) ) )
        {
            int i = 0;
            while (i < nMines)
            {

                int x = UnityEngine.Random.Range(0, 9);
                int y = UnityEngine.Random.Range(0, 9);

                if (grid[x, y] == null)
                {
                    Tile mineTile = Instantiate(Resources.Load("Prefabs/mine", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;

                    grid[x, y] = mineTile;

                    i++;
                }
            }
        }
        else
        {
            Debug.Log("Set the mines number between the inclusive interval (82 > nMines > 0)");
        }

    }

    /// <summary>
    /// Function that calculate and place the clues tiles in the board (grid)
    /// </summary>
    private void PlaceClues()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if ( null == grid[x, y] )
                {
                    //Nothing is here, can't be a mine...
                    int nMines = 0;

                    //North
                    if (y + 1 < 9)
                    {
                        if (grid[x, y + 1] != null && grid[x, y + 1].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }

                    //NorthEast
                    if (x + 1 < 9 && y + 1 < 9)
                    {
                        if (grid[x + 1, y + 1] != null && grid[x + 1, y + 1].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }

                    //East
                    if (x + 1 < 9)
                    {
                        if (grid[x + 1, y] != null && grid[x + 1, y].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }

                    //EastSouth
                    if (x + 1 < 9 && y - 1 >= 0)
                    {
                        if (grid[x + 1, y - 1] != null && grid[x + 1, y - 1].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }
                    //South
                    if (y - 1 >= 0)
                    {
                        if (grid[x, y - 1] != null && grid[x, y - 1].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }

                    //SouthWest
                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        if (grid[x - 1, y - 1] != null && grid[x - 1, y - 1].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }

                    //West
                    if (x - 1 >= 0)
                    {
                        if (grid[x - 1, y] != null && grid[x - 1, y].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }

                    //WestNorth
                    if (x - 1 >= 0 && y + 1 < 9)
                    {
                        if (grid[x - 1, y + 1] != null && grid[x - 1, y + 1].tileKind == Tile.TileKind.Mine)
                        {
                            nMines++;
                        }
                    }

                    if (nMines > 0)
                    {
                        Tile clueTile = Instantiate(Resources.Load("Prefabs/" + nMines, typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;

                        grid[x, y] = clueTile;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Function that place the blanks tile in the board (grid)
    /// </summary>
    private void PlaceBlanks()
    {
        for(int y = 0; y < 9; y++)
        {
            for(int x = 0; x < 9; x++)
            {
                if(grid[x, y] == null)
                {
                    Tile blankTile = Instantiate(Resources.Load("Prefabs/blank", typeof(Tile)), new Vector3(x, y, 0), Quaternion.identity) as Tile;

                    grid[x, y] = blankTile;
                }
            }
        }
    }
}
