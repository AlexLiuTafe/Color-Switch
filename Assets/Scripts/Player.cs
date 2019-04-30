using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Color[] colors = new Color[4];

    public Transform environment;

    private Vector3 originalPos;

    private Rigidbody2D rigid;
    private SpriteRenderer rend;
    public void Restart()
    {
        transform.position = originalPos;
        Stop();// stop the player from moving
    }

	public void Play()
    {
        //Enable RigidBody
        rigid.isKinematic = false;
    }
    public void Stop()
    {
        //Disable RigidBody
        rigid.isKinematic = true;
        //Remove any velocity
        rigid.velocity = Vector2.zero;
    }
    public void Jump()
    {
        // Reset velocity to flying up
        rigid.velocity = Vector2.up * jumpForce;
    }
	void Start ()
    {
        originalPos = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rigid.isKinematic)
        {
            return;
        }
        //Get player's position
        Vector3 position = transform.position;

        //if mouse button is down
        if (Input.GetButtonDown("Fire1"))
        {
            Jump();


        }
        if(rigid.isKinematic)
        {
            return;
        }
        // if posiiton goes higher than 0
        if(position.y >0f)
        {
            // Translate the environment the opposite way
            environment.Translate(new Vector3(0, -position.y, 0));
            //cap thae player's position
            position.y = 0f;

        }
        //apply player's position
        transform.position = position;
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Get the other object's SpriteRenderer
        SpriteRenderer otherRend = col.GetComponent<SpriteRenderer>();

        switch (col.tag)
        {
            case "ColorChanger":
                //randomize color
                int randomIndex = Random.Range(0, colors.Length);
                rend.color = colors[randomIndex];
                //Destroy the col gameobject
                Destroy(col.gameObject);
                break;

            case "ColorCircle":
                // if other color is not the same as our color
                if(otherRend.color != rend.color)
                {
                    //Game Over
                    print("Game Over");

                }
                break;
            default:
                break;
        }
    }
}
