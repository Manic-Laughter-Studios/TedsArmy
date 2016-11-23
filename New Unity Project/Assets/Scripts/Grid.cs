using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public int width, height;
    public float cellSize = 1;

    public GridCell[] cells;

    [ContextMenu("MakeGrid")]
    public void MakeGrid()
    {
        cells = new GridCell[width * height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var newGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newGO.transform.position = new Vector3(i * cellSize, 0, j * cellSize);
                newGO.transform.parent = transform;

                var gridCell = newGO.AddComponent<GridCell>();
                gridCell.myGrid = this;
                gridCell.x = i;
                gridCell.y = j;

                cells[i*height + j] = gridCell;
            }  
        }
        //make rows
            //make cols
    }

    public GridCell GetCellAtIndex(int x, int y)
    {
        if (x < 0 || y < 0 ||
            x >= width || y >= height)
            return null;

        return cells[x* height + y];
    }

	// Use this for initialization
	void Start ()
    {
        MakeGrid();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
