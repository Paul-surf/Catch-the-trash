using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HelpPanelScript : MonoBehaviour
{
    public GameObject UpgradeButton, StartText, helpPanel;
    public Animator HelpPanel;
    int NumberOfTimesPressed = 0;
    void Awake() {
        if (HelpPanel.GetBool("Active") == true) 
        {
            UpgradeButton.SetActive(false);
            StartText.SetActive(false);
        }
    }
    void Start()
    {
        HelpPanel.gameObject.GetComponent<Animator>();
    }

    public void HelpButtonScript() 
    {
        NumberOfTimesPressed++;
        if (NumberOfTimesPressed % 2 == 0)
        {
            HelpPanel.SetBool("Active", true);
            UpgradeButton.SetActive(false);
            StartText.SetActive(false);
        }
        else 
        {
            HelpPanel.SetBool("Active", false);
            UpgradeButton.SetActive(true);
            StartText.SetActive(true);
        }
    }
}