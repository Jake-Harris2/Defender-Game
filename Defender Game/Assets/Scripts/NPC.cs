using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float score;
    public float movementSpeed;
    public bool usesRandomMovement;

    private float directionChangeTimer;
    private float lastDirectionChange;

    private Vector2 randomMovement = Vector2.zero;

	void Start ()
    {
        lastDirectionChange = Time.time;
    }

    private void newDirection()
    {
        float randomHorizontal = Random.Range(-0.5f, 0.5f);
        if (randomHorizontal > 0)
        {
            randomHorizontal += 0.5f;
        }
        else
        {
            randomHorizontal -= 0.5f;
        }
        float randomVertical = Random.Range(-0.3f, 0.3f);
        randomMovement = new Vector2(randomHorizontal, randomVertical);
        lastDirectionChange = Time.time;
        directionChangeTimer = Random.Range(5f, 10f);
    }

	public virtual void Update ()
    {
        if(usesRandomMovement)
        {
            if (Time.time - lastDirectionChange > directionChangeTimer)
            {
                newDirection();
            }
            Vector2 tempLocalPosition = new Vector2(transform.localPosition.x, transform.localPosition.y) + (randomMovement * movementSpeed * Time.deltaTime);
            if (transform.parent.name == "Right" && tempLocalPosition.x > 40.96f)
            {
                tempLocalPosition.x = 40.96f;
            }
            if (transform.parent.name == "Left" && tempLocalPosition.x < -40.96f)
            {
                tempLocalPosition.x = -40.96f;
            }
            if(tempLocalPosition.y > 2.1f)
            {
                tempLocalPosition.y = 2.1f;
            }
            if (tempLocalPosition.y < -2.5f)
            {
                tempLocalPosition.y = -2.5f;
            }
            transform.localPosition = tempLocalPosition;
        }
    }
}

