using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public float borderWidth = 0.02f;
    public float lineThinkness = 0.5f;
    public float scaleTime = 0.25f;
    public float delay = 0.1f;

    public iTween.EaseType easeType = iTween.EaseType.easeInOutExpo;

    private void Start()
    {
       // DrawLink(new Vector3(4f, 0f, 0f), new Vector3(4f, 0f, 2f));
    }

    public void DrawLink(Vector3 endPos, Vector3 startPos)
    {
        transform.localScale = new Vector3(lineThinkness, 1f, 0f);

        Vector3 dirVector = endPos - startPos;

        float zScale = dirVector.magnitude - borderWidth * 2f;

        Vector3 newScale = new Vector3(lineThinkness, 1f, zScale);

        transform.rotation = Quaternion.LookRotation(dirVector);

        transform.position = startPos + (transform.forward * borderWidth);

        iTween.ScaleTo(gameObject, iTween.Hash(
            "time", scaleTime,
            "scale", newScale,
            "easetype", easeType,
            "delay", delay
            ));
    }
}
