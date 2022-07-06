using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMovement : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartMovement(Vector3 target)
    {
        StartCoroutine(MovementRoutine(target));
    }

    private IEnumerator MovementRoutine(Vector3 target)
    {
        do
        {
            rectTransform.anchoredPosition = Vector3.MoveTowards(rectTransform.anchoredPosition, target, 0.1f);
            yield return null;
        } while (Vector3.Distance(rectTransform.anchoredPosition, target) > 0.0001f);
    }
}
