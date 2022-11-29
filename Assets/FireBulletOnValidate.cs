using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FireBulletOnValidate : MonoBehaviour
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
    AudioSource audioSource;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        magazine_num=40;
        player = GameObject.FindGameObjectWithTag("Player");
        targetPlayer = player.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other) {
        //Trigger Point와의 collider로 변경
        if (other.gameObject.tag =="magazine"){
            
            magazine.transform.position = new Vector3(33.9967f,4.3265f,39.497f);
            if (magazine.activeSelf==true){
            
            magazine.SetActive(false);
            }
            magazine_num = 40;
            targetPlayer.SetBullet(40);

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        pos = this.gameObject.transform.position;
        if (pos.y<4.1 || pos.z<38||pos.z>40||pos.x<33.8||pos.x>34.65){
            transform.position = new Vector3(34.404f,4.336f,38.696f);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (magazine_num<15 && magazine.activeSelf==false){
            
            magazine.SetActive(true);
            magazine.transform.position = new Vector3(33.9967f,4.2666f,39.497f);
            magazine.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void FireBullet(ActivateEventArgs arg){
        
        
        /*this.audioSource = GetComponent<AudioSource>();
        audioSource.clip = shotsound;
        audioSource.Play();*/
        

        if (magazine_num>0){
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet,5);
            magazine_num = magazine_num-1;

            targetPlayer.SetBullet(1);
            targetPlayer.StateUpdate();
            

        }
        
        
        

    }
}
