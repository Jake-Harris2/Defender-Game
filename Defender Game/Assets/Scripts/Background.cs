using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float backgroundScrollingSpeed;
    [SerializeField]
    float backgroundScrollMultiplier = 60f;

    Rigidbody2D playerRigidbody;

	void Start ()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        backgroundScrollingSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>().GetBackgroundScrollSpeed()*backgroundScrollMultiplier;
        Debug.Log(backgroundScrollingSpeed);
        Vector2 backgroundMovement = Vector2.right * -backgroundScrollingSpeed;
        playerRigidbody.MovePosition(playerRigidbody.position + backgroundMovement * Time.deltaTime);
        //Create empty gameobjects to use onbecamevisible() to check for the end of the texture
    }
}
