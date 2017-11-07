using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50f) && Input.GetMouseButtonDown(0))
        {
            hit.collider.GetComponent<Cube_Script>().ColorChange();
            //hit.collider.GetComponent<Cube_Script>().ShowNeighbours();
        }

    }
}
