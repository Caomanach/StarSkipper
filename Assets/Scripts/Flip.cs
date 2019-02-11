using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public PlayerController p_Script;
    private bool facingRightTrueFalse;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        facingRightTrueFalse = p_Script.facingRight;
    }
    public void flip()
    {
        facingRightTrueFalse = !facingRightTrueFalse;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
