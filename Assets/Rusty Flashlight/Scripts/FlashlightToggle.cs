using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

using UnityEngine.XR.Interaction.Toolkit;
public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    private bool isOn = false; //is flashlight on or off?
    XRGrabInteractable grabbable;
    Vector3 pos;
    // Use this for initialization
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(ISON);
        //set default off
        lightGO.SetActive(isOn);
        
    }

    // Update is called once per frame

    public void ISON(ActivateEventArgs arg){
        

        //toggle light
        isOn = !isOn;
        //turn light on
        if (isOn)
        {
            lightGO.SetActive(true);
        }
        //turn light off
        else
        {
            lightGO.SetActive(false);

        }
        

    }

    void Update()
    {
        pos = this.gameObject.transform.position;
        if (pos.y<4.1 || pos.z<38||pos.z>40||pos.x<33.8||pos.x>34.65){
            transform.position = new Vector3(34.143f,4.29f,39.388f);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        
        // if (OVRInput.GetDown(OVRInput.Button.Three) && grabbable.isSelected ){
        //    //toggle light
        //     isOn = !isOn;
        //     //turn light on
        //     if (isOn)
        //     {
        //         lightGO.SetActive(true);
        //     }
        //     //turn light off
        //     else
        //     {
        //         lightGO.SetActive(false);

        //     } 
        // }
        
    }
}
