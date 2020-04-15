using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController mainPlayer;
    [SerializeField] private Animator gunAnimator;
    public bool setup;

    private DoorManager doorManager;

    // UI stuff
    [SerializeField] GameObject doorCanvas;
    [SerializeField] GameObject FPSCanvas;
    

    private void Awake()
    {
        doorManager = GetComponent<DoorManager>();
        setup = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorSetup(bool status)
    {
        if(status)
        {
            gunAnimator.Play("defaultgun_draw");
            doorCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            setup = true;
        }
    }
}
