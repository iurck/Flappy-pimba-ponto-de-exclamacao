using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get gameManager
        var gameManager = GameManager.Instance;
        // ignore "if" se o jogo acabou
        if(gameManager.IsGameOver())
        {
            return;
        }
        // move object
        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        if (transform.position.x <= -gameManager.ObstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}
