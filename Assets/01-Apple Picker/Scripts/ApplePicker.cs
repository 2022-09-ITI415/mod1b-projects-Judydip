using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
                Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
                tBasketGO.transform.position = pos;
        }
            public void AppleDestroyed()
        {
            GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject tGO in tAppleArray)
            {
                Destroy(tGO);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
