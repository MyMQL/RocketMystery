using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scorer : MonoBehaviour
{

    static int score = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Wynik();
        }

        if (collision.gameObject.tag == "Untagged")
        {
            score = score - score;
            Debug.Log(score);
        }



    }
    
    void Wynik()
    {
        score = score + 1;
  
        Debug.Log(score);
    }
}
