using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWayPoint : MonoBehaviour {

    public bool Loop = true;
    public List<Vector2> waypoint;



    // Private Variable
    private Character myCharacter;
    private int targetWayIndex;
    

	void Start () {
        Loop = true;
        myCharacter = GetComponent<Character>();
    }
	
	void Update () {

        if (Loop)
        {
            // 도착 여부 확인
            if (Vector2.Distance((Vector2)transform.position, waypoint[targetWayIndex]) < 0.01f)
            {
                targetWayIndex++;

                // 마지막 웨이포인트에 도착
                if (waypoint.Count <= targetWayIndex)
                {
                    targetWayIndex = 0;
                }
            }
            else
            {
                float step = myCharacter.speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, waypoint[targetWayIndex], step);
                //     transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                transform.position = new Vector3(transform.position.x, transform.position.y, -1 + transform.position.y / 1000.0f);
            }
        }
	}
}
