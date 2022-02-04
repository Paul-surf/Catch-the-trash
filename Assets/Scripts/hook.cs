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
    float moveSpeed = 120f;
    private float StartYPos;
    public float VertMoveSpeed = 2f;
    public int TrashCollected = 0;
    public int MaxTrashCollected = 3;
    public GameObject TrashCounterShow;
    public TextMeshProUGUI TrashCounter;
    bool FunctionCalled = false;
    public StartScript RestartScript;
    public GameObject StartGame;
    public GameObject HelpMenu, UpgradeButton;
    public GameObject krog;
    public TextMeshProUGUI _coinTxt;
    public ButtonManager ButtonManagerScript;
    public DepthCounter CounterOfDepth;
    public float coins;
    public bool ReachedMaxDepth = false;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        StartYPos = transform.position.y;
    }
    
    void Update(){
        _coinTxt.text = coins.ToString();
        TrashCounter.text = TrashCollected + "/" + MaxTrashCollected;
        dirX = Input.acceleration.x * moveSpeed;
        if(TrashCollected < MaxTrashCollected && transform.position.y < -230 && ReachedMaxDepth == false) {
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

    
        if(CounterOfDepth.CurrentDepth == CounterOfDepth.MaxDepth+1) {
            ReachedMaxDepth = true;
        }

        if(TrashCollected < MaxTrashCollected) {
            VertMoveSpeed = 2f;
            transform.position = new Vector3(transform.position.x, transform.position.y - VertMoveSpeed, transform.position.z);
            transform.Translate(Vector3.down * VertMoveSpeed * Time.deltaTime);
        }

        if(TrashCollected >= MaxTrashCollected && transform.position.y < StartYPos || ReachedMaxDepth == true) {
            VertMoveSpeed = 9f;
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
            IncreaseGold();
            TrashCollected = 0;
            _coinTxt.text = coins.ToString();
            spawnScript.PrefabFunction();
            ReachedMaxDepth = false;
            UpgradeButton.SetActive(true);
        }
    }

    void IncreaseGold() {
        coins += TrashCollected * 5 * ButtonManagerScript.CoinUpgradeScale;
        // Debug.Log(ButtonManagerScript.CoinUpgradeScale);
        coins = Mathf.Floor(coins);
    }

}
