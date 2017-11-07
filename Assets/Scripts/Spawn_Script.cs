using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Script : MonoBehaviour
{
    [SerializeField]
    int size;  //size of dimentions
    [SerializeField]
    int dim; //amount of dimentions
    [SerializeField]
    GameObject _prefab; //amount of dimentions

    private int[] coords;

    private int timer;

    GameObject[] _blocks;

    // Use this for initialization
    void Start()
    {
        _blocks = new GameObject[(int)Mathf.Pow(size, dim)];
        Spawn();
        for(int i = 0; i < _blocks.Length; i++)
        {
            FindNeighbours(i);
        }
        timer = 0;
	}
	
	// Update is called once per frame
	void Update()
    {

        if (timer >= 30)
        {
            for (int i = 0; i < _blocks.Length; i++)
            {
                _blocks[i].GetComponent<Cube_Script>().Check();
            }
            for (int i = 0; i < _blocks.Length; i++)
            {
                _blocks[i].GetComponent<Cube_Script>().Change();
            }
            timer = 0;
        }
        else
        {
            timer++;
        }
    }

    int MakeX(int self)
    {
        int x = 0;
        for (int i = 0; i < dim; i++)
        {
            if (i % 2 == 0)
            {
                x += numberToArray(self)[i] * (int) Mathf.Pow(size + 1, i / 2);
            }
        }
        return x;
    }

    int MakeY(int self)
    {
        int y = 0;
        for (int i = 0; i < dim; i++)
        {
            if (i % 2 == 1)
            {
                y += numberToArray(self)[i] * (int) Mathf.Pow(size + 1, (i - 1) / 2);
            }
        }
        return y;
    }

    void Spawn()
    {
        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i] = Instantiate(_prefab,new Vector3(MakeX(i), MakeY(i), 0), Quaternion.identity);
        }
    }

    public int[] numberToArray(int self)
    {
        coords = new int[dim];
        for (int i = 0; i < dim; i++)
            {
            coords[i] = (int) Mathf.Floor(self % (Mathf.Pow(size, i + 1)) / Mathf.Pow(size, i));

        }
        return coords;
    }


    private void FindNeighbours(int num)
    {
        int[] self = numberToArray(num);

        for(int j = 0; j < _blocks.Length; j++)
        {
            bool tmp = true;
            int[] arrayTmp = numberToArray(j);
            for (int k = 0; k < arrayTmp.Length; k++)
            {
                if(!(arrayTmp[k] - self[k] <= 1 && arrayTmp[k] - self[k] >= -1))
                {
                    tmp = false;
                }
            }
            if(tmp && num != j)
            {
                _blocks[num].GetComponent<Cube_Script>().neighbours.Add(_blocks[j]);
            }
        }
    }
}