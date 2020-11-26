using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingMenu : MonoBehaviour
{
    [SerializeField] RectTransform Menu;
    [SerializeField] float time;
    private bool IsMoving = false;
    private Vector3 start;
    private Vector3 end;
    public bool IsOpen { get; private set; } = false;

    private void Awake()
    {
        start = Menu.transform.position;
        end = start;
        end.x += Menu.rect.width;
    }

    public void Slide()
    {
        gameObject.SetActive(true);
        StartCoroutine(nameof(MoveTo));
        IsOpen = !IsOpen;
    }

    private IEnumerator MoveTo()
    {
        while (IsMoving)
        {
            yield return null;
        }

        if (!IsOpen)
        {
            gameObject.SetActive(true);
        }

        IsMoving = true;
        Vector3 tstart = !IsOpen ? start : end;
        Vector3 tend = !IsOpen ? end : start;
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(tstart, tend, t / time);
            yield return null;
        }
        transform.position = tend;
        IsMoving = false;
        if(!IsOpen)
        {
            gameObject.SetActive(false);
        }
    }

}
