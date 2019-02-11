using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    public Transform hitPoint;
    public bool direction;
    public PlayerController p_Script;
    public Flip f_script;
    public Camera cam;
    public int PosOffset;
        
    
    // Start is called before the first frame update
    void Start()
    {
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5f;

        Vector3 objectPos = cam.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        //Debug.Log (angle + "")

        if (direction == true) { PosOffset = 75; }
        if (direction == false) { PosOffset = 110; }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + PosOffset)); //Rotation
        //transform.RotateAround(p_Script.currentLocation, Vector3.forward, angle + PosOffset);

        if (angle > 0f && angle < 100f || angle < 0f && angle > -90f)
        {
            if (direction == false)
            {
                direction = true;
                Flip();
            }
        }

        if (angle > 100f && angle < 180f || angle < -90f && angle > -180f)
        {
            if (direction == true)
            {
                direction = false;
                Flip();
            } 
        }   
    }

    void Flip()
    {
        if (direction == false && p_Script.facingRight == true || direction == true && p_Script.facingRight == false)
        {
            f_script.flip();

            hitPoint.Rotate(Vector3.forward * 180);

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
