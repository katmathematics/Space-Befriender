using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightDirection : MonoBehaviour
{

    public PlayerController player;
    private bool currentDirectionRight = true;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.rightNext != currentDirectionRight) {
            currentDirectionRight = player.rightNext;

            if(currentDirectionRight) {
                anim.Play("Go_Right_Anim");
            }
            else {
                anim.Play("Go_Left_Anim");
            }
        }
    }
}
