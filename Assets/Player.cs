using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject Bullet;
    public float MAX_HP;
    public int Kill;
    private int Cur_HP;
    public int Bullet_num;
    public TMP_Text StateText;
    public Transform FirePos;
    
    // Start is called before the first frame update
    void Start()
    {
        Cur_HP=200;
        MAX_HP = 200;
        Bullet_num = 40;
        Kill = 5;
        StateUpdate();
    }

    // Update is called once per frame
    void Update()
    {
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
        StateText.text = "Kill" + Kill +"\n"+ "HP" + Cur_HP + "\n"+"Bullet" + Bullet_num;
    }

    public void SetDamage(int damage)
    {
        Cur_HP -= damage;
        Debug.LogFormat("#### SetDamage {0} , Player HP {1}", damage, Cur_HP);
        if(Cur_HP <= 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
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
}
