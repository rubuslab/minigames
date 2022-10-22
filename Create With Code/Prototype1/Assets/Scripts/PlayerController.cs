using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables
    public float Speed = 20.0f;
    public Camera MainCamera;

    // private variables
    private Vector3 m_distance;

    // Start is called before the first frame update
    void Start()
    {
        m_distance = MainCamera.transform.position - this.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        float move_z_translate = Input.GetAxis("Vertical");
        float move_x_translate = Input.GetAxis("Horizontal");
        if (Mathf.Abs(move_z_translate) > 0.0001f || Mathf.Abs(move_x_translate) > 0.0001f)
        {
            float delta = Speed * Time.deltaTime;
            move_z_translate *= delta;
            move_x_translate *= delta;
            // move on x, z axis
            this.transform.Translate(move_x_translate, 0, move_z_translate);

            // update main camera position
            MainCamera.transform.position = m_distance + this.transform.position;
        }
    }
}
