using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameHandlerMenu : MonoBehaviour
{
    public Animator animator;
    public Text text;
    private float holdTime;
    private bool countTime;
    // Start is called before the first frame update
    void Start()
    {
        countTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
        {
            if(Time.time > holdTime)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (animator.GetBool("deadowka") && !countTime)
        {
            text.text = "Umarłeś, Za 2 sekundy wrocisz do menu";
            holdTime = Time.time + 4.0f;
            countTime = true;
        }
    }
}
