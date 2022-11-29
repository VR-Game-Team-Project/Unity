using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    private bool check1;
    private bool check2;
    private float timer;
    private float nightRatio;

    public float time1;
    public float time2;
    public int nightTime;
    public Material skybox;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        check1 = false;
        check2 = false;
        nightRatio = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= time1 && check1 == false)
        {
            check1 = true;
            transform.Rotate(Vector3.right, 90f);
        }
        if (timer >= time2 && check2 == false)
        {
            check2 = true;
            transform.Rotate(Vector3.right, 90f);
        }

        if (timer <= nightTime)
        {
            nightRatio = timer / nightTime;
        }
        else
        {
            nightRatio = 1f;
        }

        if (nightRatio > 0.1f)
        {
            RenderSettings.fogDensity = nightRatio - 0.1f;
        }
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(new Color(0.5f, 0.5f, 0.5f), new Color(0.05f, 0.05f, 0.05f), nightRatio));
    }

    private void OnApplicationQuit()
    {
        RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
    }
}
