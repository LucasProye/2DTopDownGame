using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    public Texture2D _cursor;

    void Start()
    {

        //set the cursor origin to its centre. (default is upper left corner)
        Vector2 cursorOffset = new Vector2(_cursor.width / 2, _cursor.height / 2);

        //Sets the cursor to the Crosshair sprite with given offset 
        //and automatic switching to hardware default if necessary
        Cursor.SetCursor(_cursor, cursorOffset, CursorMode.Auto);
    }
}
