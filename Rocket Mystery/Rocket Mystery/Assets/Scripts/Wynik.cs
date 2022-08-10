using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wynik : MonoBehaviour

{
    
    public TextMeshPro TextMeshProObject;
    public TextMeshPro ValueText;
    Scorer scorer;
    [SerializeField] GameObject Rakieta;

    // Start is called before the first frame update
    public void Awake()
    {
        scorer = Rakieta.GetComponent<Scorer>();
    }

    // Update is called once per frame
    public void Update()
    {
       int punkty = scorer.punkty;
        //Debug.Log(punkty);
        Zmiana();
        
    }

    public void Zmiana()
    {
        int wyniki = scorer.punkty;
        Debug.Log(wyniki);
        TextMeshProObject = GetComponent<TextMeshPro>();
        ValueText.text = wyniki.ToString();
        TextMeshProObject.SetText(ValueText.text = wyniki.ToString());
    }
}
