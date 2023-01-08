using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    public static PlayerControl instance;
    //public GameManager gameManager;
    public InputControl control;
    public float moveSpeed;
    public List<GameObject> stackList;
    public bool set;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anim= GetComponent<Animator>();
    }
    private void Update()
    {
        if (control.gameStart)
        {
            transform.parent.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            anim.SetBool("Move", true);

        }
        
    }
    
    public void stop()
    {
        anim.SetBool("Move", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Collect")
        {
            other.transform.parent = transform.parent.GetChild(0).transform;
            stackList.Add(other.gameObject);
            //stackList[stackList.Count - 1].transform.position += new Vector3(0, 0, stackList.Count * 1.5f);
            stackList[stackList.Count - 1].transform.position = stackList[stackList.Count-2].transform.position+ new Vector3(0, 0, 1.5f);
            //other.transform.position += stackList[stackList.Count - 1].transform.position + new Vector3(0, 0, 5f);
            if (stackList.Count==1)
            {
                stackList[0].gameObject.GetComponent<Movement>().SetLeadTransform(transform);
            }
            else
            {
                stackList[stackList.Count - 1].gameObject.GetComponent<Movement>().SetLeadTransform(stackList[stackList.Count - 2].transform);
            }
        }
        else if (other.tag=="h")
        {   
            Destroy(stackList[stackList.Count-1]);
            stackList.RemoveAt(stackList.Count - 1);
        }
        if (transform.childCount==3)
        {
            other.tag = "Collected";
        }
    }
}
