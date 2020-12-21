using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpClue : MonoBehaviour
{
    [Header("Panels")]
	[SerializeField] private GameObject popUpPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.C))
    	{
    		popUpPanel.SetActive(true);
    	} 
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUpPanel.SetActive(false);            
        }
    }
}