// Tested in unity editor and Oculus Quest
// Copyright (c) TeamCharlie @swanseauniversity. All rights reserved.
// Dated: 26/01/2023
// This script is used to count the waste put into the bin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 targetPosition;
    private ParticleSystem splashParticleSystem;
    private Coroutine pourRoutine;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        splashParticleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    public void BeginStream()
    {
        pourRoutine = StartCoroutine(BeinPouring());
        StartCoroutine(UpdateParticle());
    }

    private IEnumerator BeinPouring()
    {
        while (gameObject.activeSelf)
        {
            targetPosition = FindEndPointOfSTream();

            MoveToPosition(0, transform.position);
            MoveToPosition(1, targetPosition);

            AnimatePosition(1, targetPosition);

            yield return null;
        }
    }

    public void End()
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPouring());
    }

    private IEnumerator EndPouring()
    {
        while (!HasReachedPosition(0, targetPosition))
        {
            AnimatePosition(0, targetPosition);
            AnimatePosition(1, targetPosition);
            yield return null;
        }

        Destroy(gameObject);
    }

    private Vector3 FindEndPointOfSTream()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out hit, 10.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 targetPosition)
    {
        lineRenderer.SetPosition(index, targetPosition);
    }

    private void AnimatePosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPoint = lineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
        lineRenderer.SetPosition(index, newPosition);
    }

    private bool HasReachedPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = lineRenderer.GetPosition(index);
        return currentPosition == targetPosition;
    }

    private IEnumerator UpdateParticle()
    {
        while (gameObject.activeSelf)
        {
            splashParticleSystem.gameObject.transform.position = targetPosition;
            bool isHitting = HasReachedPosition(1, targetPosition);
            splashParticleSystem.gameObject.SetActive(isHitting);
            yield return null;
        }
    }
}
