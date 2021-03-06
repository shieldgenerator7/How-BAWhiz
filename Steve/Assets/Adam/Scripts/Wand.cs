﻿using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class Wand : MonoBehaviour
{
    public SomaticComponent Somatic;
    private Vector3 screenPoint;
    private Vector3 offset;

    private int Errors = 0;

      
    // Use this for initialization
    void Start()
    {
        var manager = FindObjectOfType<TargetManager>();
        manager.RegisterWand(this);
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
    }

    void Update()
    {
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        curPosition.z = -1f;
        transform.position = curPosition;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "hazard")
        {
            Errors++;
            Debug.Log(String.Format("Contact detected: {0}", Errors));
        }

        if (collider.gameObject.tag == "target")
        {
            collider.gameObject.SendMessage("Score");
        }
    }

    public void End()
    {
        Debug.Log(String.Format("Errors: {0}", Errors));
        
        /*if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }*/
        var navigator = FindObjectOfType<Navigator>();
        Somatic.ErrorCount = Errors;
        PlayerProgress.Instance.InProgressSpell.AddSomaticComponent(Somatic);
        navigator.Navigate("LessonStatus");
    }

	
}
