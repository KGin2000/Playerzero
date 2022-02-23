
using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
        // Start is called before the first frame update
    // void Start()
    // {
    //     SwitchBoundingShape();
    // }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += SwitchBoundingShape;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= SwitchBoundingShape;
    }
    

    private void SwitchBoundingShape()
    {
        BoxCollider boxCollider = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<BoxCollider>();

        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

        cinemachineConfiner.m_BoundingVolume = boxCollider ; 

        cinemachineConfiner.InvalidatePathCache();
    }
    
}
