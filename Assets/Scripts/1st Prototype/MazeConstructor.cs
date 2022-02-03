using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    public bool ShowDebug;

    [SerializeField] private Material _material1;
    [SerializeField] private Material _material2;
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material _treasureMaterial;
    private MazeDataGenerator _dataGenerator;
    private MazeMeshGenerator _meshGenerator;

    public int[,] Data { get; private set;}
    public float HallWidth
    {
        get; private set;
    }
    public float HallHeight
    {
        get; private set;
    }

    public int StartRow
    {
        get; private set;
    }
    public int StartCol
    {
        get; private set;
    }

    public int GoalRow
    {
        get; private set;
    }
    public int GoalCol
    {
        get; private set;
    }

    private void Awake()
    {
        Data = new int[,]
        {
            {1, 1, 1},
            {1, 0, 1},
            {1, 1, 1}
        };
        _dataGenerator = new MazeDataGenerator();
        _meshGenerator = new MazeMeshGenerator();
    }

    public void GenerateNewMaze(int numRows, int numCols, TriggerEventHandler startCallback = null, TriggerEventHandler goalCallback = null)
    {
        if (numRows % 2 == 0 && numCols % 2 == 0)
        {
            Debug.LogError("Odd numbers work better for dungeon size.");
        }

        DisposeOldMaze();
        Data = _dataGenerator.FromDimensions(numRows, numCols);

        FindStartPosition();
        FindGoalPosition();

        HallWidth = _meshGenerator.Width;
        HallHeight = _meshGenerator.Height;

        DisplayMaze();

        PlaceStartTrigger(startCallback);
        PlaceGoalTrigger(goalCallback);
    }

    private void OnGUI()
    {
        if (!ShowDebug)
        {
            return;
        }

        GUI.Label(new Rect(20, 20, 500, 500), getOutputMap());
    }

    private string getOutputMap()
    {
        string outputMap = "";
        int[,] maze = Data;
        int maximumRows = maze.GetUpperBound(0);
        int maximumCols = maze.GetUpperBound(1);

        for (int i = maximumRows; i >= 0; i--)
        {
            for (int j = 0; j <= maximumCols; j++)
            {
                if (maze[i, j] == 0)
                {
                    outputMap += "....";
                }
                else
                {
                    outputMap += "==";
                }
            }
            outputMap += "\n";
        }
        return outputMap;
    }

    private void DisplayMaze()
    {
        GameObject dungeon = new GameObject();
        dungeon.transform.position = Vector3.zero;
        dungeon.name = "Procedural Maze";
        dungeon.tag = "Generated";

        MeshFilter filter = dungeon.AddComponent<MeshFilter>();
        filter.mesh = _meshGenerator.FromData(Data);

        MeshCollider collider = dungeon.AddComponent<MeshCollider>();
        collider.sharedMesh = filter.mesh;

        MeshRenderer render = dungeon.AddComponent<MeshRenderer>();
        render.materials = new Material[2] { _material1, _material2 };
    }

    public void DisposeOldMaze()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Generated");
        foreach (GameObject go in objects)
        {
            Destroy(go);
        }
    }

    private void FindStartPosition()
    {
        int[,] maze = Data;
        int maximumRows = maze.GetUpperBound(0);
        int maximumCols = maze.GetUpperBound(1);

        for(int i = 0; i <= maximumRows; i++)
        {
            for(int j = 0; j <= maximumCols; j++)
            {
                if(maze[i, j] == 0)
                {
                    StartRow = i;
                    StartCol = j;
                    return;
                }
            }
        }
    }

    private void FindGoalPosition()
    {
        int[,] maze = Data;
        int maximumRows = maze.GetUpperBound(0);
        int maximumCols = maze.GetUpperBound(1);

        for (int i = maximumRows; i >= 0; i--)
        {
            for (int j = maximumCols; j >= 0; j--)
            {
                if (maze[i, j] == 0)
                {
                    GoalRow = i;
                    GoalCol = j;
                    return;
                }
            }
        }
    }

    private void PlaceStartTrigger(TriggerEventHandler callback)
    {
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.transform.position = new Vector3(StartCol * HallWidth, 0.5f, StartRow * HallWidth);
        gameObject.name = "Start Pos";
        gameObject.tag = "Generated";

        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = _startMaterial;

        TriggerEventRouter eventRouter = gameObject.AddComponent<TriggerEventRouter>();
        eventRouter.callback = callback;
    }

    private void PlaceGoalTrigger(TriggerEventHandler callback)
    {
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.transform.position = new Vector3(GoalCol * HallWidth, 0.5f, GoalRow * HallWidth);
        gameObject.name = "Treasure";
        gameObject.tag = "Generated";

        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = _treasureMaterial;

        TriggerEventRouter eventRouter = gameObject.AddComponent<TriggerEventRouter>();
        eventRouter.callback = callback;
    }
}
