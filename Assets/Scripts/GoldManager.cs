using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public int Gold = 0;

    public void CountGold(int amount) {
        Gold += amount;
        Debug.Log(Gold);
    }
}
