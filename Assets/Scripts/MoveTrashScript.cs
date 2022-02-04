using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrashScript : MonoBehaviour
{
    public hook HookScript;

    void FixedUpdate() {
        this.transform.position = new Vector3(this.transform.position.x+0.35f, this.transform.position.y, this.transform.position.z);

        if(this.transform.position.x >= 100)  {
            this.transform.position = new Vector3(-100, this.transform.position.y, this.transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Hook" && HookScript.TrashCollected < HookScript.MaxTrashCollected && HookScript.ReachedMaxDepth == false) {
            AddTrashCatched();
            Destroy(this.gameObject);
        }
    }
    
    public void AddTrashCatched() {
        HookScript.TrashCollected = HookScript.TrashCollected + 1;
    }
}
