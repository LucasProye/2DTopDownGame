using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D _cursor;

    void Start()
    {
        Vector2 cursorOffset = new Vector2(_cursor.width / 2, _cursor.height / 2);

        Cursor.SetCursor(_cursor, cursorOffset, CursorMode.Auto);
    }
}
