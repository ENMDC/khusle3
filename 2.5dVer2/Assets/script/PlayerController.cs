using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if ( Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0,-50f * Time.deltaTime,0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 50f * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(50f * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(-50f * Time.deltaTime, 0,0 );
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate( 0, 0,-speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0,  0,speed * Time.deltaTime);
            }
            float y = Input .GetAxis("JetPackMovement");
        Vector3 moveDir = new Vector3(0, -y, 0);
        rb.linearVelocity = moveDir * speed;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }

    }
}
