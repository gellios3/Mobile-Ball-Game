using Contexts;
using strange.extensions.context.impl;
using UnityEngine;

namespace Views.Root
{
    public class MainGameRoot : ContextView
    {
        
        [SerializeField] private Texture2D _cursorTexture;
        
        private void Awake()
        {
            context = new MainGameContext(this);
            
            Cursor.SetCursor(_cursorTexture, new Vector2(-1.5f, 1.5f), CursorMode.Auto);
        }
        
        private void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }
}