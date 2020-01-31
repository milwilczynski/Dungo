using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentManager : MonoBehaviour
{
    public static int potionCounter = 5;
    public int recoveryHp = 20;
    public Text potionView;
    private CharacterStats characterStats;
    void Start()
    {
        potionView.text = potionCounter.ToString();
        characterStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        potionView.text = potionCounter.ToString();
        if (Input.GetKeyDown(KeyCode.Alpha1) && potionCounter > 0)
        {
            potionCounter--;
            characterStats.setCurrent(recoveryHp);
        }
    }
}
