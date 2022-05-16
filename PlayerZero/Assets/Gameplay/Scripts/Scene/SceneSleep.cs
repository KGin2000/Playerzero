using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SceneSleep : MonoBehaviour
{
    [SerializeField] private SceneName sceneNameGoto = SceneName.Scene1_Farm;
    [SerializeField] private Vector3 scenePositionGoto = new Vector3();

    private int gameHour;

    private void Update()
    {
        gameHour = GameManager.instance.timeManager.gameHour;
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if (gameHour > 5)
            {
                if(gameHour < 21)
                {
                    UIManager.Instance.EnableNotSleepMenu();
                }
                else
                {
                    UIManager.Instance.EnableCanSleepMenu();
                }
                
            }
            else
            {
                UIManager.Instance.EnableCanSleepMenu();
            }

        // if (player != null)
        //     {
        //         float xPosition = Mathf.Approximately(scenePositionGoto.x, 0f) ? player.transform.position.x : scenePositionGoto.x;

        //         float yPosition = 0f;

        //         float zPosition = Mathf.Approximately(scenePositionGoto.x, 0f) ? player.transform.position.z : scenePositionGoto.z;

        //         SceneControllerManager.Instance.FadeAndLoadScene(sceneNameGoto.ToString(), new Vector3(xPosition, yPosition, zPosition));
        //     }  
        }
    }
}
