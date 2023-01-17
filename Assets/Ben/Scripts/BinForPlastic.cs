using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinForPlastic : MonoBehaviour
{
    [SerializeField]
    private int plasticWasteCount = 0;
    public int totalPlastiWateToReceive;
    public bool isAllPlasticwasteCollected = false;
    public bool somePlasticwasteCollected = false;
    public bool noPlasticwasteCollected = false;
    [SerializeField]
    private UITextControllor hUDTextControllor;

    private void Start()
    {
        hUDTextControllor = GameObject.FindGameObjectWithTag("GameController").GetComponent<UITextControllor>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plastic")
        {
            plasticWasteCount++;
            //PlasticCollectionStatus();
            Debug.Log("Plastic waste in plastic bin " + plasticWasteCount);
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            Debug.Log("Bio in plastic bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in plastic bin");
        }
    }

    public void Update()
    {
        PlasticCollectionStatus();
    }

    public void PlasticCollectionStatus()
    {
        if (plasticWasteCount == totalPlastiWateToReceive)
        {
            isAllPlasticwasteCollected = true;
        }
        else if (plasticWasteCount < totalPlastiWateToReceive && plasticWasteCount >= (totalPlastiWateToReceive / 2))
        {
            somePlasticwasteCollected = true;
        }
        else if(plasticWasteCount < (totalPlastiWateToReceive / 2))
        {
            noPlasticwasteCollected = true;
        }
        hUDTextControllor.hUD_DisplayText.text = hUDTextControllor.hUD_DisplayText.text + "Number of Plastic Waste collected: " + plasticWasteCount + "\n";
    }
}
