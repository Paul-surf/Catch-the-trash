using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthCounter : MonoBehaviour
{

    public float CurrentDepth = 0;
    public float MaxDepth = 10;
    public TextMeshProUGUI DepthCounterText;
    public GameObject TheHook;

    void Update() {

        CurrentDepth = Mathf.Floor((TheHook.transform.position.y*(-1))/100);

        DepthCounterText.text = CurrentDepth.ToString() + "m/" + MaxDepth.ToString() + "m";
    }
}
