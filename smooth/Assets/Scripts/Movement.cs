using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public Transform currentLeadTransform;
    float currentVelocity = 0.0f;
    float smoothTime = 0.0525f;
    private void Update()
    {
        if (!PlayerControl.instance.set)
        {
            Move();
        }
    }
    public void Move()
    {
        if (currentLeadTransform == null)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, currentLeadTransform.position.x, ref currentVelocity, smoothTime),
                transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collected")
        {
            transform.parent = other.transform.parent;
            PlayerControl.instance.stackList.Add(transform.gameObject);
            PlayerControl.instance.stackList[PlayerControl.instance.stackList.Count - 1].transform.position = PlayerControl.instance.stackList[PlayerControl.instance.stackList.Count - 2].transform.position + new Vector3(0, 0, 1.5f);
            SetLeadTransform(PlayerControl.instance.stackList[PlayerControl.instance.stackList.Count - 2].transform);
        }
    }
    public void SetLeadTransform(Transform leadTransform)
    {
        currentLeadTransform = leadTransform;
    }
}
