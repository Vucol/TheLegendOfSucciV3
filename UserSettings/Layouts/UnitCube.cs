using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    [HideInInspector]
    public TurretData turretData;
    [HideInInspector]
    public bool isUpgraded = false;
    public GameObject buildEffect;
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;
        isUpgraded = false;
        turretGo = GameObject.Instantiate(turretData.turretPrefeb, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    public void UpgradeTurret()
    {
        if (isUpgraded == true) return;
        Destroy(turretGo);
        isUpgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradePrefeb, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    public void DismantleTurret()
    {
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        turretData = null;
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    void OnMouseEnter()
    {
        if (turretGo == null && !EventSystem.current.IsPointerOverGameObject())
        {
            renderer.material.color = Color.blue;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
