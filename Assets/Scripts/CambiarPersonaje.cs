using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CambiarPersonaje : MonoBehaviour
{



    private GameObject[] cambiarPersonaje;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        cambiarPersonaje = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            cambiarPersonaje[i] = transform.GetChild(i).gameObject;

        }

        foreach (GameObject j in cambiarPersonaje)
        {
            j.SetActive(false);



            if (cambiarPersonaje[index])
            {
                cambiarPersonaje[index].SetActive(true);

            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void btnLeft()
    {
        cambiarPersonaje[index].SetActive(false);
        index--;
        if(index < 0)
        {
            index = cambiarPersonaje.Length - 1 ;
        }

        cambiarPersonaje[index].SetActive(true);

    }

    public void btnRight()
    {

        cambiarPersonaje[index].SetActive(false);
        index++;
        if (index == cambiarPersonaje.Length)
        {
            index = 0;
        }

        cambiarPersonaje[index].SetActive(true);
    }
}
