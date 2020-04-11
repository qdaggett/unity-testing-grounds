using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quinn Daggett - 100618734
// 2020-01-29

public class Door : MonoBehaviour
{
    // Asset-related variables
    Animator doorAnimator;
    public ParticleSystem hotParticles;
    public AudioSource noisySound;
    public AudioSource notSafeSound;
    public AudioSource safeSound;

    // Door properties
    public bool isHot;
    public bool isNoisy;
    public bool isSafe;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Function for setting up door properties
    public void InitDoor(bool hot, bool noisy, bool safe)
    {
        isHot = hot;
        isNoisy = noisy;
        isSafe = safe;

        if(isHot)
        {
            hotParticles.Play(); // Play smoke particles if door is hot
        }

        if(isNoisy)
        {
            noisySound.Play(); // Play crackling sound on loop if door is noisy
        }

    }

    // Update is called once per frame
    // Canned animation portion
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.O))
    //    {
    //        //doorAnimator.SetTrigger("OpenDoor");
    //        doorAnimator.Play("Open");
    //    }
    //
    //    if(Input.GetKeyDown(KeyCode.C))
    //    {
    //        //doorAnimator.SetTrigger("CloseDoor");
    //        doorAnimator.Play("Close");
    //    }
    //
    //}

    public void UseDoor()
    {
        if(isSafe == false)
        {
            notSafeSound.Play();
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(isSafe == true)
        {
            safeSound.Play();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
