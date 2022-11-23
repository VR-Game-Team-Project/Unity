using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulController : MonoBehaviour
{
    public float speed = 5;
    public int power = 10;
    public int HP = 30;
    public float Enemy_Attack_Delay = 2f;
    Animator animator;
    private GameObject player;
    private float dist; //Range of attack
    private float Cur_Attack_Time = 0.0f;


    private Player targetPlayer = null;
    //targetPlayer = GameObject.FindGameObjectWithTag("Player");


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetPlayer = player.GetComponent<Player>();
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > 2.5f)
        {
            transform.position += new Vector3(transform.forward.x * speed, 0, transform.forward.z * speed);
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
                    animator.SetTrigger("nearPlayer");
                    targetPlayer.SetDamage(power);
                    targetPlayer.StateUpdate();
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.name == "Bullet")
    //    {
    //        Debug.LogFormat("#### ######, ####");
    //    }
    //}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.LogFormat("#### ######, ####");
            Destroy(collision.gameObject);
            HP -= 10;
            StartCoroutine(MoveDelay());
            if (HP <= 0)
            {
                Destroy(gameObject);
            }

        }
    }


}