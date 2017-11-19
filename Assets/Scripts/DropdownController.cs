using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DropdownController : MonoBehaviour
{
    public Dropdown NPlayer;

    public GameObject Dropwdown1;
    public GameObject Dropwdown2;
    public GameObject Dropwdown3;
    public GameObject Dropwdown4;

    public int nPlayer;


    void Start()
    {
       
    }
    // Update is called once per frame
    void Update ()
    {
        nPlayer = NPlayer.value;
        if (NPlayer.value == 0)
        {
            Dropwdown1.SetActive(true);
            Dropwdown2.SetActive(false);
            Dropwdown3.SetActive(false);
            Dropwdown4.SetActive(false);
        }
        if (NPlayer.value == 1)
        {
            Dropwdown1.SetActive(true);
            Dropwdown2.SetActive(true);
            Dropwdown3.SetActive(false);
            Dropwdown4.SetActive(false);
        }
        if (NPlayer.value == 2)
        {
            Dropwdown1.SetActive(true);
            Dropwdown2.SetActive(true);
            Dropwdown3.SetActive(true);
            Dropwdown4.SetActive(false);
        }
        if (NPlayer.value == 3)
        {
            Dropwdown1.SetActive(true);
            Dropwdown2.SetActive(true);
            Dropwdown3.SetActive(true);
            Dropwdown4.SetActive(true);
        }
    }

}
