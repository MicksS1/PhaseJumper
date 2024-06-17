using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCheckL : MonoBehaviour
{
    public PMove PMove;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            PMove.isObstacleL = true;

        else
            PMove.isObstacleL = false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            PMove.isObstacleL = false;
    }
}
