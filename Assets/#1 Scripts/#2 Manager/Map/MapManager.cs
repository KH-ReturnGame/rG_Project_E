using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager :MonoBehaviour
{
    [SerializeField] Vector2Int mapSize;
    [SerializeField] float minimumDevideRate;
    [SerializeField] float maximumDivideRate;
    [SerializeField] private int maximumDepth;
    [SerializeField] Tilemap tileMap; 
    [SerializeField] Tile[] roomTile;
    [SerializeField] Tile[] wallTile;
    [SerializeField] Tile[] outTile;
    [SerializeField] Tile[] trapTile; // 함정을 나타내는 타일 추가
    int type;
    
    void Start()
    {   
        MakeMap(0);
    }
    
    void FillBackground()
    {
        for(int i = -10; i < mapSize.x + 10; i++)
        {
            for(int j = -10; j < mapSize.y + 10; j++)
            {
                tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), outTile[type]);
            }
        }
    }
    
    void FillWall()
    {      
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
               if(tileMap.GetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0)) == outTile[type])
                {
                    for(int x = -1; x <= 1; x++)
                    {
                        for(int y = -1; y <= 1; y++)
                        {
                            if (x == 0 && y == 0) continue;
                            if(tileMap.GetTile(new Vector3Int(i - mapSize.x / 2+x, j - mapSize.y / 2+y, 0)) == roomTile[type])
                            {
                                tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0) , wallTile[type]);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
    
    void Divide(Node tree,int n)
    {
        if (n == maximumDepth) return;

        int maxLength = Mathf.Max(tree.nodeRect.width, tree.nodeRect.height);
        int split = Mathf.RoundToInt(Random.Range(maxLength * minimumDevideRate, maxLength * maximumDivideRate));
        
        if (tree.nodeRect.width >= tree.nodeRect.height)
        {
            tree.leftNode = new Node(new RectInt(tree.nodeRect.x,tree.nodeRect.y,split,tree.nodeRect.height));
            tree.rightNode= new Node(new RectInt(tree.nodeRect.x+split, tree.nodeRect.y, tree.nodeRect.width-split, tree.nodeRect.height));
        }
        else
        {
            tree.leftNode = new Node(new RectInt(tree.nodeRect.x, tree.nodeRect.y, tree.nodeRect.width,split));
            tree.rightNode = new Node(new RectInt(tree.nodeRect.x, tree.nodeRect.y + split, tree.nodeRect.width , tree.nodeRect.height-split));
        }
        
        tree.leftNode.parNode = tree;
        tree.rightNode.parNode = tree;
        Divide(tree.leftNode, n + 1);
        Divide(tree.rightNode, n + 1);
    }
    
    private RectInt GenerateRoom(Node tree,int n)
    {
        RectInt rect;
        if (n == maximumDepth)
        {
           rect = tree.nodeRect;
            int width = Random.Range(rect.width / 2, rect.width - 1);
            int height = Random.Range(rect.height / 2, rect.height - 1);
            int x = rect.x + Random.Range(1, rect.width - width);
            int y = rect.y + Random.Range(1, rect.height - height);        
           rect = new RectInt(x, y, width, height);
           FillRoom(rect); 
        }
        else
        {
            tree.leftNode.roomRect = GenerateRoom(tree.leftNode,n+1);
            tree.rightNode.roomRect = GenerateRoom(tree.rightNode, n + 1);
            rect = tree.leftNode.roomRect;
        }
        return rect;
    }
    
    private void FillRoom(RectInt rect) {
        for(int i = rect.x; i < rect.x + rect.width; i++)
        {
            for(int j = rect.y; j < rect.y + rect.height; j++)
            {
                tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), roomTile[type]);
            }
        }

        // 방에 랜덤으로 함정 배치
        int trapCount = Random.Range(1, 4); // 방당 최소 1개, 최대 3개의 함정 배치
        for (int k = 0; k < trapCount; k++)
        {
            int trapX = Random.Range(rect.x, rect.x + rect.width);
            int trapY = Random.Range(rect.y, rect.y + rect.height);

            // 함정 타일을 방 내부의 랜덤 위치에 배치
            tileMap.SetTile(new Vector3Int(trapX - mapSize.x / 2, trapY - mapSize.y / 2, 0), trapTile[type]);
        }
    }

    private void GenerateLoad(Node tree,int n)
    {
        if (n == maximumDepth)
            return;
        
        Vector2Int leftNodeCenter = tree.leftNode.center;
        Vector2Int rightNodeCenter = tree.rightNode.center;      
       
        for (int i=Mathf.Min(leftNodeCenter.x, rightNodeCenter.x); i <= Mathf.Max(leftNodeCenter.x, rightNodeCenter.x); i++)
        {
            tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, leftNodeCenter.y - mapSize.y / 2, 0), roomTile[type]);
        }

        for (int j = Mathf.Min(leftNodeCenter.y, rightNodeCenter.y); j <= Mathf.Max(leftNodeCenter.y, rightNodeCenter.y); j++)
        {
            tileMap.SetTile(new Vector3Int(rightNodeCenter.x - mapSize.x / 2, j - mapSize.y / 2, 0), roomTile[type]);
        }
        
        GenerateLoad(tree.leftNode, n + 1);
        GenerateLoad(tree.rightNode, n + 1);
    }
    
    public void MakeMap(int i)
    {
        type = i;
        FillBackground();
        Node root = new Node(new RectInt(0, 0, mapSize.x, mapSize.y));
        Divide(root, 0);
        GenerateRoom(root, 0);
        GenerateLoad(root, 0);
        FillWall();
    }
}
