using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Convert : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI text;
    int score = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect" || other.tag == "Collected")
        {
            Destroy(PlayerControl.instance.stackList[PlayerControl.instance.stackList.Count - 1]);
            PlayerControl.instance.stackList.RemoveAt(PlayerControl.instance.stackList.Count - 1);
            score += 1;
            text.text = score.ToString();
        }
        else if (other.tag == "Player" && score == 0)
        {
            gameManager.fail();
        }
    }
}
