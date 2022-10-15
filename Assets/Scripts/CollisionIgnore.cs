using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    [SerializeField] private Collider collider_1;
    [SerializeField] private Collider collider_2;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(collider_1, collider_2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
