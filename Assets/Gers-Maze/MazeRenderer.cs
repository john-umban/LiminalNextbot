using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField] MazeGen mazeGen;
    [SerializeField] GameObject MazeCellPrefab;

    public float CellSize = 1f;
    private void Start() {
        MazeCell[,] maze = mazeGen.GetMaze();
        for (int x = 0; x < mazeGen.mazeWidth; x++)
        {
            for (int y = 0; y < mazeGen.mazeHeight; y++)
            {
                GameObject newCell = Instantiate(MazeCellPrefab, new Vector3((float)x * CellSize, 0f, (float)y * CellSize), Quaternion.identity, transform);
                MazeCellObject mazeCell = newCell.GetComponent<MazeCellObject>();
                bool top = maze[x, y].topWall;
                bool bottom = false;
                bool left = maze[x, y].leftWall;
                bool right = false;

                if (x == mazeGen.mazeWidth - 1) right = true;
                if (y == 0) bottom = true;

                mazeCell.Init(top, bottom, left, right);
            }
        }
    }
}
