using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    public DiceKick Kick;

    public GameObject BlkDie;
    public GameObject RedDie;
    public GameObject RedDie2;
    public GameObject BluDie;
    public GameObject BrwnDie;
    public GameObject YlwDie;
    public GameObject YlwDie2;
    public GameObject GryDie;
    public GameObject GryDie2;

    public string buttonName = "Fire1";

    public Vector3 Blkpoint;
    public Vector3 Redpoint;
    public Vector3 Redpoint2;
    public Vector3 Blupoint;
    public Vector3 Brwnpoint;
    public Vector3 Ylwpoint;
    public Vector3 Ylwpoint2;
    public Vector3 Grypoint;
    public Vector3 Grypoint2;

    public static int blkval;
    public static int redval;
    public static int redval2;
    public static int bluval;
    public static int brwnval;
    public static int ylwval;
    public static int ylwval2;
    public static int gryval;
    public static int gryval2;


    public static int nbluval;
    public static int nylwval;
    public static int nylwval2;




    public static int defroll;
    public static int damroll;
    public static int rangeroll;



    void Start()
    {
        Blkpoint = BlkDie.transform.position;
        Redpoint = RedDie.transform.position;
        Redpoint2 = RedDie2.transform.position;
        Blupoint = BluDie.transform.position;
        Brwnpoint = BrwnDie.transform.position;
        Ylwpoint = YlwDie.transform.position;
        Ylwpoint2 = YlwDie2.transform.position;
        Grypoint = GryDie.transform.position;
        Grypoint2 = GryDie2.transform.position;
    }

    void Update()
    {
        blkval = BlkDie.GetComponent<DiceNum>().value;
        bluval = BluDie.GetComponent<DiceNum>().value;
        redval = RedDie.GetComponent<DiceNum>().value;
        redval2 = RedDie2.GetComponent<DiceNum>().value;
        gryval = GryDie.GetComponent<DiceNum>().value;
        gryval2 = GryDie2.GetComponent<DiceNum>().value;
        brwnval = BrwnDie.GetComponent<DiceNum>().value;
        ylwval = YlwDie.GetComponent<DiceNum>().value;
        ylwval2 = YlwDie2.GetComponent<DiceNum>().value;

        nbluval = BluDie.GetComponent<DiceNum>().nvalue;
        nylwval = YlwDie.GetComponent<DiceNum>().nvalue;
        nylwval2 = YlwDie2.GetComponent<DiceNum>().nvalue;

    }

    void disabledie()
    {
        BlkDie.gameObject.SetActive(false);
        RedDie.gameObject.SetActive(false);
        RedDie2.gameObject.SetActive(false);
        BluDie.gameObject.SetActive(false);
        BrwnDie.gameObject.SetActive(false);
        YlwDie.gameObject.SetActive(false);
        YlwDie2.gameObject.SetActive(false);
        GryDie.gameObject.SetActive(false);
        GryDie2.gameObject.SetActive(false);
    }

    //can adjust to different classes within the metholds

    public void rollrest()
    {
        disabledie();

        // single red
        rollRED();
    }

    public void rollrevive()
    {
        disabledie();

        rollRED();
        rollRED2();

        damroll = redval + redval2;
        print(redval + " / " + redval2);

        // two reds
    }

    public IEnumerator rollmelee(UnitInformation enemyunit)
    {
        disabledie();

        // single red and blue
        // http://puu.sh/yj0Ce/baeb673c0b.jpg

        rollRED();
        rollBLU();

        yield return new WaitForSeconds(7f);
        
        damroll = redval + bluval;
        failcheck();

    }

    public IEnumerator rollranged(UnitInformation enemyunit)
    {
        disabledie();

        // single blue and 2 yellows
        // http://puu.sh/yj0G5/b28c40e926.jpg

        rollYLW();
        rollYLW2();
        rollBLU();

        yield return new WaitForSeconds(7f);

        damroll = bluval + ylwval + ylwval2;
        rangeroll = nylwval + nylwval2 + nbluval;
        failcheck();

    }

    public void failcheck()
    {
        if (bluval == 0)
        {
            // attack failed
            damroll = -999;
        }
    }

    public  IEnumerator rolldef(UnitInformation enemyunit)
    {

        if (enemyunit.tag == "Enemy")
        {
            rollBRWN();
            yield return new WaitForSeconds(8f);
            defroll = brwnval;
        }
        if (enemyunit.tag == "Player")
        {
            rollGRY();
            yield return new WaitForSeconds(8f);
            defroll = gryval;
        }

    }

    /// <summary>
    /// Dice rolls
    /// </summary>

    void rollRED()
    {
        RedDie.transform.position = (Redpoint);
        RedDie.gameObject.SetActive(true);
        Kick = RedDie.GetComponent<DiceKick>();
        Kick.KickDie();
    }

    void rollRED2()
    {
        RedDie2.transform.position = (Redpoint2);
        RedDie2.gameObject.SetActive(true);
        Kick = RedDie2.GetComponent<DiceKick>();
        Kick.KickDie();
    }

    void rollBLU()
    {
        BluDie.transform.position = (Blupoint);
        BluDie.gameObject.SetActive(true);
        Kick = BluDie.GetComponent<DiceKick>();
        Kick.KickDie();
    }

    void rollYLW()
    {
        YlwDie.transform.position = (Ylwpoint);
        YlwDie.gameObject.SetActive(true);
        Kick = YlwDie.GetComponent<DiceKick>();
        Kick.KickDie();
    }

    void rollYLW2()
    {
        YlwDie2.transform.position = (Ylwpoint2);
        YlwDie2.gameObject.SetActive(true);
        Kick = YlwDie2.GetComponent<DiceKick>();
        Kick.KickDie();
    }

    void rollBRWN()
    {
        BrwnDie.transform.position = (Brwnpoint);
        BrwnDie.gameObject.SetActive(true);
        Kick = BrwnDie.GetComponent<DiceKick>();
        Kick.KickDie();
    }

    void rollGRY()
    {
        GryDie.transform.position = (Grypoint);
        GryDie.gameObject.SetActive(true);
        Kick = GryDie.GetComponent<DiceKick>();
        Kick.KickDie();
    }
}
