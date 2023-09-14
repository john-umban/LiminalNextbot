using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    
    public SanityManager sanityManager;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            sanityManager.AffectSanity(1000f); 
        }
    }
}
