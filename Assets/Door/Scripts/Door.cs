using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    [SerializeField]
    private Sprite closeSprite;
    [SerializeField]
    private Sprite openSprite;

    private SpriteRenderer spriteRenderer;
    
    private GameObject closeCollider;
    private GameObject openCollider;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        closeCollider = transform.Find("CloseCollider").gameObject;
        openCollider = transform.Find("OpenCollider").gameObject;

        Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        spriteRenderer.sprite = openSprite;
        openCollider.SetActive(true);
        closeCollider.SetActive(false);
    }

    public void Close()
    {
        spriteRenderer.sprite = closeSprite;
        openCollider.SetActive(false);
        closeCollider.SetActive(true);
    }
}
