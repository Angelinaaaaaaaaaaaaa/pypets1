using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour
{
    public static Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("nazh", true);
            Memory.energy -= 0.01;
            Memory.coins++;
            Memory.exp++;
        }
        else
        {
            anim.SetBool("nazh", false);
        }
        
    }
}
