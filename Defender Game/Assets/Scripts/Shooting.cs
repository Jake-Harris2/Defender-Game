using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private float lastShootTime;
    private float shootingCooldown = 0.3f;
    private SpriteRenderer playerRenderer;
    private ParticleSystem particleSystem;

    [SerializeField]
    private Rigidbody2D projectilePrefab;
	
	void Start ()
    {
        lastShootTime = Time.time;
        playerRenderer = GetComponent<SpriteRenderer>();
	}

	void Update ()
    {
		if((Time.time - lastShootTime > shootingCooldown) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Space)))
        {
            Rigidbody2D projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as Rigidbody2D;
            if(playerRenderer.flipX)
            {
                projectileInstance.AddForce(new Vector2(-2000, 0));
            }
            else
            {
                projectileInstance.AddForce(new Vector2(2000, 0));
            }
            lastShootTime = Time.time;
        }
	}
}
