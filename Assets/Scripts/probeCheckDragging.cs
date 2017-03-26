using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class probeCheckDragging : MonoBehaviour {

    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;

    // Use this for initialization
    void Start () {
        LineRendererSetup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "Foreground";
        catapultLineBack.sortingLayerName = "Foreground";

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;
    }


}
