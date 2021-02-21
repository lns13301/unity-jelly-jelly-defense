using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTouch : MonoBehaviour
{
    private static float DISTANCE = 10;
    private static float DRAG_DELAY = 0.3f;

    public Movement movement;
    public float dragDelay;
    public bool isDrag;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (dragDelay > 0)
        {
            dragDelay -= Time.deltaTime;
        }
        else
        {
            isDrag = true;
        }
    }

    private void OnMouseDown()
    {
        movement.TouchState();
        dragDelay = DRAG_DELAY;
        isDrag = false;
    }

    private void OnMouseUp()
    {
        if (isDrag)
        {
            return;
        }

        GameManager.instance.AddJelatin(Random.Range(5, 50));
    }

    private void OnMouseDrag()
    {
        if (dragDelay > 0)
        {
            return;
        }

        isDrag = true;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, DISTANCE);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
