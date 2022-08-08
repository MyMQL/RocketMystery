using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wynik : MonoBehaviour

{
    Scorer scorer;
    [SerializeField] GameObject Rakieta;

    // Start is called before the first frame update
    void Awake()
    {
        scorer = Rakieta.GetComponent<Scorer>();
    }

    // Update is called once per frame
    void Update()
    {
       int punkty = scorer.punkty;
        Debug.Log(punkty);
    }
}
