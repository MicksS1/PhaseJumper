using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCheckR : MonoBehaviour
{
    public PMove PMove;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            PMove.isObstacleR = true;

        else
            PMove.isObstacleR = false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            PMove.isObstacleR = false;
    }
}
