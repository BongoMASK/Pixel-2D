using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DialogueTrigger : MonoBehaviour
{
    int val, k;

    public int range = 50;
    public bool isGoodOnly;
    public bool isBadOnly;
    public bool hybrid;
    public GameObject button;
    public Color color1;
    public Color color2;
    public Tilemap background;
    public Dialogue dialogue;
    public Dialogue dialogue2;

    void Awake() {
        if(isGoodOnly == true) {
            val = 1;
        }
        else if(isBadOnly == true) {
            val = 2;
        }
        else {
            val =  Random.Range(1, 3);
        }

        if(val == 1)
            for(int i = -range; i <= range; i++) 
                for(int j = -range; j <= range; j++)
                    SetTileColour(color1, new Vector3Int(i,j,0), background);

        if(val == 2)
            for(int i = -range; i <= range; i++) 
                for(int j = -range; j <= range; j++)
                    SetTileColour(color2, new Vector3Int(i,j,0), background);
                    
        if(hybrid == true) {
            for(int i = -range; i <= range; i++) 
                for(int j = -range; j <= range; j++) {
                    k = Random.Range(1, 10);
                    if(k == 1) 
                        SetTileColour(color1, new Vector3Int(i,j,0), background);
                    if(k == 2)
                        SetTileColour(color2, new Vector3Int(i,j,0), background);
                }
        }        
    }

    public void TriggerDialogue() {
        if(val == 1) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, Color.white);
            //SetTileColour(Color.green, new Vector3Int(10,0,0), background);
        }
        if(val == 2) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2, Color.red);
            //SetTileColour(Color.red, new Vector3Int(10,0,0), background);
        }

        button.SetActive(false);
    }

    private void SetTileColour(Color colour, Vector3Int position, Tilemap tilemap) {
        // Flag the tile, inidicating that it can change colour.
        // By default it's set to "Lock Colour".
        tilemap.SetTileFlags(position, TileFlags.None);
 
        // Set the colour.
        tilemap.SetColor(position, colour);
    }
}
