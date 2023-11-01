using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSkills : MonoBehaviour
{

    private Rigidbody rb;

    [Header("Dialogue References")]
    public GameObject TutorialDialogue;
    public GameObject SliddingDialogue;
    public GameObject ClimbingDialogue;
    public GameObject WallrunDialogue;
    public GameObject escapeDialogue;

    [Header("uiRef")]
    public GameObject slidePot;
    public GameObject climbPot;
    public GameObject wallrunPot;
    public GameObject ledgegarbPot;
    public GameObject dashPot;
    public GameObject stamina;

    [Header("audio")]
    public AudioClip pickClip;

    AudioSource asource;

    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ActivateClimbing")
        {
            try
            {
                Debug.Log("touched climb power up");
                gameObject.GetComponent<Climbing>().enabled = true;



                asource.PlayOneShot(pickClip);
                TutorialDialogue.SetActive(false);
                SliddingDialogue.SetActive(false);
                ClimbingDialogue.SetActive(true);
                climbPot.SetActive(true);

                Destroy(collision.gameObject);
            }
            catch
            {
                Destroy(collision.gameObject);
            }
            
        }
        if (collision.gameObject.tag == "ActivateSliding")
        {
            try
            {
                Debug.Log("touched slide power up");
                gameObject.GetComponent<Sliding>().enabled = true;


                asource.PlayOneShot(pickClip);
                TutorialDialogue.SetActive(false);
                SliddingDialogue.SetActive(true);
                slidePot.SetActive(true);

                Destroy(collision.gameObject);
            }
            catch
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "ActivateDashing")
        {
            try
            {
                Debug.Log("touched dashing power up");
                gameObject.GetComponent<Dashing>().enabled = true;
                dashPot.SetActive(true);
                stamina.SetActive(true);
                asource.PlayOneShot(pickClip);
                Destroy(collision.gameObject);
            }
            catch
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "ActivateWallrunning")
        {
            try
            {
                Debug.Log("touched wallrunning power up");
                gameObject.GetComponent<WallRunningAdvanced>().enabled = true;

                //TODO: Add activation message

                TutorialDialogue.SetActive(false);
                SliddingDialogue.SetActive(false);
                ClimbingDialogue.SetActive(false);
                escapeDialogue.SetActive(false);
                WallrunDialogue.SetActive(true);
                wallrunPot.SetActive(true);
                asource.PlayOneShot(pickClip);
                Destroy(collision.gameObject);
            }
            catch
            {
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.tag == "ActivateLedgeGrabbing")
        {
            try
            {
                Debug.Log("touched ledge grabbing power up");
                gameObject.GetComponent<LedgeGrabbing>().enabled = true;
                ledgegarbPot.SetActive(true);
                asource.PlayOneShot(pickClip);
                Destroy(collision.gameObject);
            }
            catch
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "escaped")
        {
            TutorialDialogue.SetActive(false);
            SliddingDialogue.SetActive(false);
            ClimbingDialogue.SetActive(false);
            escapeDialogue.SetActive(true);
        }
    }

}
