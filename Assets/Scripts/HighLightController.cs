using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightController : MonoBehaviour
{
    [SerializeField] GameObject highlighter;

    GameObject currentTarget;
    
    public void Highlight(GameObject target)
    {   
        if (currentTarget == target)
        {
            return;
        }
        currentTarget = target;
        Vector3 position = target.transform.position;
        Highlight(position);
    }

    public void Highlight(Vector3 position, float yOffset = 0.5f)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = new Vector3(position.x, position.y + yOffset, position.z);
    }


    public void Hide()
    {   
        currentTarget = null;
        highlighter.SetActive(false);
    }
}
