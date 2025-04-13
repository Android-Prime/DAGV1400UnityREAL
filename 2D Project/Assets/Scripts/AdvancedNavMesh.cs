using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicNavMeshAgent : MonoBehaviour
{
    public string targetTag = "Target";
    public float updateInterval = 2f; // 

    private NavMeshAgent agent;
    private List<Transform> targets = new List<Transform>();
    private int currentTargetIndex = 0;
    private float nextUpdateTime = 0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        UpdateTargetList();
        SetNextDestination();
    }

    private void Update()
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateTargetList();
            nextUpdateTime = Time.time + updateInterval;
        }

        if (targets.Count == 0) return;

        // Check if we've reached the current destination
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            GoToNextTarget();
        }
    }

    private void UpdateTargetList()
    {
        GameObject[] foundTargets = GameObject.FindGameObjectsWithTag(targetTag);
        targets.Clear();

        foreach (GameObject obj in foundTargets)
        {
            if (obj != null)
                targets.Add(obj.transform);
        }

        // Reset current index if needed
        if (currentTargetIndex >= targets.Count)
        {
            currentTargetIndex = 0;
        }
    }

    private void SetNextDestination()
    {
        if (targets.Count > 0)
        {
            agent.SetDestination(targets[currentTargetIndex].position);
        }
    }

    private void GoToNextTarget()
    {
        currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        SetNextDestination();
    }
}