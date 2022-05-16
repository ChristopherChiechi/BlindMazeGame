using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    // variables
    [SerializeField] RawImage img;
    [SerializeField] float x, y;

    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
    }
}
