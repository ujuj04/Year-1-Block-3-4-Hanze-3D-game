using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class CursorHandler : MonoBehaviour
{
    void Update()
    {
        if(PixelCrushers.DialogueSystem.DialogueManager.isConversationActive)
            Cursor.visible = true;
        else Cursor.visible = false;
    }
}
