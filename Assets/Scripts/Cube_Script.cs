using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Script : MonoBehaviour
{
    [SerializeField]
    private Material _on;
    [SerializeField]
    private Material _off;
    //[SerializeField]
    //private Material _show;
    //private bool show;
    public bool _Live;
    public bool _SecondLive;
    public List<GameObject> neighbours;
    
    // Use this for initialization
    void Start()
    {
        _Live = false;
        //show = false;
        _SecondLive = false;
        _Draw();
    }
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void ColorChange()
    {
        _Live = !_Live;
        _Draw();
    }

    int _Check()
    {
        int tmp = 0;
        for(int i = 0; i < neighbours.Count; i++)
        {
            if(neighbours[i].gameObject.GetComponent<Cube_Script>()._Live)
            {
                tmp++;
            }
        }
        return tmp;
    }

    void _Draw()
    {
        if(_Live)
        {
            gameObject.GetComponent<Renderer>().material = _on;
        }
        //else if (show)
        //{
        //    gameObject.GetComponent<Renderer>().material = _show;
        //}
        else
        {
            gameObject.GetComponent<Renderer>().material = _off;
        }
    }


    public void Check()
    {
        _SecondLive = _Live;
        if (_Check() == 3)
        {
            _SecondLive = true;
        }
        else if (_Check() != 2)
        {
            _SecondLive = false;
        }
    }

    public void Change()
    {
        _Live = _SecondLive;
        _Draw();
    }

    //public void ShowNeighbours()
    //{
    //    for (int i = 0; i < neighbours.Count; i++)
    //    {
    //        neighbours[i].gameObject.GetComponent<Cube_Script>().show = true;
    //        neighbours[i].gameObject.GetComponent<Cube_Script>()._Draw();
    //    }
    //}
}
