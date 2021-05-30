using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public GameObject scoreDetector;
    public GameObject specialCoin;
    public GameObject healthCoin;

    private float midDist = 4f;
    private float randDist = 2.5f;
    private float offset = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        float val = Random.Range(-randDist, randDist);

        InstantiateCube((transform.position.y + val + midDist) + offset);
        InstantiateCube((transform.position.y + val - midDist) + offset);

        Instantiate(scoreDetector, new Vector3(transform.position.x + 2f, (transform.position.y + val) + offset, transform.position.z), Quaternion.identity);

        float prob = Random.Range(0f, 100f);
        Debug.Log(prob);
        if (prob > 80 && prob <= 90) {
            Instantiate(specialCoin, new Vector3(transform.position.x - 3.5f, transform.position.y + 4.8f, transform.position.z), Quaternion.identity);
        } else if (prob > 90 && prob <= 100) {
            Instantiate(healthCoin, new Vector3(transform.position.x - 3.5f, transform.position.y + 4.8f, transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateCube(float y) {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.gameObject.tag = "enemy";
        obj.transform.localScale = new Vector3(1, 5, 1);

        obj.transform.position = new Vector3(transform.position.x + 1, y, transform.position.z);

        Instantiate(obj);
    }
}
