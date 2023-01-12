using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Finish : MonoBehaviour
{
    public Animator anim;
    public Vector3 pos;
    public InputControl control;
    public int score = 0;
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect" || other.tag == "Collected")
        {
            Destroy(PlayerControl.instance.stackList[PlayerControl.instance.stackList.Count - 1]);
            PlayerControl.instance.stackList.RemoveAt(PlayerControl.instance.stackList.Count - 1);
            score += 1;
            Debug.Log(score);
        }
        else if (other.tag == "Player")
        {
            Debug.Log("score: " + score);
            control.gameStart = false;
            other.transform.parent = null;
            other.transform.position = new Vector3(other.transform.position.x,
            other.transform.position.y, transform.position.z);
            PlayerControl.instance.pos();
            PlayerControl.instance.stop();
            PlayerControl.instance.set = true;
            anim.SetBool("finish", true);
        }
    }
}
