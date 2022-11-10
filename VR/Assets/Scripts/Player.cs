using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float HP = 2500;
    private int CurHP = 0;
    private Camera maincam = null;
    // Start is called before the first frame update
    void Start()
    {
        maincam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDamage(int damage)
    {
        HP -= damage;
        Debug.LogFormat(" ### SetDamage param :{0} , HP :{1}", damage, HP);

    }
}
