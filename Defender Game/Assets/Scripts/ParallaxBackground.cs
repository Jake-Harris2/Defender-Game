using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private float backgroundLength;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float parallaxSpeed;

    private Transform[] backgroundStates;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

	void Start ()
    {
        lastCameraX = cameraTransform.position.x;
        backgroundStates = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgroundStates[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = backgroundStates.Length - 1;
	}

	void Update ()
    {
        float cameraDeltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (cameraDeltaX * parallaxSpeed);
		if(cameraTransform.position.x < (backgroundStates[leftIndex].transform.position.x + viewZone))
        {
            ScrollLeft();
        }

        if (cameraTransform.position.x > (backgroundStates[rightIndex].transform.position.x - viewZone))
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        backgroundStates[rightIndex].position = Vector3.right * (backgroundStates[leftIndex].position.x - backgroundLength);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0)
        {
            rightIndex = backgroundStates.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        backgroundStates[leftIndex].position = Vector3.right * (backgroundStates[rightIndex].position.x + backgroundLength);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == backgroundStates.Length)
        {
            leftIndex = 0;
        }
    }
}
