using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupLetter : MonoBehaviour
{
    public GameObject collectTextObj, intText, YOUWIN;
    public AudioSource pickupSound;
    public bool interactable;
    public static int pagesCollected;
    public Text collectText;

    void OnTriggerStay(Collider other){
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
            YOUWIN.SetActive(false);

        }
    }

    void OnTriggerExit(Collider other){
    if (other.CompareTag("MainCamera"))
    {
        intText.SetActive(false);
        interactable = false;
        YOUWIN.SetActive(false);

    }
    }

    void Update(){

        if (interactable == true){
            if(Input.GetKeyDown(KeyCode.E)){
                pagesCollected = pagesCollected + 1; // +=1; 
                collectText.text = pagesCollected + "/8 pages Collected";
                collectTextObj.SetActive(true);
                pickupSound.Play();
                intText.SetActive(false);
                this.gameObject.SetActive(false);
                interactable = false;
                if (pagesCollected == 8){
                YOUWIN.SetActive(true);

            }
        }
    }


}
}