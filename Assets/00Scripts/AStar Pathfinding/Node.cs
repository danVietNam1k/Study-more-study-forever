using System.Collections.Generic;

using UnityEngine;

public class Node : MonoBehaviour
{
    [Header("Node Information")]
    public float gCost;
    public float hCost;
    public float fcost => gCost + hCost;
    public Node previousNode;
    public List<Node> neighbors = new();
    public bool isObstacle;
}
