using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
public class FireBulletOnValidate2 : MonoBehaviour
{
    public GameObject bullet;
    public GameObject magazine;
    public Transform spawnPoint;    
    public Transform triggerPoint;

    Vector3 pos;
    public AudioClip shotsound;
    private Player targetPlayer = null;
    private GameObject player;
    int magazine_num;
    int delay_num;
    public float fireSpeed = 20;
    AudioSource audioSource;
    public AudioClip clipinsound;
     XRGrabInteractable grabbable;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet2);
        magazine_num=5;
        player = GameObject.FindGameObjectWithTag("Player");
        targetPlayer = player.GetComponent<Player>();
        delay_num=0;
    }

    private void OnTriggerEnter(Collider other) {
        //Trigger Point와의 collider로 변경
        if (other.gameObject.tag =="magazine"){
            this.audioSource = GetComponent<AudioSource>();
            audioSource.clip = clipinsound;
            audioSource.Play();
            magazine.transform.position = new Vector3(34.385f,4.302f,38.345f);
            if (magazine.activeSelf==true){
            
            magazine.SetActive(false);
            }
            magazine_num = 5;
            targetPlayer.SetBullet1(5);
            targetPlayer.StateUpdate();

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        pos = this.gameObject.transform.position;
        if (pos.y<4.1 || pos.z<38||pos.z>40||pos.x<33.8||pos.x>34.65){
            transform.position = new Vector3(34.385f,4.302f,38.345f);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (magazine_num<5 && magazine.activeSelf==false){
            
            magazine.SetActive(true);
            magazine.transform.position = new Vector3(33.9967f,4.2666f,39.497f);
            magazine.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (OVRInput.GetDown(OVRInput.Button.One) && grabbable.isSelected ){
           //toggle light
            
        }
        if (OVRInput.GetDown(OVRInput.Button.One) && grabbable.isSelected ){
           
        }


    }
    public void SetDelay(){
        delay_num=0;
    }

    public void FireBullet2(ActivateEventArgs arg){
        
        
        
        

        if (magazine_num>0&&delay_num==0){
            this.audioSource = GetComponent<AudioSource>();
            audioSource.clip = shotsound;
            audioSource.Play();
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet,5);
            magazine_num = magazine_num-1;
            delay_num=1;
            targetPlayer.SetBullet1(1);
            targetPlayer.StateUpdate();
            Invoke("SetDelay",1.0f);
        }
        
        
        

    }
}
