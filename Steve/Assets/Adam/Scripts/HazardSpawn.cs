using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HazardSpawn : MonoBehaviour
{
    public Hazard HazardPrefab;
    public int EmitHazardTheta = 0;
    public int HazardVelocity = 120;
    public float shortSpawnTimer = 1.0f;
    public float longSpawnTimer = 3.0f;
    public int spawnsPerSeries = 3;

    public float lastSpawn = 0f;
    

    private int seriesCount;
    public bool SpawnActivated = false;

    void Update()
    {
        lastSpawn += Time.deltaTime;
        if (!SpawnActivated)
        {
            return;
        }
        if (seriesCount >= spawnsPerSeries)
        {
            if (lastSpawn > longSpawnTimer)
            {
                seriesCount = 0;
                SpawnHazard();
            }
        }
        else
        {
            if (lastSpawn > shortSpawnTimer)
            {
                SpawnHazard();
            }
        }
    }

    private void SpawnHazard()
    {
        var hazard = (Hazard)Instantiate(HazardPrefab, transform.position, Quaternion.identity);

        var rads = Mathf.Deg2Rad * EmitHazardTheta;

        var xVel = Mathf.Sin(rads) * HazardVelocity;
        var yVel = Mathf.Cos(rads) * HazardVelocity;

        hazard.GetComponent<Rigidbody2D>().AddForce(new Vector2(xVel, yVel));
        lastSpawn = 0f;
        seriesCount++;
    }
}
