using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;
    float translate = 0;
    [SerializeField]
    float steerSpeed = 250f;
    float rotate = 0;
    [SerializeField]
    float slowSpeed = 5f;
    [SerializeField]
    float boostSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rotate = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        translate = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0, -rotate);
        transform.Translate(0, translate, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bump")
        {
            moveSpeed = slowSpeed;
        }
    }
  

}
