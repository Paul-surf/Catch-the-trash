using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    public GameObject panel;
    public Sprite[] icons;
    public GameObject StartGameButton, upgradeButton;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource4;
    public Button CoinUpgradeButton, CapacityUpgradeButton, DepthUpgradeButton, HookUpgradeButton;
    public hook HookScript;
    public DepthCounter DepthCounterScript;
    public TextMeshProUGUI CoinUpgradeCostText, CapacityUpgradeCostText, DepthUpgradeCostText, HookUpgradeCostText;
    public TextMeshProUGUI CoinLvText, CapacityLvText, DepthLvText, HookLvText;
    public GameObject HookMaxText, DepthMaxText, CapacityMaxText, CoinMaxText;
    public TextMeshProUGUI DisableHookText, DisableDepthText, DisableCapacityText, DisableCoinText;
    public Image HookUpgradeImage;
    public SpriteRenderer HookImage;
    int n, b, c, d, e = 0, f = 0, g = 0, h = 0, HookLv = 1, DepthLv = 1, CapacityLv = 1, GoldLv = 1;
    public float CoinUpgradeScale = 1;
    public float CoinUpgradeCost = 15, CapacityUpgradeCost = 20, DepthUpgradeCost = 25;
    public float HookUpgradeCost = 50;
    void Update() {
        // Letting HookScript.coins be equal to our coins
        HookScript._coinTxt.text = HookScript.coins.ToString();
        // As long this condition is met, the upgrades have a price
        // If this was done without the if statement, we wouldn't be
        // To delete the text unless we used GameObjects
        if (h < 5) {
            CoinUpgradeCostText.text = CoinUpgradeCost.ToString() + "g";
        }
        if (f < 4) {
            DepthUpgradeCostText.text = DepthUpgradeCost.ToString() + "g";
        }
        if (g < 3) {
            CapacityUpgradeCostText.text = CapacityUpgradeCost.ToString() + "g";
        }
        if(e < 5) {
            HookUpgradeCostText.text = HookUpgradeCost.ToString() + "g";
        }
        // Little cheat code for PC users
        if(Input.GetKeyDown(KeyCode.M)) {
            HookScript.coins += 1000;
        }
        // Checking if you can upgrade ur coin mulitplier
        if(HookScript.coins - CoinUpgradeCost >= 0) {
            CoinUpgradeButton.interactable = true;
        } else {   
            CoinUpgradeButton.interactable = false;
        }
        // Checking if you can upgrade ur capacity
        if (HookScript.coins - CapacityUpgradeCost >= 0) {
            CapacityUpgradeButton.interactable = true;
        } else {
            CapacityUpgradeButton.interactable = false;
        }
        // Checking if you can upgrade ur depth upgrade
        if (HookScript.coins - DepthUpgradeCost >= 0) {
            DepthUpgradeButton.interactable = true;
        } else {
            DepthUpgradeButton.interactable = false;
        }
        // Checking if you can upgrade ur Hook
        if(HookScript.coins - HookUpgradeCost >= 0 && e < 6) {
            HookUpgradeButton.interactable = true;
        } else {   
            HookUpgradeButton.interactable = false;
        }

    }
// Heres the tutorial button
    public void OnButtonHelpPress()
    {
        n++;
        if (n%2 == 0) {
            panel.SetActive(false);
            StartGameButton.SetActive(true);
            upgradeButton.SetActive(true);
        } else {
            panel.SetActive(true);
            StartGameButton.SetActive(false);
            upgradeButton.SetActive(false);
        }
        if (n%10 == 0) {
            audioSource.Play();
        }
    }
    // Heres the source code for all our upgrades
    public void GoldUpgrade() {
        h++;
        if(h < 5 && HookScript.coins - CoinUpgradeCost >= 0) {
            HookScript.coins -= CoinUpgradeCost;
            CoinUpgradeScale *= 1.3f;
            HookScript._coinTxt.text = HookScript.coins.ToString();
            CoinUpgradeCost *= 2;
            GoldLv += 1;
            CoinLvText.text = "Lv " + GoldLv.ToString();
        } else if (h == 5 && GoldLv == 5) {
            CoinUpgradeButton.interactable = false;
            CoinLvText.text = "Lv Max";
            DisableCoinText.text = "";
            CoinMaxText.SetActive(true);
            CoinUpgradeCostText.text = "";
        }
    }

    public void CapacityUpgrade() {
        g++;
        if (g < 3 && HookScript.coins - CapacityUpgradeCost >= 0) {
            HookScript.coins -= CapacityUpgradeCost;
            HookScript.MaxTrashCollected += 1;
            CapacityLv += 1;
            CapacityLvText.text = "Lv " + CapacityLv.ToString();
            CapacityUpgradeCost *= 2.5f;
        } else if (g == 3 && CapacityLv == 3) {
            CapacityUpgradeButton.interactable = false;
            CapacityLvText.text = "Lv Max";
            DisableCapacityText.text = "";
            CapacityMaxText.SetActive(true);
            CapacityUpgradeCostText.text = "";
        }
    }
    public void DepthUpgrade() {
        f++;
        if (f < 4 && HookScript.coins - DepthUpgradeCost >= 0) {
            HookScript.coins -= DepthUpgradeCost;
            DepthCounterScript.MaxDepth += 5;
            DepthLv += 1;
            DepthLvText.text = "Lv " + DepthLv.ToString();
            DepthUpgradeCost = Mathf.Floor(DepthUpgradeCost * 1.75f);
        } else if (f == 4 && DepthLv == 4) {
            DepthUpgradeButton.interactable = false;
            DepthLvText.text = "Lv Max";
            DisableDepthText.text = "";
            DepthMaxText.SetActive(true);
            DepthUpgradeCostText.text = "";
        }

    }
    public void HookUpgrade() {
        e++;
        if(e < 5 && HookScript.coins - HookUpgradeCost >= 0) {
            HookScript.coins -= HookUpgradeCost;
            HookScript._coinTxt.text = HookScript.coins.ToString();
            HookUpgradeImage.sprite = icons[e];
            HookImage.sprite = icons[e-1];
            HookUpgradeCost = Mathf.Floor(HookUpgradeCost * 2);
            HookLv += 1;
            HookLvText.text = "Lv " + HookLv.ToString();
            HookScript.MaxTrashCollected += 1;
        } else if(e == 5) {
            HookUpgradeButton.interactable = false;
            HookLv += 1;
            HookLvText.text = "Lv Max";
            HookScript.coins -= HookUpgradeCost;
            HookImage.sprite = icons[e-1];
            HookScript.MaxTrashCollected += 5;
            HookMaxText.SetActive(true);
            HookUpgradeCostText.text = "";
            DisableHookText.text = "";
        }
    }

// Here is some commented out sound effects since we didn't want these in.
        // public void box1Effects() {
    //     b++;
    //     if (n%2 == 0) {
    //         audioSource2.Play();
    //     } else {
    //         audioSource2.Play();
    //     }
        
    // }
    // public void box2Effects() {
    //     d++;
    //     if (n%2 == 0) {
    //         audioSource4.Play();
    //     } else {
    //         audioSource4.Play();
    //     }
    // }
}
