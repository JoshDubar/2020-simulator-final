using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

[RequireComponent(typeof(LineRenderer))]
public class DrawCircle : MonoBehaviour
{
    public int segments = 100;

    public bool circle = true;
    [Range(0, 50)]
    public float xradius = 0.5f;
    [Range(0, 50)]
    public float yradius = 0.1f;
    LineRenderer line;

    private Color lineColor = new Color(0, 225, 33, 225);

    private float lineThickness = 0.1f;

    public float rate;

    public int index;

    public bool activate;

    public float increment;

    void Start()
    {
        rate = 0.0f;
        index = 0;
        activate = false;
        line = gameObject.GetComponent<LineRenderer>();
        line.SetWidth(lineThickness, lineThickness);
        line.startColor = Color.green;
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        line.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 3);
        xradius = 0.5f;
        yradius = 0.5f;
    }

    private void Update() {

        if (activate) {
            rate += Time.deltaTime;
        }
        if (rate > increment  && index < (segments + 1)) {
            rate = 0;
            CreatePoints();
        }
    }

    void CreatePoints() {
        float x;
        float y;

        float change = 2 * (float)Math.PI / segments;
        float angle = change;
        x = Mathf.Sin(angle) * xradius;
        y = Mathf.Cos(angle) * yradius;
        line.SetPosition(index, new Vector3(x, y, 0));
        index += 1;
        angle += change;
    }
}