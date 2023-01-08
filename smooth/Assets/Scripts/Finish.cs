using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager gameManager;
    public InputControl control;
    int score = 0;
    public TextMeshProUGUI point;
    public GameObject panel;
    private void Update()
    {
        Debug.Log(score);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Collect")
        {
            PlayerControl.instance.set = true;
            //Destroy(other.GetComponent<Movement>());
            other.transform.parent = null;
            other.transform.position = transform.position + new Vector3(0, .5f, 1f) + (new Vector3(0, .5f, 0) * transform.childCount);
            other.transform.parent = transform;
        }
        else if (other.tag=="cup")
        {
            score += 5;
        }
        else if (other.tag == "gold")
        {
            score+= 10;
        }
        else if (other.tag == "Player")
        {
            PlayerControl.instance.moveSpeed= 0;
            PlayerControl.instance.stop();
            control.gameStart = false;
            panel.SetActive(true);
            point.text = score.ToString();
        }
    }
}
