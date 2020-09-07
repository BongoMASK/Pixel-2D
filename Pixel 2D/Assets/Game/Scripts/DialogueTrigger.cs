using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DialogueTrigger : MonoBehaviour
{
    int val;

    public int range = 50;
    public GameObject button;
    public Color color1;
    public Color color2;
    public Tilemap background;
    public Dialogue dialogue;
    public Dialogue dialogue2;

    void Awake() {
        val =  Random.Range(1, 3);
        if(val == 1)
            for(int i = -range; i <= range; i++) 
                for(int j = -range; j <= range; j++)
                    SetTileColour(color1, new Vector3Int(i,j,0), background);

        if(val == 2)
            for(int i = -range; i <= range; i++) 
                for(int j = -range; j <= range; j++)
                    SetTileColour(color2, new Vector3Int(i,j,0), background);

            //-8, 15, 25, 15
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
