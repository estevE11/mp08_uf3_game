using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlockGenerator : MonoBehaviour
{
    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(block, new Vector3(transform.position.x + 13f, transform.position.y - 2.29f, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }
}
