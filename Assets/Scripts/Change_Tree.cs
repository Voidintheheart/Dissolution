using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Tree : MonoBehaviour
{
    public GameObject Base;
    public GameObject Fire;
    public GameObject Ice;
    public bool computerbase = true;
    public bool computerfire = false;
    public bool computerice = false;

    void Update()
    { if (computerbase == true)
        {
            Invoke("fire", 2f);
        }
    else if (computerfire == true)
        {
            Invoke("ice", 2f);
        }
    else if (computerice == true)
        {
            Invoke("nature", 2f);
        }
    }
    private void nature()
    {
        computerbase = true;
        computerfire = false;
        computerice = false;
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
