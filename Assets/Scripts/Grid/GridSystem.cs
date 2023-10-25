using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// He thong luoi
/// Chua so hang va so cot
/// </summary>
public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;
   public GridSystem(int width,int height,float cellSize)
   {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width,height];

        for(int x =0; x < width; x++)
        {
            for(int z =0; z < height; z++)
            {
                //Debug.DrawLine(GetWorldPosition(x,z),GetWorldPosition(x,z)+ Vector3.right *.2f ,Color.white,1000);
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x,z] = new GridObject(this, gridPosition);
            }
        }
   }

    public Vector3 GetWorldPosition(GridPosition gridPosition)//lay toa do x,z thoi,khong phai toa do trong unity,co tinh den CellSize phuc vu cho viec ve thoi
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)//lay ra xem day la o thu bao nhieu(0,0) (1,1)...
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x /cellSize),
            Mathf.RoundToInt(worldPosition.z /cellSize)
            );
    }

    //Tạo ra hế thống lưới đánh số các ô 
    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab,GetWorldPosition(gridPosition),Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    //Trả về GridObject từ GridPosition 
    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x,gridPosition.z];
    }
}
