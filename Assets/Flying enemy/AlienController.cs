using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    
    

    public float speed = 10;
    public int power = 40;
    public int HP = 10;
    public float Enemy_Attack_Delay = 0.5f;
    Animator animator;
    private GameObject player;
    private float dist;
    private float Cur_Attack_Time = 0.0f;
    private int monstercount;
    private int aliencount=0;
    private int onetimecount=0;
    private Player targetPlayer = null;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetPlayer = player.GetComponent<Player>();
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
        animator = GetComponent<Animator>();
        onetimecount=0;
        
        

        

    }
    public void SetCount(int count)
    {
        monstercount = count;
       
    }

    // Update is called once per frame
    
    void Update()
    {
        if(monstercount>=20){
            speed=0.2f;
        }
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
                if (Cur_Attack_Time < Enemy_Attack_Delay)
                {
                    Cur_Attack_Time += Time.deltaTime;
                }
                else
                {
                    Cur_Attack_Time = 0.0f;
                    animator.SetTrigger("attack_01");
                    targetPlayer.SetEyebatcount();
                    
                    targetPlayer.SetDamage(power);
                    targetPlayer.StateUpdate();
                    Destroy(gameObject);
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
       if(other.gameObject.tag == "Bullet1")
       {
            Debug.LogFormat("#### ######, ####");
            Destroy(other.gameObject);
            
            HP -= 10;
            animator.SetTrigger("die");
            StartCoroutine(MoveDelay());
            if (HP <= 0&&onetimecount==0)
            {
                onetimecount=1;
                //animator.SetTrigger("die");
                targetPlayer.SetKill(1);
                
                targetPlayer.StateUpdate();
                Destroy(gameObject);
                
            }
       }
    }
}



















