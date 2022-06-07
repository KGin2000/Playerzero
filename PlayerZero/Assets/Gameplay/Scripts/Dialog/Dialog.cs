using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private int _dialogCode;

    private SpriteRenderer spriteRenderer;

    public int DialogCode { get { return _dialogCode; } set { _dialogCode = value; } }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (DialogCode != 0)
        {
            Init(DialogCode);
        }
    }

    void Update()
    {
    
    }

    public void Init (int itemCodeParam)
    {
    
    }
}
