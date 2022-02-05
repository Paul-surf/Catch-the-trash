using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradePageScript : MonoBehaviour
{
    public GameObject UpgradeButton;
    public TextMeshProUGUI CoinsText;
    public Animator OpenPage;
    public hook HookScript;
    void Start() 
    {
        OpenPage.gameObject.GetComponent<Animator>();
    }
    void Update() {
        HookScript._coinTxt.text = HookScript.coins.ToString();
        CoinsText.text = HookScript.coins.ToString();
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