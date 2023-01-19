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
            
            Debug.Log("Plastic waste in paper bin ");
        }
        else if (other.gameObject.tag == "BioDegradable")
        {
            
            Debug.Log("Bio in paper bin");
        }
        else if (other.gameObject.tag == "Paper")
        {
            paperWasteCount++;
            //PaperCollectionStatus();
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
            somepaperWasteCollected = false;
            noPaperWastesCollected = false;
        }
        else if (paperWasteCount < totalPaperWasteToReceive && paperWasteCount >= (totalPaperWasteToReceive / 2))
        {
            isAllpaperWasteCollected = false;
            somepaperWasteCollected = true;
            noPaperWastesCollected = false;
        }
        else if (paperWasteCount < (totalPaperWasteToReceive / 2))
        {
            isAllpaperWasteCollected = false;
            somepaperWasteCollected = false;
            noPaperWastesCollected = true;
        }
        hUDTextControllor.hUD_DisplayText.text = "Number of Paper Waste collected: " + paperWasteCount + "\n";
    }
}
