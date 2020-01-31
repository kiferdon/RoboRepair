using UnityEngine;

public class TabSelector : MonoBehaviour {
    public int backLayer;
    public int frontLayer;
    private SpriteRenderer _selected;

    public void Select(SpriteRenderer spriteRenderer) {
        if (_selected) _selected.sortingOrder = backLayer;
        _selected = spriteRenderer;
        _selected.sortingOrder = frontLayer;
    }
}