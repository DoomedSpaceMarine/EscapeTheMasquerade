using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D customCursor;

    void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

}
