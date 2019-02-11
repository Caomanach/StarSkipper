using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D body;
    public ArrowRotation2 a_script;
    public PlayerController p_Script;
    public Transform launchDirection;
    public float LaunchForce = 400f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchPlayer();
        }
    }

    void LaunchPlayer()
    {
        float launchDirX = launchDirection.position.x;
        float launchDirY = launchDirection.position.y;
        float posX = transform.position.x;
        float posY = transform.position.y;

        //Launch direction is the difference between our destination and our current position
        Vector2 launchDir = new Vector2(launchDirX - posX, launchDirY - posY);
        p_Script.Jump(launchDir, LaunchForce);

    }

   
}
