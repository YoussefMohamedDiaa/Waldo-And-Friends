using UnityEngine;

public class PanController : MonoBehaviour {

    public float panSpeed = 20f;
    public float panVerticalBorderThickness = 10f, panHorizontalBorderThickness = 10f;
    public float panHorizontalMinLimit, panHorizontalMaxLimit;
    public float panDepthMinLimit, panDepthMaxLimit;

    public float scrollSpeed = 2f;
    public float scrollMinLimit, scrollMaxLimit;

    private GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if (gameManager.IsPaused) return;

        Vector3 position = transform.position;
        Vector3 mousePosition = Input.mousePosition;

        if (Input.GetKey("w") || mousePosition.y >= Screen.height - panVerticalBorderThickness)
            position.z += panSpeed * Time.deltaTime;
        if (Input.GetKey("a") || mousePosition.x <= panHorizontalBorderThickness)
            position.x -= panSpeed * Time.deltaTime;
        if (Input.GetKey("s") || mousePosition.y <= panVerticalBorderThickness)
            position.z -= panSpeed * Time.deltaTime;
        if (Input.GetKey("d") || mousePosition.x >= Screen.width - panHorizontalBorderThickness)
            position.x += panSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, panHorizontalMinLimit, panHorizontalMaxLimit);
        position.z = Mathf.Clamp(position.z, panDepthMinLimit, panDepthMaxLimit);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y -= scroll * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, scrollMinLimit, scrollMaxLimit);

        transform.position = position;
    }
}
