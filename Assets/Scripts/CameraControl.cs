using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform target;

    public Transform bg1;
    public Transform bg2;
    public RectTransform Terrain;

    TerrainScript terrainScript;
    SpawnScript spawnScript;

    public float MoveBackground = 1;
    private bool MovingDown;
    private float LastYPosition;
    
    public float height;
    public float width;

    void Start() {
        Camera cam = GetComponent<Camera>();

        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        LastYPosition = target.position.y;

        terrainScript = GameObject.FindGameObjectWithTag("TerrainTag").GetComponent<TerrainScript>(); 
        spawnScript = GameObject.FindGameObjectWithTag("SpawnTag").GetComponent<SpawnScript>(); 

    }

    void Update() {
        //Camera
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = targetPos;

        //Background
        if(LastYPosition > target.position.y) {
            MovingDown = true;
            LastYPosition = target.position.y;
        } else {
            MovingDown = false;
            LastYPosition = target.position.y;
        }

        if(MovingDown) {
            if(target.position.y <= bg2.position.y && target.position.y <= bg1.position.y && target.position.y < -250 && MoveBackground == 1) {
                bg1.position = new Vector3(bg1.position.x, bg1.position.y-600, bg1.position.z);
                spawnScript.PrefabFunction();
                MoveBackground++;
                terrainScript.ChoosePreset();
            }

            if(target.position.y <= bg1.position.y && target.position.y <= bg2.position.y && target.position.y < -250 && MoveBackground == 2) {
                bg2.position = new Vector3(bg2.position.x, bg2.position.y-600, bg2.position.z);
                spawnScript.PrefabFunction();
                MoveBackground--;
                terrainScript.ChoosePreset();
            }
        } else if(MovingDown == false){
            if(target.position.y >= bg2.position.y && target.position.y >= bg1.position.y && target.position.y < -250 && MoveBackground == 1) {
                bg2.position = new Vector3(bg2.position.x, bg2.position.y+600, bg2.position.z);
                spawnScript.PrefabFunction();
                MoveBackground++;
                terrainScript.ChoosePresetFromList();
            }

            if(target.position.y >= bg1.position.y && target.position.y >= bg2.position.y && target.position.y < -250 && MoveBackground == 2) {
                bg1.position = new Vector3(bg1.position.x, bg1.position.y+600, bg1.position.z);
                spawnScript.PrefabFunction();
                MoveBackground--;
                terrainScript.ChoosePresetFromList();
            }
        }
    }
}
