using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    public static PlayerControl instance;
    public GameManager gameManager;
    public InputControl control;
    public float moveSpeed;
    public List<GameObject> stackList;
    public bool set = false;
    public Finish finish;
    Vector3 posz;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (control.gameStart)
        {
            transform.parent.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            anim.SetBool("Move", true);
        }
        if (set)
        {
            transform.position=Vector3.Lerp(transform.position, posz, 1.5f * Time.deltaTime);
            if (transform.position.z+0.01f>=posz.z)
            {
                //anim.SetBool("finish", false);
                anim.SetBool("dance", true);
                set= false;
                gameManager.win();
            }
        }

    }
    public void pos()
    {
        posz=transform.position + new Vector3(0f, 0f, finish.score);
    }

    public void stop()
    {
        anim.SetBool("Move", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect")
        {
            other.transform.parent = transform.parent.GetChild(0).transform;
            stackList.Add(other.gameObject);
            stackList[stackList.Count - 1].transform.position = stackList[stackList.Count - 2].transform.position + new Vector3(0, 0, 1.5f);
            if (stackList.Count == 1)
            {
                stackList[0].gameObject.GetComponent<Movement>().SetLeadTransform(transform);
            }
            else
            {
                stackList[stackList.Count - 1].gameObject.GetComponent<Movement>().SetLeadTransform(stackList[stackList.Count - 2].transform);
            }
        }
        else if (other.tag == "h")
        {
            Destroy(stackList[stackList.Count - 1]);
            stackList.RemoveAt(stackList.Count - 1);
        }
        if (transform.childCount == 3)
        {
            other.tag = "Collected";
        }
    }
}
