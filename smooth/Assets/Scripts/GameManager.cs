using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputControl control;
    public Animator anima;
    public GameObject[] panels;
    public void fail()
    {
        control.gameStart = false;
        anima.SetBool("Move", false);
        panels[0].SetActive(true);        
        //PlayerControl.instance.GetComponent<Animator>().enabled = false;

    }public void win()
    {
        panels[1].SetActive(true);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
