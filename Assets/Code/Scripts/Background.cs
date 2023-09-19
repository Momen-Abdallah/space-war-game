using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Sprite[] sprite;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = sprite[Random.Range(0, sprite.Length)];
    }
}
