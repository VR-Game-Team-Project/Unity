using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject Bullet;
    public float MAX_HP;
    public int Kill;
    private int Cur_HP;
    public int Bullet_num;
    public int Bullet_num1;
    int Eyebatcount;
    public TMP_Text StateText;
    public Transform FirePos;
    
    // Start is called before the first frame update
    void Start()
    {
        Cur_HP=200;
        MAX_HP = 200;
        Bullet_num = 40;
        Bullet_num1 = 5;
        Kill = 0;
        Eyebatcount=0;
        StateUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Kill+Eyebatcount ==40){
            SceneManager.LoadScene("EndingScene");
        }
        if (Cur_HP<=0){
            SceneManager.LoadScene("OverScene");
        }

        
        /*if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }*/
        
    }
    /*void Fire()
    {
        Instantiate(Bullet, FirePos.position, FirePos.rotation);
    }
*/
    public void StateUpdate()
    {
        StateText.text = "Kill: " + Kill +"\n"+ "HP: " + Cur_HP + "\n"+"Rifle Bullet: " + Bullet_num + "\n"+"Sniper Bullet: " + Bullet_num1;
    }

    public void SetDamage(int damage)
    {
        Cur_HP -= damage;
        Debug.LogFormat("#### SetDamage {0} , Player HP {1}", damage, Cur_HP);
//         if(Cur_HP <= 0)
//         {
// #if UNITY_EDITOR
//             UnityEditor.EditorApplication.isPlaying = false;
// #endif
//         }
     }

    public void SetBullet(int bullet1)
    {
        if(bullet1==40){
            Bullet_num=40;
        }
        else{
            Bullet_num -= bullet1;
            if(Bullet_num <= 0)
            {
                Bullet_num=0;
            }

        }
        
    }

    public void SetBullet1(int bullet2)
    {
        if(bullet2==5){
            Bullet_num1=5;
        }
        else{
            Bullet_num1 -= bullet2;
            if(Bullet_num1 <= 0)
            {
                Bullet_num1=0;
            }

        }
        
    }
    public void SetKill(int killnum)
    {
        
        Kill +=killnum;
        
    }

    public void SetEyebatcount()
    {
        
        Eyebatcount +=1;
        
    }
}
