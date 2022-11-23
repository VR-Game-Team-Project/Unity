using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bullet;
    public float MAX_HP = 200;
    private int Cur_HP = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
    }
    void Fire()
    {
        Instantiate(Bullet);
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
}
