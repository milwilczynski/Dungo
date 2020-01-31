using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotionSystem : MonoBehaviour
{
    public Text text;
    private bool canBePickUp = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canBePickUp)
            {
                EquipmentManager.potionCounter++;
                text.text = "";
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        canBePickUp = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canBePickUp = true;
            text.text = "Naciśnij e";
        }
    }
}
