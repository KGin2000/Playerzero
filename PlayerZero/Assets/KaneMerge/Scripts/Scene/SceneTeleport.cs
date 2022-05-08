using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SceneTeleport : MonoBehaviour
{
    [SerializeField] private SceneName sceneNameGoto = SceneName.Scene1_Farm;
    [SerializeField] private Vector3 scenePositionGoto = new Vector3();

    private void OnTriggerEnter(Collider collision)
    {
        Player player = collision.GetComponent<Player>();

      if (player != null)
      {
          float xPosition = Mathf.Approximately(scenePositionGoto.x, 0f) ? player.transform.position.x : scenePositionGoto.x;

          float yPosition = 0f;

          float zPosition = Mathf.Approximately(scenePositionGoto.z, 0f) ? player.transform.position.z : scenePositionGoto.z;

          SceneControllerManager.Instance.FadeAndLoadScene(sceneNameGoto.ToString(), new Vector3(xPosition, yPosition, zPosition));
      }  
    }
}
