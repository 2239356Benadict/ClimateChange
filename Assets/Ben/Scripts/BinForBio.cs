using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinForBio : MonoBehaviour
{
    [SerializeField]
    private int bioWasteCount = 0;
    public int totalBioWastetoReceive;
    public bool isAllBioWasteCollected = false;
    public bool someBioWasteCollected = false;
    public bool noBioWasteCollected = false;
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
            
            Debug.Log("Plastic waste in bio bin "+ bioWasteCount);
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            bioWasteCount++;
            //BioWasteCollectionStatus();
            Debug.Log("Bio in bio bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in bio bin");
        }
    }

    public void Update()
    {
        BioWasteCollectionStatus();
    }

    public void BioWasteCollectionStatus()
    {
        if (bioWasteCount == totalBioWastetoReceive)
        {
            isAllBioWasteCollected = true;
        }
        else if(bioWasteCount < totalBioWastetoReceive && bioWasteCount >= (totalBioWastetoReceive/2))
        {
            someBioWasteCollected = true;
        }
        else if(bioWasteCount < (totalBioWastetoReceive / 2))
        {
            noBioWasteCollected = true;
        }

        hUDTextControllor.hUD_DisplayText.text = hUDTextControllor.hUD_DisplayText.text + "Number of Food Waste collected: " + bioWasteCount + "\n";
    }
}
