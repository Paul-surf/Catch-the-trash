using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePageScript : MonoBehaviour
{
    public GameObject UpgradeButton;
    public Animator OpenPage;
    void Start() 
    {
        OpenPage.gameObject.GetComponent<Animator>();
    }
    public void UpgradesPageFunction() {
        UpgradeButton.SetActive(false);
        OpenPage.SetBool("Active", true);
    }
    public void GoBackFunction() {
        UpgradeButton.SetActive(true);
        OpenPage.SetBool("Active", false);
    }
}