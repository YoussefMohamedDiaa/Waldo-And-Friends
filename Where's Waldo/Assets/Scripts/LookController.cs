using UnityEngine;

public class LookController : MonoBehaviour {

    public Camera viewCamera;
    public Transform spotLightTransform;
    private GameManager gameManager;

    private void Start() {
        // Cursor.lockState = CursorLockMode.Locked;
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void Update() {
        if (gameManager.IsPaused) return;

        Ray mouseRay = viewCamera.ScreenPointToRay(Input.mousePosition);
        spotLightTransform.LookAt(mouseRay.origin + mouseRay.direction);
    }
}
