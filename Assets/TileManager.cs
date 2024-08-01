using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Vector2 field = new Vector2();

    [SerializeField]Transform tile;

    private void Start()
    {
        for(int r = 0; r < field.x; r++)
        {
            for (int c = 0; c < field.y; c++)
            {
                Transform t = Instantiate(tile, new Vector3(c, 0, r), Quaternion.identity, transform);
            }
        }
    }
}
