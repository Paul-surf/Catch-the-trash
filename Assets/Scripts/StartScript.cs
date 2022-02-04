using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{  
        public GameObject hook;
        public GameObject terrain;
        public GameObject button, UpgradeButton;
        public GameObject FishingGuy;

        public Transform Cloud1, Cloud2;
        public BoxCollider2D AirLayerBox;
        private float StartOfScreen;
        private float EndOfScreen;
        private float ms = 1/5f;

        public Sprite Fishing;
        private SpriteRenderer spriteR;
        public GameObject Guy;

        public GameObject snor;
        public GameObject helpButton;
        public GameObject trashCounter;
        public AudioSource earrape;

        MoveTrashScript moveTrashScript;
 
    void Start() {
        StartOfScreen = AirLayerBox.bounds.extents.x + 1;
        EndOfScreen = +StartOfScreen;
        spriteR = Guy.GetComponent<SpriteRenderer>();
        moveTrashScript = GameObject.FindGameObjectWithTag("MoveTrashTag").GetComponent<MoveTrashScript>();
    }

    void Update() {
        Cloud1.position = new Vector3(Cloud1.position.x+ms, Cloud1.position.y, Cloud1.position.z);
        Cloud2.position = new Vector3(Cloud2.position.x+ms, Cloud2.position.y, Cloud2.position.z);

        if(Cloud1.position.x > EndOfScreen) {
            Cloud1.position = new Vector3(Cloud1.position.x*-1, Cloud1.position.y, Cloud1.position.z);
        }
        if(Cloud2.position.x > EndOfScreen) {
            Cloud2.position = new Vector3(Cloud2.position.x*-1, Cloud2.position.y, Cloud2.position.z);
        }
    }

    public void StartGame() {
        button.SetActive(false);
        earrape.Play();
        button.SetActive(false);
        terrain.SetActive(true);
        UpgradeButton.SetActive(false);
        FishingGuy.GetComponentInChildren<Animator>().Play("StartFishing");
        spriteR.sprite = Fishing;
        Invoke("EnableHook", 0.6f);
    }

    private void EnableHook() {
        hook.SetActive(true);
        trashCounter.SetActive(true);
        helpButton.SetActive(false);
    }
}
