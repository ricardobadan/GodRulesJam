using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    Animator anim;
    public bool canOpen;
    public bool canShut;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            anim.SetTrigger("OpenDoor");
        }
        if (canShut)
        {
            anim.SetTrigger("ShutDoor");
        }
    }
}
