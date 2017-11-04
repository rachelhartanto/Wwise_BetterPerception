using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{


    //    [RequireComponent(typeof(AudioSource))]
    //    [RequireComponent(typeof(CharacterController))]

    private CharacterController _controller;

    bool isPlaying;



    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Use this for initialization


    void Update()
    {

        //        RaycastHit hit;
        //        Ray landingRay = new Ray(transform.position, Vector3.down);

        //        if (Physics.Raycast (landingRay, out hit, 1f)) {
        //
        //
        //            if (hit.collider.tag == "Terrain") {
        //
        //                Debug.Log ("Terrain");
        //            } 
        //            else if (hit.collider.tag == "Concrete") {
        //
        //                Debug.Log ("Concrete");
        //            } 
        //            else if (hit.collider.tag == "Wood") {
        //
        //                Debug.Log ("Wood");
        //            }
        //            else if (hit.collider.tag == "Tile") {
        //
        //                Debug.Log ("Tile");
        //            }
        //            else if (hit.collider.tag == "BathroomTile") {
        //
        //                Debug.Log ("BathroomTile");
        //            }
        //            else if (hit.collider.tag == "SoftTile") {
        //
        //                Debug.Log ("SoftTile");
        //            }
        //        }



        if (Input.GetAxis("Horizontal") > 0.1f && isPlaying == false)
        {
            StartCoroutine("FootStep");
        }


        if (Input.GetAxis("Horizontal") < -0.1f && isPlaying == false)
        {
            StartCoroutine("FootStep");
        }


        if (Input.GetAxis("Vertical") > 0.1f && isPlaying == false)
        {
            StartCoroutine("FootStep");
        }


        if (Input.GetAxis("Vertical") < -0.1f && isPlaying == false)
        {
            StartCoroutine("FootStep");

        }

    }






    IEnumerator FootStep()
    {

        isPlaying = true;


        RaycastHit hit = new RaycastHit();


        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            tag = hit.collider.gameObject.tag;
            if (tag == "Terrain")
            {
                AkSoundEngine.SetSwitch("Footsteps", "Terrain", gameObject);
            }
            else if (tag == "Concrete")
            {
                AkSoundEngine.SetSwitch("Footsteps", "Concrete", gameObject);
            }
            else if (tag == "Wood")
            {
                AkSoundEngine.SetSwitch("Footsteps", "Wood", gameObject);
            }
            else if (tag == "Tile")
            {
                AkSoundEngine.SetSwitch("Footsteps", "Tile", gameObject);
            }
            else if (tag == "BathroomTile")
            {
                AkSoundEngine.SetSwitch("Footsteps", "BathroomTile", gameObject);
            }
            else if (tag == "SoftTile")
            {
                AkSoundEngine.SetSwitch("Footsteps", "SoftTile", gameObject);
            }
        }

        AkSoundEngine.PostEvent("Footsteps", gameObject);

        yield return new WaitForSeconds(0.5f);


        isPlaying = false;
        //                }
        //                else {
        //                    yield return 0;
        //                }
        //            }
        //        AkSoundEngine.PostEvent ("Footsteps", gameObject);

    }

    private void PlayFootStepAudio()
    {
        if (_controller.isGrounded)
        {
            return;
        }
    }
}