using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
public class UnitMovement : MonoBehaviour
{

    // Where to go?
    private Vector2 targetPos;

    //Max distance between current pos. and target pos. when unit stops moving
    [SerializeField] private float maxDistance = 0.2f;

    // How many times each second we will update our path
    public float updateRate = 2f;

    // Caching
    private Seeker seeker;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 10f;

    [HideInInspector]
    public bool pathIsEnded = false;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();

        targetPos = transform.position;

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, targetPos, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if (targetPos == null)
        {
            yield return false;
        }

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, targetPos, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Sets new target pos
    public void SetTargetPos(Vector2 targetPos)
    {
        // Set new target pos
        this.targetPos = targetPos;
    }

    void FixedUpdate()
    {
        if (targetPos == null)
        {
            return;
        }

        if (path == null)
            return;

        // Current position of unit
        Vector2 currentPos = transform.position;

        // If distance between current pos. and target pos. is less than maxDistance
        // Stop!
        if ((currentPos - targetPos).magnitude < maxDistance)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        transform.Translate(dir);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

}