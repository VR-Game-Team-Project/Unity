using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FireBulletOnValidate : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPoint;
    public Transform triggerPoint;

    Vector3 pos;
    public AudioClip shotsound;

    public int magazine_num =40;
    AudioSource audioSource;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        
    }
    private void OnTriggerEnter(Collider other) {
        //Trigger Point와의 collider로 변경
        if (other.gameObject.tag =="magazine"){
            magazine_num = 40;

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        pos = this.gameObject.transform.position;
        if (pos.y<4.2 || pos.z<38||pos.z>40||pos.x<34.1||pos.x>35.1){
            transform.position = new Vector3(34.404f,4.336f,38.696f);
        }
    }
    public void FireBullet(ActivateEventArgs arg){
        

        if (magazine_num>0){
            this.audioSource = GetComponent<AudioSource>();
            audioSource.clip = shotsound;
            audioSource.Play();
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet,5);
            
            magazine_num = magazine_num-1;

        }
        
        

    }
}
