using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hook : MonoBehaviour
{
    Rigidbody2D rb;
    public TerrainScript terrainScript;
    public SpawnScript spawnScript;

    float dirX;
    float moveSpeed = 60f;
    private float StartYPos;
    public float VertMoveSpeed = 2f;
    public int TrashCollected = 0;
    public int MaxTrashCollected = 3;
    public GameObject TrashCounterShow;
    public TextMeshProUGUI TrashCounter;
    bool FunctionCalled = false;
    public StartScript RestartScript;
    public GameObject StartGame;
    public GameObject HelpMenu;
    public GameObject b1;
    public GameObject b2;
    public GameObject krog;
    public TextMeshProUGUI _coinTxt;
    public ButtonManager ButtonManagerScript;
    public float coins;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        StartYPos = transform.position.y;
    }
    
    void Update(){
        _coinTxt.text = coins.ToString();
        TrashCounter.text = TrashCollected + "/" + MaxTrashCollected;
        dirX = Input.acceleration.x * moveSpeed;
        if(TrashCollected < MaxTrashCollected && transform.position.y < -230) {
            rb.velocity = new Vector2(dirX, 0f);
            if(Input.GetKey(KeyCode.RightArrow)) {
                rb.velocity = new Vector2(30, 0f);
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                rb.velocity = new Vector2(-30, 0f);
            }
            transform.position = new Vector2 (Mathf.Clamp(transform.position.x, terrainScript.NewWidth/-2+10, terrainScript.NewWidth/2-10), transform.position.y);
        } else {
            if(transform.position.x < -4) {
                transform.position = new Vector2 (transform.position.x + 1, transform.position.y);
            }
            if(transform.position.x > 0) {
                transform.position = new Vector2 (transform.position.x - 1, transform.position.y);
            }
            if(transform.position.x > -4 && transform.position.x < 0) {
                transform.position = new Vector2 (-2, transform.position.y);
            }
        }
    }

    void FixedUpdate() {
        if(TrashCollected < MaxTrashCollected) {
            VertMoveSpeed = 2f;
            transform.position = new Vector3(transform.position.x, transform.position.y - VertMoveSpeed, transform.position.z);
            transform.Translate(Vector3.down * VertMoveSpeed * Time.deltaTime);
        }

        if(TrashCollected >= MaxTrashCollected && transform.position.y < StartYPos-6f) {
            VertMoveSpeed = 6f;
            transform.position = new Vector3(transform.position.x, transform.position.y + VertMoveSpeed, transform.position.z);
            transform.Translate(Vector3.up * VertMoveSpeed * Time.deltaTime);
            FunctionCalled = true;
        }

        if (FunctionCalled && transform.position.y >= -21) {
            Debug.Log("Done!");
            FunctionCalled = false;
            krog.SetActive(false);
            TrashCounterShow.SetActive(false);
            StartGame.SetActive(true);
            HelpMenu.SetActive(true);
            b1.SetActive(true);
            b2.SetActive(true);
            IncreaseGold();
            TrashCollected = 0;
            _coinTxt.text = coins.ToString();
            spawnScript.PrefabFunction();
        }
    }

    void IncreaseGold() {
        coins += TrashCollected * 5 * ButtonManagerScript.CoinUpgradeScale;
        Debug.Log(ButtonManagerScript.CoinUpgradeScale);
        coins = Mathf.Floor(coins);
    }

}
