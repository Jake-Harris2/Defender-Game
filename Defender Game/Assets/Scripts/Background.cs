using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float backgroundScrollingSpeed;
    [SerializeField]
    float backgroundScrollMultiplier = 60f;

    private Renderer backgroundRenderer;

    Vector2 backgroundStartingPosition;

	void Start ()
    {
        backgroundRenderer = GetComponent<Renderer>();
	}
	
	void Update ()
    {
        backgroundScrollingSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>().GetBackgroundScrollSpeed()*backgroundScrollMultiplier;
        float backgroundMovement = backgroundScrollMultiplier * Time.time;
        Vector2 backgroundOffset = new Vector2(backgroundMovement, 0);
        //Debug.Log(backgroundScrollingSpeed);
        backgroundRenderer.material.mainTextureOffset = backgroundOffset;

        /*Vector2 backgroundMovement = Vector2.right * -backgroundScrollingSpeed;
        transform.position = new Vector2(transform.position.x, transform.position.y) + backgroundMovement * Time.deltaTime;*/
    }
}
