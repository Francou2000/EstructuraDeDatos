using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    private float movHorizontal = 0;
    public float MovHorizontal => movHorizontal;
    private float movVertical = 0;
    public float MovVertical => movVertical;
    private bool jump = false;
    public bool Jump => jump;
    private bool shoot = false;
    public bool Shoot => shoot;
    private bool powerUp = false;
    public bool PowerUp => powerUp;

    public Input_Manager() { }


    public void InputUpdate()
    {
        movHorizontal = Input.GetAxis("Horizontal"); //The player moves left with "A" and right with "D"
        movVertical = Input.GetAxis("Vertical"); //The player looks up with "W" and down with "S"

        if (Input.GetKey(KeyCode.Space)) // The player jumps with "Space"
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) // The player shoots with "Mouse0" (left click)
        {
            shoot = true;
        }
        else
        {
            shoot = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) // The player uses the powerUP with "Mouse1" (right click)
        {
            powerUp = true;
        }
        else
        {
            powerUp = false;
        }

    }

    
}
