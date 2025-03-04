using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class offroadteleport : MonoBehaviour
{

    public GameObject player;
    private Vector3 tpLocation;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.GetStateDown("offroadteleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Fire out the teleport line");
            Ray raycast = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            bool bHit = Physics.Raycast(raycast, out hit);

            if (bHit)
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);

                tpLocation = hit.point;
            }

        }

        if (SteamVR_Input.GetStateUp("offroadteleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Teleport to the intersection point");
            print(tpLocation);
            player.transform.position = tpLocation;

            

        }
    }
}
