using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletspeed;
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * bulletspeed * Time.deltaTime;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ghoul")
        {
            Debug.LogFormat("#### ######, ####");
        }
    }
}


