using UnityEngine;

public abstract class Item7 : MonoBehaviour
{
    protected UIManager uiManager;
    protected abstract void comportement(Collider2D collision);

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            comportement(collision);
        }
    }
}
