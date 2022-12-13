using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulOriginalController : MonoBehaviour
{
    private GameObject player;
    private float lastTime;
    private float timer;
    private int zombieCount;
    private float spawnTime;
    private Vector3 spawnCenter;

    public int max_zombie;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0f;
        timer = 0f;
        zombieCount = 0;
        spawnTime = 2f;
        player = GameObject.FindGameObjectWithTag("Player");
        spawnCenter = new Vector3(player.transform.position.x + 100, player.transform.position.y - 20, player.transform.position.z);
        this.GetComponent<GhoulController>().enabled = false;
        this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= lastTime + spawnTime && zombieCount < max_zombie)
        {
            lastTime = timer;
            GameObject newZombie = Instantiate(this.gameObject, new Vector3(spawnCenter.x + Random.Range(-25, 25), spawnCenter.y, spawnCenter.z + Random.Range(-50, 50)), this.gameObject.transform.rotation);
            newZombie.GetComponent<GhoulController>().enabled = true;
            newZombie.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            spawnTime = Random.Range(1.5f, 2.5f);
            Destroy(newZombie.GetComponent<GhoulOriginalController>());
            zombieCount++;
        }
    }
}
