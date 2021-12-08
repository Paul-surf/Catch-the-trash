using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    public Transform Stone1_1, Stone2_1, Stone3_1, Stone4_1, Stone5_1, RedCoral_1, GreenCoral_1, PinkCoral_1, PurpleCoral_1;
    public Transform Stone1_2, Stone2_2, Stone3_2, Stone4_2, Stone5_2, RedCoral_2, GreenCoral_2, PinkCoral_2, PurpleCoral_2;

    public RectTransform TerrainCanvas_1, TerrainCanvas_2;
    public Transform bg1, bg2;

    private CameraControl CameraObject;
    public float NewWidth;
    private float NewMoveBackground;

    public static List<int> PresetList = new List<int>();

    private bool IsUp = false;
    private bool FirstUp = true;

    void Start() {
        StartCoroutine(FindWidth());
    }

    IEnumerator FindWidth() {
        yield return new WaitForSeconds(1/3);
        CameraObject = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        NewWidth = CameraObject.width;
        NewMoveBackground = 1;
        ChoosePreset();
        yield return new WaitForSeconds(1/3);
        NewMoveBackground = 2;
        ChoosePreset();
    }

    public void ChoosePreset() {
        IsUp = false;
        int RandomNum = Random.Range(1, 4);
        if(RandomNum == 1) { Preset1(); PresetList.Add(1); }
        if(RandomNum == 2) { Preset2(); PresetList.Add(2); }
        if(RandomNum == 3) { Preset3(); PresetList.Add(3); }
    }

    public void ChoosePresetFromList() {
        if(FirstUp) {
            PresetList.RemoveRange(PresetList.Count-2, 2);
            FirstUp = false;
        } else {
            PresetList.RemoveAt(PresetList.Count-1);
        }
        int LastPreset = PresetList[PresetList.Count-1];
        IsUp = true;
        if(LastPreset == 1) { Preset1(); }
        if(LastPreset == 2) { Preset2(); }
        if(LastPreset == 3) { Preset3(); }
    }
    

    void Preset1() {

        if (NewMoveBackground == 1 && IsUp == false || NewMoveBackground == 2 && IsUp == true) {
        //Background 1 Preset
            //Left Side Of Screen
            Stone1_1.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_1.localPosition.y + 49, Stone1_1.position.z);
            Stone2_1.position = new Vector3((NewWidth/(-2))+14/2, TerrainCanvas_1.localPosition.y - 67, Stone2_1.position.z);
            Stone5_1.position = new Vector3((NewWidth/(-2))+11/2, TerrainCanvas_1.localPosition.y - 121, Stone5_1.position.z);
            PurpleCoral_1.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_1.localPosition.y + 109, PurpleCoral_1.position.z);
            GreenCoral_1.position = new Vector3((NewWidth/(-2))+4, TerrainCanvas_1.localPosition.y - 16, GreenCoral_1.position.z);

            Stone1_1.eulerAngles = new Vector3(Stone1_1.rotation.x, Stone1_1.rotation.y, -7532/100);
            Stone2_1.eulerAngles = new Vector3(Stone2_1.rotation.x, Stone2_1.rotation.y, -808/10);
            Stone5_1.eulerAngles = new Vector3(Stone5_1.rotation.x, Stone5_1.rotation.y, 0);
            PurpleCoral_1.eulerAngles = new Vector3(PurpleCoral_1.rotation.x, PurpleCoral_1.rotation.y, -657/10);
            GreenCoral_1.eulerAngles = new Vector3(GreenCoral_1.rotation.x, GreenCoral_1.rotation.y, -803/10);
            
            //Right Side Of Screen
            Stone3_1.position = new Vector3((NewWidth/2)-4, TerrainCanvas_1.localPosition.y - 94, Stone3_1.position.z);
            Stone4_1.position = new Vector3((NewWidth/2)-7, TerrainCanvas_1.localPosition.y + 31, Stone4_1.position.z);
            RedCoral_1.position = new Vector3((NewWidth/2)-8, TerrainCanvas_1.localPosition.y - 36, RedCoral_1.position.z);
            PinkCoral_1.position = new Vector3((NewWidth/2)-7, TerrainCanvas_1.localPosition.y + 96, PinkCoral_1.position.z);

            Stone3_1.eulerAngles = new Vector3(Stone3_1.rotation.x, Stone3_1.rotation.y, 0);
            Stone4_1.eulerAngles = new Vector3(Stone4_1.rotation.x, Stone4_1.rotation.y, -2606/10);
            PinkCoral_1.eulerAngles = new Vector3(PinkCoral_1.rotation.x, PinkCoral_1.rotation.y, 10704/100);
            RedCoral_1.eulerAngles = new Vector3(RedCoral_1.rotation.x, RedCoral_1.rotation.y, 744/10);
        }

        if(NewMoveBackground == 2 && IsUp == false || NewMoveBackground == 1 && IsUp == true) {
        // Background 2 Preset
            //Left Side Of Screen
            Stone1_2.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_2.localPosition.y + 49, Stone1_2.position.z);
            Stone2_2.position = new Vector3((NewWidth/(-2))+4, TerrainCanvas_2.localPosition.y - 67, Stone2_2.position.z);
            Stone5_2.position = new Vector3((NewWidth/(-2))+4, TerrainCanvas_2.localPosition.y - 121, Stone5_2.position.z);
            PurpleCoral_2.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_2.localPosition.y + 109, PurpleCoral_2.position.z);
            GreenCoral_2.position = new Vector3((NewWidth/(-2))+4, TerrainCanvas_2.localPosition.y - 16, GreenCoral_2.position.z);

            Stone1_2.eulerAngles = new Vector3(Stone1_2.rotation.x, Stone1_2.rotation.y, -7532/100);
            Stone2_2.eulerAngles = new Vector3(Stone2_2.rotation.x, Stone2_2.rotation.y, -808/10);
            Stone5_2.eulerAngles = new Vector3(Stone5_2.rotation.x, Stone5_2.rotation.y, 0);
            PurpleCoral_2.eulerAngles = new Vector3(PurpleCoral_2.rotation.x, PurpleCoral_2.rotation.y, -657/10);
            GreenCoral_2.eulerAngles = new Vector3(GreenCoral_2.rotation.x, GreenCoral_2.rotation.y, -803/10);
            
            //Right Side Of Screen
            Stone3_2.position = new Vector3((NewWidth/2)-5, TerrainCanvas_2.localPosition.y - 94, Stone3_2.position.z);
            Stone4_2.position = new Vector3((NewWidth/2)-6, TerrainCanvas_2.localPosition.y + 31, Stone4_2.position.z);
            RedCoral_2.position = new Vector3((NewWidth/2)-8, TerrainCanvas_2.localPosition.y - 36, RedCoral_2.position.z);
            PinkCoral_2.position = new Vector3((NewWidth/2)-7, TerrainCanvas_2.localPosition.y + 96, PinkCoral_2.position.z);

            Stone3_2.eulerAngles = new Vector3(Stone3_2.rotation.x, Stone3_2.rotation.y, 0);
            Stone4_2.eulerAngles = new Vector3(Stone4_2.rotation.x, Stone4_2.rotation.y, -2606/10);
            PinkCoral_2.eulerAngles = new Vector3(PinkCoral_2.rotation.x, PinkCoral_2.rotation.y, 10704/100);
            RedCoral_2.eulerAngles = new Vector3(RedCoral_2.rotation.x, RedCoral_2.rotation.y, 744/10);
        }
    }

    void Preset2() {
        if (NewMoveBackground == 1 && IsUp == false || NewMoveBackground == 2 && IsUp == true) {
        //Background 1 Preset
            //Left Side Of Screen
            PinkCoral_1.position = new Vector3((NewWidth/(-2))+7, TerrainCanvas_1.localPosition.y + 109, PinkCoral_1.position.z);
            Stone3_1.position = new Vector3((NewWidth/(-2))+5, TerrainCanvas_1.localPosition.y + 35, Stone3_1.position.z);
            PurpleCoral_1.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_1.localPosition.y - 43, PurpleCoral_1.position.z);
            Stone2_1.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_1.localPosition.y - 110, Stone2_1.position.z);

            PinkCoral_1.eulerAngles = new Vector3(PinkCoral_1.rotation.x, PinkCoral_1.rotation.y, -10704/100);
            Stone3_1.eulerAngles = new Vector3(Stone3_1.rotation.x, Stone3_1.rotation.y, 0);
            PurpleCoral_1.eulerAngles = new Vector3(PurpleCoral_1.rotation.x, PurpleCoral_1.rotation.y, -657/10);
            Stone2_1.eulerAngles = new Vector3(Stone2_1.rotation.x, Stone2_1.rotation.y, -808/10);
            
            //Right Side Of Screen
            Stone4_1.position = new Vector3((NewWidth/2)-5, TerrainCanvas_1.localPosition.y + 109, Stone4_1.position.z);
            GreenCoral_1.position = new Vector3((NewWidth/2)-8, TerrainCanvas_1.localPosition.y + 53, GreenCoral_1.position.z);
            Stone1_1.position = new Vector3((NewWidth/2)-4, TerrainCanvas_1.localPosition.y + 3, Stone1_1.position.z);
            RedCoral_1.position = new Vector3((NewWidth/2)-7, TerrainCanvas_1.localPosition.y - 56, RedCoral_1.position.z);
            Stone5_1.position = new Vector3((NewWidth/2)-4, TerrainCanvas_1.localPosition.y - 114, Stone5_1.position.z);

            Stone4_1.eulerAngles = new Vector3(Stone4_1.rotation.x, Stone4_1.rotation.y, -2606/10);
            GreenCoral_1.eulerAngles = new Vector3(GreenCoral_1.rotation.x, GreenCoral_1.rotation.y, 803/10);
            Stone1_1.eulerAngles = new Vector3(Stone1_1.rotation.x, Stone1_1.rotation.y, 7532/100);
            RedCoral_1.eulerAngles = new Vector3(RedCoral_1.rotation.x, RedCoral_1.rotation.y, 744/10);
            Stone5_1.eulerAngles = new Vector3(Stone5_1.rotation.x, Stone5_1.rotation.y, 180);
        }

        if (NewMoveBackground == 2 && IsUp == false || NewMoveBackground == 1 && IsUp == true) {
        //Background 2 Preset
            //Left Side Of Screen
            PinkCoral_2.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_2.localPosition.y + 109, PinkCoral_2.position.z);
            Stone3_2.position = new Vector3((NewWidth/(-2))+7, TerrainCanvas_2.localPosition.y + 35, Stone3_2.position.z);
            PurpleCoral_2.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_2.localPosition.y - 43, PurpleCoral_2.position.z);
            Stone2_2.position = new Vector3((NewWidth/(-2))+4, TerrainCanvas_2.localPosition.y - 110, Stone2_2.position.z);

            PinkCoral_2.eulerAngles = new Vector3(PinkCoral_2.rotation.x, PinkCoral_2.rotation.y, -10704/100);
            Stone3_2.eulerAngles = new Vector3(Stone3_2.rotation.x, Stone3_2.rotation.y, 0);
            PurpleCoral_2.eulerAngles = new Vector3(PurpleCoral_2.rotation.x, PurpleCoral_2.rotation.y, -657/10);
            Stone2_2.eulerAngles = new Vector3(Stone2_2.rotation.x, Stone2_2.rotation.y, -808/10);
            
            //Right Side Of Screen
            Stone4_2.position = new Vector3((NewWidth/2)-5, TerrainCanvas_2.localPosition.y + 109, Stone4_2.position.z);
            GreenCoral_2.position = new Vector3((NewWidth/2)-8, TerrainCanvas_2.localPosition.y + 53, GreenCoral_2.position.z);
            Stone1_2.position = new Vector3((NewWidth/2)-4, TerrainCanvas_2.localPosition.y + 3, Stone1_2.position.z);
            RedCoral_2.position = new Vector3((NewWidth/2)-6, TerrainCanvas_2.localPosition.y - 56, RedCoral_2.position.z);
            Stone5_2.position = new Vector3((NewWidth/2)-4, TerrainCanvas_2.localPosition.y - 114, Stone5_2.position.z);

            Stone4_2.eulerAngles = new Vector3(Stone4_2.rotation.x, Stone4_2.rotation.y, -2606/10);
            GreenCoral_2.eulerAngles = new Vector3(GreenCoral_2.rotation.x, GreenCoral_2.rotation.y, 803/10);
            Stone1_2.eulerAngles = new Vector3(Stone1_2.rotation.x, Stone1_2.rotation.y, 7532/100);
            RedCoral_2.eulerAngles = new Vector3(RedCoral_2.rotation.x, RedCoral_2.rotation.y, 744/10);
            Stone5_2.eulerAngles = new Vector3(Stone5_2.rotation.x, Stone5_2.rotation.y, 180);
        }
    }

        void Preset3() {
        if (NewMoveBackground == 1 && IsUp == false || NewMoveBackground == 2 && IsUp == true) {
        //Background 1 Preset
            //Left Side Of Screen
            RedCoral_1.position = new Vector3((NewWidth/(-2))+10, TerrainCanvas_1.localPosition.y + 109, RedCoral_1.position.z);
            Stone3_1.position = new Vector3((NewWidth/(-2))+7, TerrainCanvas_1.localPosition.y + 35, Stone3_1.position.z);
            PinkCoral_1.position = new Vector3((NewWidth/(-2))+5, TerrainCanvas_1.localPosition.y - 43, PinkCoral_1.position.z);
            Stone2_1.position = new Vector3((NewWidth/(-2))+5, TerrainCanvas_1.localPosition.y - 110, Stone2_1.position.z);

            RedCoral_1.eulerAngles = new Vector3(RedCoral_1.rotation.x, RedCoral_1.rotation.y, -744/10);
            Stone3_1.eulerAngles = new Vector3(Stone3_1.rotation.x, Stone3_1.rotation.y, 0);
            PinkCoral_1.eulerAngles = new Vector3(PinkCoral_1.rotation.x, PinkCoral_1.rotation.y, -10704/100);
            Stone2_1.eulerAngles = new Vector3(Stone2_1.rotation.x, Stone2_1.rotation.y, -808/10);
            
            //Right Side Of Screen
            Stone4_1.position = new Vector3((NewWidth/2)-5, TerrainCanvas_1.localPosition.y + 109, Stone4_1.position.z);
            PurpleCoral_1.position = new Vector3((NewWidth/2)-9, TerrainCanvas_1.localPosition.y + 53, PurpleCoral_1.position.z);
            Stone1_1.position = new Vector3((NewWidth/2)-4, TerrainCanvas_1.localPosition.y + 3, Stone1_1.position.z);
            GreenCoral_1.position = new Vector3((NewWidth/2)-7, TerrainCanvas_1.localPosition.y - 56, GreenCoral_1.position.z);
            Stone5_1.position = new Vector3((NewWidth/2)-4, TerrainCanvas_1.localPosition.y - 114, Stone5_1.position.z);

            Stone4_1.eulerAngles = new Vector3(Stone4_1.rotation.x, Stone4_1.rotation.y, -2606/10);
            PurpleCoral_1.eulerAngles = new Vector3(PurpleCoral_1.rotation.x, PurpleCoral_1.rotation.y, 657/10);
            Stone1_1.eulerAngles = new Vector3(Stone1_1.rotation.x, Stone1_1.rotation.y, 7532/100);
            GreenCoral_1.eulerAngles = new Vector3(GreenCoral_1.rotation.x, GreenCoral_1.rotation.y, 803/10);
            Stone5_1.eulerAngles = new Vector3(Stone5_1.rotation.x, Stone5_1.rotation.y, 180);
        }

        if (NewMoveBackground == 2 && IsUp == false || NewMoveBackground == 1 && IsUp == true) {
        //Background 2 Preset
            //Left Side Of Screen
            RedCoral_2.position = new Vector3((NewWidth/(-2))+7, TerrainCanvas_2.localPosition.y + 109, RedCoral_2.position.z);
            Stone3_2.position = new Vector3((NewWidth/(-2))+7, TerrainCanvas_2.localPosition.y + 35, Stone3_2.position.z);
            PinkCoral_2.position = new Vector3((NewWidth/(-2))+6, TerrainCanvas_2.localPosition.y - 43, PinkCoral_2.position.z);
            Stone2_2.position = new Vector3((NewWidth/(-2))+4, TerrainCanvas_2.localPosition.y - 110, Stone2_2.position.z);

            RedCoral_2.eulerAngles = new Vector3(RedCoral_2.rotation.x, RedCoral_2.rotation.y, -744/10);
            Stone3_2.eulerAngles = new Vector3(Stone3_2.rotation.x, Stone3_2.rotation.y, 0);
            PinkCoral_2.eulerAngles = new Vector3(PinkCoral_2.rotation.x, PinkCoral_2.rotation.y, -10704/100);
            Stone2_2.eulerAngles = new Vector3(Stone2_2.rotation.x, Stone2_2.rotation.y, -808/10);
            
            //Right Side Of Screen
            Stone4_2.position = new Vector3((NewWidth/2)-6, TerrainCanvas_2.localPosition.y + 109, Stone4_2.position.z);
            PurpleCoral_2.position = new Vector3((NewWidth/2)-7, TerrainCanvas_2.localPosition.y + 53, PurpleCoral_2.position.z);
            Stone1_2.position = new Vector3((NewWidth/2)-4, TerrainCanvas_2.localPosition.y + 3, Stone1_2.position.z);
            GreenCoral_2.position = new Vector3((NewWidth/2)-7, TerrainCanvas_2.localPosition.y - 56, GreenCoral_2.position.z);
            Stone5_2.position = new Vector3((NewWidth/2)-4, TerrainCanvas_2.localPosition.y - 114, Stone5_2.position.z);

            Stone4_2.eulerAngles = new Vector3(Stone4_2.rotation.x, Stone4_2.rotation.y, -2606/10);
            PurpleCoral_2.eulerAngles = new Vector3(PurpleCoral_2.rotation.x, PurpleCoral_2.rotation.y, 657/10);
            Stone1_2.eulerAngles = new Vector3(Stone1_2.rotation.x, Stone1_2.rotation.y, 7532/100);
            GreenCoral_2.eulerAngles = new Vector3(GreenCoral_2.rotation.x, GreenCoral_2.rotation.y, 803/10);
            Stone5_2.eulerAngles = new Vector3(Stone5_2.rotation.x, Stone5_2.rotation.y, 180);
        }
    }

    void Update() {
        if(CameraObject != null) { NewMoveBackground = CameraObject.MoveBackground; }
        TerrainCanvas_1.localPosition = new Vector3(TerrainCanvas_1.localPosition.x, bg1.position.y, TerrainCanvas_1.localPosition.z);
        TerrainCanvas_2.localPosition = new Vector3(TerrainCanvas_2.localPosition.x, bg2.position.y, TerrainCanvas_2.localPosition.z); 
    }

}

