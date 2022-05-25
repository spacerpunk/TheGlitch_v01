using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloor : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    private Rigidbody2D myRigidBody;
    public BoxCollider2D myBoxCollider;
    public MusicSystem musicSystem;
    public BoxCollider2D destroyCollider;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-speed, myRigidBody.velocity.y);

        }
    }


    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            musicSystem.StemUP();
            Destroy(gameObject);
        }
    }

    

}
