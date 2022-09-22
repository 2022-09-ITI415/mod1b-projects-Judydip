using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.p
        Vector3 mousePos3D = Camera.main.Screen
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        void OnCollisionEnter (Collision coll)
        {
            GameObject collidedWith = coll.gameObject{
                if (collidedWith.tag == "Apple")
                {
                    Destroy(collidedWith);
                }
            }
        }
    }
}
