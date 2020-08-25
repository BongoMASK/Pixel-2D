using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrust;
    public float grav;
    int prevPosition;
    Vector2 moveSideways, moveUpwards, moveDownwards;
    bool gravity = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSideways = new Vector2(thrust, 0);
        moveUpwards = new Vector2(0, grav);
        moveDownwards = new Vector2(0, -grav);
        prevPosition = (int) transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        int position = (int) transform.position.x;
        //rb.velocity = moveDownwards * Time.deltaTime * thrust;
        if(Input.GetKeyDown(KeyCode.Space)) {
            //Gravity();
            rb.velocity = new Vector2(0,0);
            if(gravity == false) {
                gravity = true;
                rb.velocity = moveUpwards * Time.fixedDeltaTime + moveSideways * Time.fixedDeltaTime;
                Debug.Log(rb.velocity);
            }
            else {
                gravity = false;
                //grav = -100;
                rb.velocity = moveDownwards * Time.fixedDeltaTime + moveSideways * Time.fixedDeltaTime;
                Debug.Log(rb.velocity);
                //rb.AddForce(transform.up * grav);
            }
            Debug.Log(position - prevPosition);
        }
    }

    /*void Gravity() {
        if(gravity == true) {
            rb.AddForce(transform.up * thrust * -1f);
        }

        if(gravity = false) {
            rb.AddForce(transform.up * thrust);
        }
    }*/
    
    void OnTriggerEnter2D(Collider2D col) {
        
    }
}
