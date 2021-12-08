using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform Background_1, Background_2;

    public GameObject TrashObject;

    public hook HookScript;

    private CameraControl CameraObject;
    private GameObject PrefabCopies1, PrefabCopies2, PrefabCopies3, PrefabCopies4, PrefabCopies5;

    private float NewMoveBackground;

    private List<GameObject> CloneList = new List<GameObject>();


    // Start is called before the first frame update
    void Start() {
        StartCoroutine(WaitFunction());
    }

    // Update is called once per frame
    void Update() {
        if(CameraObject != null) { NewMoveBackground = CameraObject.MoveBackground; }
        
    }

    IEnumerator WaitFunction() {
        yield return new WaitForSeconds(1/2);
        CameraObject = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        yield return new WaitForSeconds(1/4);
        PrefabFunction();
        yield return new WaitForSeconds(1/4);
        NewMoveBackground = 2;
        PrefabFunction();
    }

    public void PrefabFunction() {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[]) {
            if(gameObj.name == "Trash(Clone)") {
                CloneList.Add(gameObj);
            }
        }
        if(HookScript.TrashCollected < HookScript.MaxTrashCollected) {
            for(int i = 0; i < CloneList.Count-4; i++) {
                Destroy(CloneList[i]);
            }
        }
        for(int i = 0; i < 2; i++) {
            float randomX = Random.Range(-100, 100);
            float randomY = Random.Range(-140, 140);
            if(HookScript.TrashCollected < HookScript.MaxTrashCollected) {
                if(NewMoveBackground == 1) {
                    if(Background_1.position.y < -300) {
                        Instantiate(TrashObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }

                if(NewMoveBackground == 2) {
                    Instantiate(TrashObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                }
            }
            if(HookScript.TrashCollected >= HookScript.MaxTrashCollected) {
                if(NewMoveBackground == 2) {
                    Instantiate(TrashObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                }

                if(NewMoveBackground == 1) {
                    Instantiate(TrashObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}
