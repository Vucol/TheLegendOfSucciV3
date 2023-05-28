using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControler : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h, mouse*300, v) *Time.deltaTime*speed ,Space.World);
        
    }
}
