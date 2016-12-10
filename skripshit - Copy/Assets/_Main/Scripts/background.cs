using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

    private Material materialAct;
    public float speed;
    private float offset;

    void Start()
    {
        materialAct = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        offset += 0.001f;
        materialAct.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
