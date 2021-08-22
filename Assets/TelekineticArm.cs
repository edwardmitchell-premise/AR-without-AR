using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TelekineticArm : MonoBehaviour
{
    public char R_or_L;

    public GameObject target;
    public float speed = 6.0f;

    public GameObject pivot;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsTrue(R_or_L == 'R' || R_or_L == 'L');
    }

    // Update is called once per frame
    void Update()
    {        
        var h = Input.GetAxis(R_or_L + " Horizontal");
        var v = Input.GetAxis(R_or_L + " Vertical");

        target.transform.Translate(0,0,v*speed* Time.deltaTime);

        transform.RotateAround(pivot.transform.position, Vector3.up, h*20 * Time.deltaTime);

        var size = Input.GetAxis("Pressure");
        var growth = size * Time.deltaTime;
        target.transform.localScale += new Vector3(growth,growth,growth);
    }
}
