using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinForPaper : MonoBehaviour
{
    [SerializeField]
    private int paperWasteCount = 0;
    public int totalPaperWasteToReceive;
    public bool isAllpaperWasteCollected = false;
    public bool somepaperWasteCollected = false;
    public bool noPaperWastesCollected = false;
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
            paperWasteCount++;
            
            Debug.Log("Plastic waste in paper bin " + paperWasteCount);
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            Debug.Log("Bio in paper bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            Debug.Log("Paper in paper bin");
        }
    }

    public void Update()
    {
        PaperCollectionStatus();
    }

    public void PaperCollectionStatus()
    {
        
        if(paperWasteCount == totalPaperWasteToReceive)
        {
            isAllpaperWasteCollected = true;
            noPaperWastesCollected = false;
        }
        else if (paperWasteCount < totalPaperWasteToReceive && paperWasteCount >= (totalPaperWasteToReceive / 2))
        {
            somepaperWasteCollected = true;
            noPaperWastesCollected = false;
        }
        else if (paperWasteCount < (totalPaperWasteToReceive / 2))
        {
            noPaperWastesCollected = true;
            noPaperWastesCollected = false;
        }
        hUDTextControllor.hUD_DisplayText.text = "Number of Paper Waste collected: " + paperWasteCount + "\n";
    }
}
