using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet(Clone)" || col.gameObject.name == "Bullet")
        {
            Debug.LogFormat("#### ######, ####");
            Destroy(col.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
