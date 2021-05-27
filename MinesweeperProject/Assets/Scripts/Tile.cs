using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileKind
    {
        Blank,
        Mine,
        Clue
    }

    public TileKind tileKind = TileKind.Blank; 
}
