using System.Collections.Generic;
using UnityEngine;

public class PathfindingAStar : MonoBehaviour
{
    public static PathfindingAStar Instance;
    [Header("List in gameplay")]
    public List<Node> resultPath = new();
    public List<Node> frontierNodes = new();
    public List<Node> exploredNodes = new();
    [Header("Node in gameplay")]
    public Node player;
    public Node target;
    public Node currentNode;
    [Header("Node in gameplay")]
    public float timeStepShowResult;
    public float timeStepFindSlow;
    public float timeFind;

    private void Awake()
    {
        Instance = this;    
    }


}
