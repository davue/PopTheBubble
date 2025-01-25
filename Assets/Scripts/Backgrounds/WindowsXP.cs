using UnityEngine;

public class WindowsXP : Background
{
    [SerializeField] private GameObject contextMenu;
    private bool closeContextMenu = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        contextMenu.transform.position = new Vector3(-10000, -10000, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // var contextMenuTransform = (RectTransform)contextMenu.transform;
            // contextMenu.transform.position = new Vector3(mousePos.x + contextMenuTransform.rect.width / 2,
            //     mousePos.y + contextMenuTransform.rect.height / 2, 0);
            // contextMenu.SetActive(true);

            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var contextMenuTransform = (RectTransform)contextMenu.transform;
            Debug.Log(Input.mousePosition);
            Debug.Log(mousePos);
            Debug.Log(contextMenuTransform.rect);
            contextMenu.transform.localPosition = new Vector3(
                Input.mousePosition.x - Camera.main.pixelWidth / 2 - contextMenuTransform.rect.x,
                Input.mousePosition.y - Camera.main.pixelHeight / 2 + contextMenuTransform.rect.y, 0);
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            contextMenu.transform.position = new Vector3(-10000, -10000, 0);
        }
    }
}