﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMotor : MonoBehaviour
{

    private Rigidbody2D playerRigidbody;
    private Camera gameCamera;
    private SpriteRenderer playerRenderer;

    private float movementSpeed = 3f;

    private float movementLerpAmount;
    private Vector2 cameraCenter;

	void Start ()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        gameCamera = FindObjectOfType<Camera>();
        movementLerpAmount = gameCamera.pixelWidth / 2f * 0.9f;
        cameraCenter = new Vector2(gameCamera.pixelWidth / 2f, gameCamera.pixelHeight / 2f);
        playerRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
        Vector2 shipVerticalMovement = Vector2.zero;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if(horizontalInput != 0)
        {
            Vector2 lerpPositionScreen = cameraCenter + new Vector2(movementLerpAmount * -horizontalInput, 0);
            Vector2 lerpPostionGame = gameCamera.ScreenToWorldPoint(lerpPositionScreen);
            transform.position = Vector2.Lerp(transform.position, new Vector2(lerpPostionGame.x, transform.position.y), 0.06f);
            if(horizontalInput > 0)
            {
                playerRenderer.flipX = false;
            }
            if(horizontalInput < 0)
            {
                playerRenderer.flipX = true;
            }
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(0,transform.position.y), 0.03f);
        }

        if(verticalInput != 0)
        {
            shipVerticalMovement = Vector2.up * verticalInput * movementSpeed;
            playerRigidbody.MovePosition(playerRigidbody.position + shipVerticalMovement * Time.deltaTime);
        }
	}
}
