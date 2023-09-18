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

//note: Canvas of intText should have its own canvas, outside of collectText, and etc canvas.

    void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Reach") //originally if (other.CompareTag("MainCamera")) 
        {
            intText.SetActive(true);
            interactable = true;
            YOUWIN.SetActive(false);

        }
    }

    void OnTriggerExit(Collider other){
    if (other.gameObject.tag == "Reach") // originally if (other.CompareTag("MainCamera"))
    {
        intText.SetActive(false);
        interactable = false;
        YOUWIN.SetActive(false);

    }
    }

    void Update(){

        if (interactable == true){
            if(Input.GetKeyDown(KeyCode.E)){
                pagesCollected += 1; 
                collectText.text = pagesCollected + "/8 pages";
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