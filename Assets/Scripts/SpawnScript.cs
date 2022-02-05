using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform Background_1, Background_2;

    public GameObject TrashObject, FishObject, Fish2Object, BottleObject, BagObject;

    public hook HookScript;

    private CameraControl CameraObject;
    // private GameObject PrefabCopies1, PrefabCopies2, PrefabCopies3, PrefabCopies4, PrefabCopies5, PrefabCopies6, PrefabCopies7, PrefabCopies8, PrefabCopies9, PrefabCopies10;
 
    private float NewMoveBackground;

    public List<GameObject> TrashCloneList = new List<GameObject>();
    public List<GameObject> FishCloneList = new List<GameObject>();
    public List<GameObject> Fish2CloneList = new List<GameObject>();
    public List<GameObject> BottleCloneList = new List<GameObject>();
    public List<GameObject> BagCloneList = new List<GameObject>();


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
        // yield return new WaitForSeconds(1/4);
        PrefabFunction();
        yield return new WaitForSeconds(1/2);
        NewMoveBackground = 2;
        PrefabFunction();
    }

    public void PrefabFunction() {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[]) {
            if(gameObj.name == "Trash(Clone)") {
                TrashCloneList.Add(gameObj);
            } else if (gameObj.name == "Fish(Clone)") {
                FishCloneList.Add(gameObj);
            } else if (gameObj.name == "Bottle(Clone)") {
                FishCloneList.Add(gameObj);
            } else if (gameObj.name == "Bag(Clone)") {
                FishCloneList.Add(gameObj);
            } else if (gameObj.name == "Fish2(Clone)") {
                FishCloneList.Add(gameObj);
            }
        }
        if((HookScript.TrashCollected + HookScript.FishCollected) < HookScript.MaxTrashCollected) {
            for(int i = 0; i < TrashCloneList.Count-4; i++) {
                Destroy(TrashCloneList[i]);
            } 
            for(int i = 0; i < 1; i++) {
                float randomX = Random.Range(-100, 100);
                float randomY = Random.Range(-140, 140);
                if((HookScript.TrashCollected + HookScript.FishCollected) < HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 1 && Background_1.position.y < -300) {
                        Instantiate(TrashObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 2) {
                        Instantiate(TrashObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
                if((HookScript.TrashCollected + HookScript.FishCollected) >= HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 2) {
                        Instantiate(TrashObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 1) {
                        Instantiate(TrashObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
            for(int j = 0; j < FishCloneList.Count-4; j++) {
                Destroy(FishCloneList[j]);
            }
            for(int j = 0; j < 1; j++) {
                float randomX = Random.Range(100, -100);
                float randomY = Random.Range(140, -140);
                if((HookScript.FishCollected + HookScript.TrashCollected) < HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 1 && Background_1.position.y < -300) {
                        Instantiate(FishObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 2) {
                        Instantiate(FishObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
                if((HookScript.TrashCollected + HookScript.FishCollected) >= HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 2) {
                        Instantiate(FishObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 1) {
                        Instantiate(FishObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
            for(int j = 0; j < Fish2CloneList.Count-4; j++) {
                Destroy(Fish2CloneList[j]);
            }
            for(int j = 0; j < 1; j++) {
                float randomX = Random.Range(100, -100);
                float randomY = Random.Range(140, -140);
                if((HookScript.FishCollected + HookScript.TrashCollected) < HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 1 && Background_1.position.y < -300) {
                        Instantiate(Fish2Object, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 2) {
                        Instantiate(Fish2Object, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
                if((HookScript.TrashCollected + HookScript.FishCollected) >= HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 2) {
                        Instantiate(Fish2Object, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 1) {
                        Instantiate(Fish2Object, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
            for(int j = 0; j < BagCloneList.Count-4; j++) {
                Destroy(BagCloneList[j]);
            }
            for(int j = 0; j < 1; j++) {
                float randomX = Random.Range(100, -100);
                float randomY = Random.Range(140, -140);
                if((HookScript.FishCollected + HookScript.TrashCollected) < HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 1 && Background_1.position.y < -300) {
                        Instantiate(BagObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 2) {
                        Instantiate(BagObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
                if((HookScript.TrashCollected + HookScript.FishCollected) >= HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 2) {
                        Instantiate(BagObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 1) {
                        Instantiate(BagObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
            for(int j = 0; j < BottleCloneList.Count-4; j++) {
                Destroy(BottleCloneList[j]);
            }
            for(int j = 0; j < 1; j++) {
                float randomX = Random.Range(100, -100);
                float randomY = Random.Range(140, -140);
                if((HookScript.FishCollected + HookScript.TrashCollected) < HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 1 && Background_1.position.y < -300) {
                        Instantiate(BottleObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 2) {
                        Instantiate(BottleObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
                if((HookScript.TrashCollected + HookScript.FishCollected) >= HookScript.MaxTrashCollected) {
                    if(NewMoveBackground == 2) {
                        Instantiate(BottleObject, new Vector3(randomX, Background_1.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }

                    if(NewMoveBackground == 1) {
                        Instantiate(BottleObject, new Vector3(randomX, Background_2.position.y + randomY, -19/2), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
        } //Her er if statement 
    }
}
