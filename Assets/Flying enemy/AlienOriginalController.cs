using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienOriginalController : MonoBehaviour
{
    private GameObject player;
    private float lastTime;
    private float timer;
    private int alienCount;
    private float spawnTime;
    private Vector3 spawnCenter;
    AlienController alienController;

    public int max_alien;

    // Start is called before the first frame update.

    
    void Start()
    {
        lastTime = 0f;
        timer = 0f;
        alienCount = 0;
        spawnTime = 8f;
        player = GameObject.FindGameObjectWithTag("Player");
        spawnCenter = new Vector3(player.transform.position.x + 100, player.transform.position.y, player.transform.position.z);
        this.GetComponent<AlienController>().enabled = false;
        this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= lastTime + spawnTime && alienCount < max_alien)
        {
            
            lastTime = timer;
            GameObject newAlien = Instantiate(this.gameObject, new Vector3(spawnCenter.x + Random.Range(-25, 25), spawnCenter.y+ Random.Range(10, 30), spawnCenter.z + Random.Range(-50, 50)), this.gameObject.transform.rotation);
            newAlien.GetComponent<AlienController>().enabled = true;
            newAlien.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            spawnTime = Random.Range(3.0f, 6.0f);
            Debug.Log(spawnTime);
            Destroy(newAlien.GetComponent<AlienOriginalController>());
            alienCount++;
        }
    }

    
}
