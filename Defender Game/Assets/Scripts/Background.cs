using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float backgroundScrollingSpeed;
    [SerializeField]
    float backgroundScrollMultiplier = 60f;

    Vector2 backgroundStartingPosition;

	void Start ()
    {
        backgroundStartingPosition = transform.position;  
	  }
	
	void Update ()
    {
        backgroundScrollingSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>().GetBackgroundScrollSpeed()*backgroundScrollMultiplier;
        float backgroundMovement = Mathf.Repeat(Time.time * 10, 53.46f);
        transform.position = backgroundStartingPosition + Vector2.right * backgroundMovement;
    }
}
