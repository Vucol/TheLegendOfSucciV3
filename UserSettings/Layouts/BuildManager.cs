using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    public TurretData selectedTurretData;
    private UnitCube selectedUnitCube;
    public Text moneyText;
    private int money = 1000;
    public GameObject upgradeCanvas;
    public Button buttonUpgrade;
    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "$" + money;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("UnitCube"));
                if (isCollider)
                {
                    UnitCube unitCube = hit.collider.GetComponent<UnitCube>();
                    if (unitCube.turretGo == null && selectedTurretData != null)
                    {
                        if (money > selectedTurretData.cost){
                            ChangeMoney(-selectedTurretData.cost);
                            unitCube.BuildTurret(selectedTurretData);
                        }
                        else
                        {
                            
                        }
                    }
                    else if (unitCube.turretGo != null)
                    {
                        if (unitCube == selectedUnitCube && upgradeCanvas.activeInHierarchy)
                        {
                            HideUpgradeUI();
                        }
                        else
                        {
                            ShowUpgradeUI(unitCube.transform.position, unitCube.isUpgraded);
                        }
                        selectedUnitCube = unitCube;
                    }
                }
            }
        }
    }
    public void OnLaserSelected(bool isON)
    {
        if(isON)
        {
            selectedTurretData = laserTurretData;
        }
    }
    public void OnMissileSelected(bool isON)
    {
        if(isON)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnStandardSelected(bool isON)
    {
        if(isON)
        {
            selectedTurretData = standardTurretData;
        }
    }
    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade = false)
    {
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }
    void HideUpgradeUI()
    {
        upgradeCanvas.SetActive(false);
    }
    
    public void OnUpgradeButtonDown()
    {
        if (money >= selectedUnitCube.turretData.costUpgrade)
        {
            ChangeMoney(-selectedUnitCube.turretData.costUpgrade);
            selectedUnitCube.UpgradeTurret();
        }
        
        // StartCoroutine(HideUpgradeUI());
    }
    public void OnDismantleButtonDown()
    {
        selectedUnitCube.DismantleTurret();
        // StartCoroutine(HideUpgradeUI());
    }
}
