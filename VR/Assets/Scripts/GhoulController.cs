using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulController : MonoBehaviour
{
    public float speed;
    Animator animator;
    private GameObject player;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            animator.SetTrigger("nearPlayer");
        }
    }
}
