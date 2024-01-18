using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Animator spriteAnimator;
    [SerializeField] private Text buttonText;
    [SerializeField] private Texture2D cursorTexture;

    // Start is called before the first frame update
    void Start()
    {
        spriteAnimator.speed = 0;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        spriteAnimator.speed = 1;
        buttonText.color = Color.white;

        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        SoundManager.instance.PlaySound("ButtonHover");
    }

    public void OnPointerExit(PointerEventData data)
    {
        spriteAnimator.speed = 0;
        buttonText.color = new Color32(0xFF, 0x96, 0x00, 0xFF);

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerClick(PointerEventData data)
    {
        if ((data.button == PointerEventData.InputButton.Left) || (data.button == PointerEventData.InputButton.Right))
        {
            SoundManager.instance.PlaySound("ButtonConfirm");
        }
    }
}
