using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 1, 0); //need to do inline initialization in unity
    public float speed = 10;
    protected Vector3 moveTranslation;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //time corrected movement
        this.moveTranslation = new Vector3(this.direction.x, this.direction.y) * Time.deltaTime * this.speed;

        //move
        this.transform.position += new Vector3(moveTranslation.x, moveTranslation.y);
    }
}
