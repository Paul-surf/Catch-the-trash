using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    public GameObject panel;
    public Sprite[] icons;
    public GameObject StartGameButton;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource4;
    public Button Button1, Button2;
    public hook HookScript;
    public TextMeshProUGUI CoinUpgradeCostText;
    public TextMeshProUGUI HookUpgradeCostText;
    public TextMeshProUGUI MaxText;
    public TextMeshProUGUI Disable1;
    public TextMeshProUGUI Disable2;
    public Image HookUpgradeImage;
    public SpriteRenderer HookImage;
    int n;
    int b;
    int c;
    int d;
    int e = 1;
    public float CoinUpgradeScale = 1;
    public float CoinUpgradeCost = 25;
    public float HookUpgradeCost = 100;

    void Update() {
        HookScript._coinTxt.text = HookScript.coins.ToString();
        CoinUpgradeCostText.text = CoinUpgradeCost.ToString() + "g";
        if(e < 6) {
            HookUpgradeCostText.text = HookUpgradeCost.ToString() + "g";
        }
        if(Input.GetKeyDown(KeyCode.M)) {
            HookScript.coins += 1000;
        }

        if(HookScript.coins - CoinUpgradeCost >= 0) {
            Button2.interactable = true;
        } else {   
            Button2.interactable = false;
        }
        
        if(HookScript.coins - HookUpgradeCost >= 0 && e < 6) {
            Button1.interactable = true;
        } else {   
            Button1.interactable = false;
        }

    }

    public void OnButtonHelpPress()
    {
        n++;
        if (n%2 == 0) {
            panel.SetActive(false);
            StartGameButton.SetActive(true);
        } else {
            panel.SetActive(true);
            StartGameButton.SetActive(false);
        }
        if (n%10 == 0) {
            audioSource.Play();
        }
    }

    public void box1Effects() {
        b++;
        if (n%2 == 0) {
            audioSource2.Play();
        } else {
            audioSource2.Play();
        }
        
    }
    public void box2Effects() {
        d++;
        if (n%2 == 0) {
            audioSource4.Play();
        } else {
            audioSource4.Play();
        }
    }

    public void GoldUpgrade() {
        if(HookScript.coins - CoinUpgradeCost >= 0) {
            HookScript.coins -= CoinUpgradeCost;
            CoinUpgradeScale *= 1.1f;
            HookScript._coinTxt.text = HookScript.coins.ToString();
            CoinUpgradeCost *= 1.2f;
            CoinUpgradeCost = Mathf.Floor(CoinUpgradeCost);
        }
    }

    public void HookUpgrade() {
        e++;
        if(e < 6) {
            if(HookScript.coins - HookUpgradeCost >= 0) {
                HookScript.coins -= HookUpgradeCost;
                HookScript._coinTxt.text = HookScript.coins.ToString();
                HookUpgradeImage.sprite = icons[e];
                HookImage.sprite = icons[e-1];
                HookUpgradeCost *= 3f;
                HookUpgradeCost = Mathf.Floor(HookUpgradeCost);
                if(e == 5) {
                    HookScript.MaxTrashCollected += 10;
                } else {
                    HookScript.MaxTrashCollected += 1;
                }
            }
        } else {
            Button1.interactable = false;
            if(e == 6) {
                HookScript.coins -= HookUpgradeCost;
                HookImage.sprite = icons[e-1];
            }
            MaxText.text = "Maxed";
            Disable1.text = "";
            Disable2.text = "";
            HookUpgradeImage.enabled = false;
        }
    }

    // public void HookUpgrade() {
        
    // }
}
