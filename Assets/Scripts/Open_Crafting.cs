using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Open_Crafting : MonoBehaviour
{
    public Canvas Crafting_Panel;
    public bool computerOn = true;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
                computerOn = !computerOn;
                Crafting_Panel.gameObject.SetActive(computerOn);
         }

          
    }
}
