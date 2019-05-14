using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset; //because the turret spawns inside node 


    private GameObject turret;

    private Renderer rend;

    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }


    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't Build There - TODO DISPLAY ON SCREEN");
            return;
        }

        //build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    void OnMouseEnter() // Mouse over highlight 
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
