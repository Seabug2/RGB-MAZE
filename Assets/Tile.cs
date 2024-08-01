using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Vector2[] dir = {
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0,-1)
    };

    /// <summary>
    /// 0 : red
    /// 1 : green
    /// 2 : blue
    /// </summary>
    public int[] doorNumbers;
    /// <summary>
    /// 0 : red
    /// 1 : green
    /// 2 : blue
    /// </summary>
    [Tooltip("red, green, blue")]
    public Transform[] doors;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        doorNumbers = new int[3];
        List<int> rand = new List<int> { 0, 1, 2, 3 };
        for (int i = 0; i < doorNumbers.Length; i++)
        {
            int r = rand[Random.Range(0, rand.Count)];
            rand.Remove(r);
            doorNumbers[i] = r;
            doors[i].position = transform.position + new Vector3(dir[r].x,0, dir[r].y) * .5f;
        }
    }

    /// <param name="angle"> 1 or -1</param>
    public void Rotate(int angle = 1)
    {
        transform.Rotate(0, 90 * angle, 0);
        RotateDoor(angle);
    }

    void RotateDoor(int i)
    {
        for (int j = 0; j < doorNumbers.Length; j++)
        {
            doorNumbers[j] = doorNumbers[j] + i;

            if (doorNumbers[j] < 0)
            {
                doorNumbers[j] = doorNumbers.Length;
            }
            else if (doorNumbers[j] > doorNumbers.Length)
            {
                doorNumbers[j] = 0;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rotate(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rotate(1);
        }
    }
}
