using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    //bool hasCrashed;

    [SerializeField]
    float destroyDelay = 0.5f;
    [SerializeField]
    Color32 pickedPackageColor = new Color32(0,1,0,1);
    [SerializeField]
    Color32 deliveredPackageColor = new Color32(1,1,1,1);
    // [SerializeField]
    // Color32 crashedColor = new Color32(1, 0, 0, 1);
    SpriteRenderer carSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        hasPackage = false;
        // hasCrashed = false;
        carSpriteRenderer = GetComponent<SpriteRenderer>();
        carSpriteRenderer.color = deliveredPackageColor;
    }

    // Update is called once per frame
    void Update()
    {
        //if(hasCrashed)
        //{
        //    carSpriteRenderer.color = deliveredPackageColor;
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
        //carSpriteRenderer.color = crashedColor;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package collected");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
            carSpriteRenderer.color = pickedPackageColor;
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            carSpriteRenderer.color = deliveredPackageColor;

        }
    }
}
