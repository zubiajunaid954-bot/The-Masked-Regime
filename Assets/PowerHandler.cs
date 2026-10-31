using UnityEngine;
using System.Collections;
public class PowerHandler : MonoBehaviour
{
    [SerializeField] HurdlesHandler hurdlesHandler;
    [SerializeField] CharacterController characterController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Power collected!");
            if(transform.parent.name == "Player1")
            {
                if (other.gameObject.name == "black_mask")
                {


                    StartCoroutine(HereWeAreDisablinghTheHurdles("P1Camview"));
                }
                else
                {
                    //write your login here for the white amask
                }
            }
            else
            {
                if (other.gameObject.name == "black_mask")
                {
                    StartCoroutine(HereWeAreDisablinghTheHurdles("P2Camview"));

                }
                else
                {
                    //do it same for the player twn for the white mask 
                }
            }
            Destroy(other.gameObject, .5f);
        }

    }

    IEnumerator HereWeAreDisablinghTheHurdles(string layerName)
    {
        changeExcludeLayer(layerName);
        hurdlesHandler.ChangeLayerByName(layerName);
        //change the variable to change the delay
        yield return new WaitForSeconds(6.0f);
        changeExcludeLayer("Nothing");
        hurdlesHandler.ChangeLayerByName("Default");
    }

    public void changeExcludeLayer(string layerName)
    {
        int layer = LayerMask.NameToLayer(layerName);
        if (layer != -1)
        {
            characterController.includeLayers |= (1 << layer);
        }
    }
}
