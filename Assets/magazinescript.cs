using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazinescript : MonoBehaviour
{

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag =="magazinepoint"){
            transform.position = new Vector3(34.339f,4.292f,39.497f);

        }
        
    }
    // Update is called once per frame
    void Update()
    {

        pos = this.gameObject.transform.position;

        if (pos.y<4.2 || pos.z<38||pos.z>40||pos.x<34.1||pos.x>35.1){
            transform.position = new Vector3(34.339f,4.292f,39.497f);
        }
    }
}
