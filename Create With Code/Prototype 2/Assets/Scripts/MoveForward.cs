using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // public variables
    public float speed = 50.0f;
    public string prefabType; // Projectile, Animal


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void LateUpdate()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (this.transform.position.z > 15 || this.transform.position.z < -10.0f)
        {
            Quaternion rotation = this.gameObject.transform.rotation;
            Destroy(this.gameObject);

            if (prefabType == "Animal")
            {
                var obj = GameObject.Find("SpawnManager(Empty)");
                var manager = obj.GetComponent<SpawnManager>();
                manager.NewRandomAnimal(rotation);
            }
        }
    }
}
