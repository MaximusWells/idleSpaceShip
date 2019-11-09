using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgndParallax : MonoBehaviour
{
    private float bgLength;
    private float bgStartPos;

    public float parallax;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        bgStartPos = transform.position.x;
        bgLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float bgMoved = (cam.transform.position.x * (1 - parallax));
        float bgDist = (cam.transform.position.x * parallax);

        transform.position = new Vector2(bgStartPos + bgDist, transform.position.y);

        if (bgMoved > bgStartPos + bgLength) bgStartPos += bgLength;
        else if (bgMoved < bgStartPos - bgLength) bgStartPos -= bgLength;

        MoveCam();
    }

    public void MoveCam()
    {
        cam.transform.Translate((Vector2.right * (Time.deltaTime * 6.0f)));
        if (cam.transform.position.x >= 95.0f)
        {
            cam.transform.position = new Vector3 (0.0f, 0.0f, -10.0f);
        }
    }

}
