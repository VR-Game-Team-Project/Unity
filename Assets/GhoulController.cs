using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulController : MonoBehaviour
{
    public float speed = 5;
    public int power = 10;
    public int HP = 30;
    public float Enemy_Attack_Delay = 0.5f;
    Animator animator;
    private GameObject player;
    private float dist;
    private float Cur_Attack_Time = 0.0f;
    private int firsttime = 0;
    private Player targetPlayer = null;
    private int onetimecount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetPlayer = player.GetComponent<Player>();
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
        animator = GetComponent<Animator>();
        speed=0.05f;
        onetimecount=0;
    }

    // Update is called once per frame

    void firsttimeaction(){
        
        animator.SetTrigger("nearPlayer");
        targetPlayer.SetDamage(power);
        targetPlayer.StateUpdate();

    }
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > 3.5f)
        {
            transform.position += transform.forward * speed;
        }
        else
        {
            // ATTACK
            if (targetPlayer != null)
            {
                if (firsttime==0){
                    firsttime = 1;
                    Invoke("firsttimeaction",0.1f);
                    
                }else{
                    if (Cur_Attack_Time < Enemy_Attack_Delay)
                    {
                        Cur_Attack_Time += Time.deltaTime;
                    }
                    else
                    {
                        Cur_Attack_Time = 0.0f;
                        animator.SetTrigger("nearPlayer");
                        targetPlayer.SetDamage(power);
                        targetPlayer.StateUpdate();
                    }

                }
                

            }
            else
            {
                Debug.LogFormat(" ### ERROR NO OBJECT ###");
            }
        }
    }
    IEnumerator MoveDelay()
    {
        float tmpSpeed = speed; //current monster sppeed
        speed = 0;
        yield return new WaitForSeconds(0.2f);
        speed = tmpSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Bullet")
       {
            Debug.LogFormat("#### ######, ####");
            Destroy(other.gameObject);
            HP -= 10;
            StartCoroutine(MoveDelay());
            if (HP <= 0 && onetimecount==0)
            {
                onetimecount=1;
                //animator.SetTrigger("nearPlayer");
                targetPlayer.SetKill(1);
                targetPlayer.StateUpdate();
                Destroy(gameObject);
                
            }
       }
    }
    

}



















