using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Tree : MonoBehaviour
{
    public GameObject Base;
    public GameObject Fire;
    public GameObject Ice;
    public GameObject nature_effect;
    public GameObject fire_effect;
    public GameObject ice_effect;
    public bool computerbase = true;
    public bool computerfire = false;
    public bool computerice = false;
    public bool computerbase_effect = false;
    public bool computerfire_effect = false;
    public bool computerice_effect = false;

    void Update()
    { 
    }

    public void change_tree(string ItemName)
    {
        switch (ItemName)
        {
            case "nature":
                nature();
                break;
            case "fire":
                fire();
                break;
            case "ice":
                ice();
                break;
              
        }
    }
    private void nature()
    {
        computerbase = true;
        computerfire = false;
        computerice = false;
        computerbase_effect = true;
        nature_effect.gameObject.SetActive(computerbase_effect);
        Base.gameObject.SetActive(computerbase);
        Fire.gameObject.SetActive(computerfire);
        Ice.gameObject.SetActive(computerice);

        
    }
    private void fire()
    {
        computerbase = false;
        computerfire = true;
        computerice = false;
        Base.gameObject.SetActive(computerbase);
        Fire.gameObject.SetActive(computerfire);
        Ice.gameObject.SetActive(computerice);


    }
    private void ice()
    {
        computerbase = false;
        computerfire = false;
        computerice = true;
        Base.gameObject.SetActive(computerbase);
        Fire.gameObject.SetActive(computerfire);
        Ice.gameObject.SetActive(computerice);


    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
    }
}
