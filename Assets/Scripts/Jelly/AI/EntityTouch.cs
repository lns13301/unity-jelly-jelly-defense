using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTouch : MonoBehaviour
{
    private static string MOUSE_UP_SOUND = "Grow";

    private static float DISTANCE = 10;
    private static float DRAG_DELAY = 0.3f;

    [SerializeField] private Movement movement;
    [SerializeField] private JellyState jellyState;
    [SerializeField] private JellyData jellyData;
    [SerializeField] private float dragDelay;
    public bool isDrag;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        jellyState = GetComponent<JellyState>();
        jellyData = GetComponent<JellyData>();
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
        Selling.instance.registerJelly(null);
        Selling.instance.isSellingMode = false;
    }

    private void OnMouseUp()
    {
        bool isSellingMode = Selling.instance.isSellingMode;

        SoundManager.instance.PlayOneShowSoundFindByName(MOUSE_UP_SOUND);

        if (isDrag && !isSellingMode)
        {
            return;
        }

        if (isSellingMode)
        {
            Selling.instance.Sell();
            return;
        }

        GameManager.instance.AddJelatin(Random.Range(5, 50));
        jellyState.ChangeLevelAnimationController(jellyData.GetEntityData().level);
    }

    private void OnMouseDrag()
    {
        if (dragDelay > 0)
        {
            return;
        }

        isDrag = true;
        Selling.instance.registerJelly(jellyData);

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, DISTANCE);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
