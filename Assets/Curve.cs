using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public Transform start;
    public Transform middle;
    public Transform end;

    public Transform slider;

    public float duration;
    public float Duration { get { return duration == 0 ? 0.1f : duration; } }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Go());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Go()
    {
        Vector3 a = start.position;
        Vector3 b = middle.position;
        Vector3 c = end.position;

        float per = 0f;
        float time = Time.time;

        while (per < 1)
        {
            per = (Time.time - time) / Duration;

            Vector3 l_ab = Vector3.Lerp(a, b, per);
            Vector3 l_bc = Vector3.Lerp(b, c, per);

            Vector3 point = Vector3.Lerp(l_ab, l_bc, per);

            slider.position = point;

            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(Go());
    }
}
