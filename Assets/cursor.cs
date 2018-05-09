using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour {
    private MeshRenderer meshRenderer;
    public GameObject FocusedObject { get; private set; }
    // Use this for initialization
    void Start()
    {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            //System.Diagnostics.Debug.WriteLine("Hit Enabled");
            meshRenderer.enabled = true;
            this.transform.position = hitInfo.point;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            var newFocusedObject = hitInfo.collider.gameObject;
            if (FocusedObject != null && newFocusedObject != FocusedObject)
            {
                FocusedObject.SendMessage("OnReset");
            }

            FocusedObject = newFocusedObject;
            FocusedObject.SendMessage("OnSelect");
        }
        else
        {
            //System.Diagnostics.Debug.WriteLine("Hit Disabled");
            meshRenderer.enabled = false;
            if (FocusedObject != null)
            {
                FocusedObject.SendMessage("OnReset");
            }
            FocusedObject = null;
        }
    }
}
