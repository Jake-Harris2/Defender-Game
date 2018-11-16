﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMotor : MonoBehaviour
{

    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Transform cameraTransforms;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerRenderer;
    private float verticalMovementSpeed = 8f;
    private float cameraMovementSpeed = 20f;
    private float currentCameraMovementSpeed;
    private float movementLerpAmount;
    private Vector2 cameraCenter;
    private float acceleration = 5f;
    private bool lastMovingRight;


    void Start ()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        movementLerpAmount = gameCamera.pixelWidth / 2f * 0.8f;
        cameraCenter = new Vector2(gameCamera.pixelWidth / 2f, gameCamera.pixelHeight / 2f);
        playerRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {

        float horizontalInput = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        float verticalInput = Mathf.Round(Input.GetAxisRaw("Vertical"));

        Vector3 cameraMovement = Vector3.zero;

        transform.position = Vector2.Lerp(transform.position, new Vector2(gameCamera.transform.position.x, transform.position.y), cameraMovementSpeed/400f);

        if(lastMovingRight)
        {
            cameraMovement = Vector3.right * currentCameraMovementSpeed;
        }
        else
        {
            cameraMovement = Vector3.right * -currentCameraMovementSpeed;
        }

        cameraTransforms.position = cameraTransforms.position + cameraMovement * Time.deltaTime;

        if (horizontalInput != 0)
        {
            currentCameraMovementSpeed += acceleration * Time.deltaTime;
            if(currentCameraMovementSpeed > cameraMovementSpeed)
            {
                currentCameraMovementSpeed = cameraMovementSpeed;
            }
            if (horizontalInput > 0)
            {
                lastMovingRight = true;
                playerRenderer.flipX = false;
            }
            if (horizontalInput < 0)
            {
                lastMovingRight = false;
                playerRenderer.flipX = true;
            }
            playerAnimator.SetFloat("Input", Mathf.Abs(horizontalInput));
        }
        else
        {
            currentCameraMovementSpeed -= acceleration * Time.deltaTime;
            cameraMovement = Vector3.right * horizontalInput * currentCameraMovementSpeed;
            if (currentCameraMovementSpeed < 0)
            {
                currentCameraMovementSpeed = 0;
            }
            cameraTransforms.position = cameraTransforms.position + cameraMovement * Time.deltaTime;
            playerAnimator.SetFloat("Input", 0f);
        }

        Vector2 shipVerticalMovement = Vector2.zero;

        if (verticalInput != 0)
        {
            shipVerticalMovement = Vector2.up * verticalInput * verticalMovementSpeed;
            playerRigidbody.MovePosition(playerRigidbody.position + shipVerticalMovement * Time.deltaTime);
        }

	}

    public float GetBackgroundScrollSpeed()
    {
        Vector2 shipScreenPosition = gameCamera.WorldToScreenPoint(gameObject.transform.position);
        float shipScreenPercentage = (cameraCenter.x - shipScreenPosition.x) / gameCamera.pixelWidth;
        Debug.Log(shipScreenPercentage);
        float backgroundScrollingSpeed = 1 * shipScreenPercentage;
        return backgroundScrollingSpeed;
    }
}
