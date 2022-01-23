using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds the graph
/// </summary>
public class GraphBuilder : MonoBehaviour
{
    static Graph<Waypoint> graph = new Graph<Waypoint>();

    #region Constructor

    // Uncomment the code below after copying this class into the console
    // app for the automated grader. DON'T uncomment it now; it won't
    // compile in a Unity project

    /// <summary>
    /// Constructor
    /// 
    /// Note: The GraphBuilder class in the Unity solution doesn't 
    /// use a constructor; this constructor is to support automated grading
    /// </summary>
    /// <param name="gameObject">the game object the script is attached to</param>
    //public GraphBuilder(GameObject gameObject) :
    //    base(gameObject)
    //{
    //}

    #endregion

    /// <summary>
    /// Awake is called before Start
    ///
    /// Note: Leave this method public to support automated grading
    /// </summary>
    public void Awake()
    {
        // add nodes (all waypoints, including start and end) to graph
        foreach (Transform child in transform)
        {
            var currentWaypoint = child.GetComponent<Waypoint>();
            graph.AddNode(currentWaypoint);

            switch (currentWaypoint.Id)
            {
                case 0:
                    graph.Start = currentWaypoint;
                    break;
                case 31:
                    graph.Finish = currentWaypoint;
                    break;
            }
        }

        // add neighbors for each node in graph
        foreach (GraphNode<Waypoint> firstNode in graph.Nodes)
        {
            foreach (GraphNode<Waypoint> secondNode in graph.Nodes)
            {
                if (firstNode != secondNode &&
                    Mathf.Abs(firstNode.Value.Position.x - secondNode.Value.Position.x) <= 3.5f &&
                    Mathf.Abs(firstNode.Value.Position.y - secondNode.Value.Position.y) <= 3.0f)
                {
                    firstNode.AddNeighbor(secondNode,
                        Vector3.Distance(firstNode.Value.Position, secondNode.Value.Position));
                }
            }
        }
    }

    /// <summary>
    /// Gets and sets the graph
    /// 
    /// CAUTION: Set should only be used by the autograder
    /// </summary>
    /// <value>graph</value>
    public static Graph<Waypoint> Graph
    {
        get { return graph; }
        set { graph = value; }
    }
}
