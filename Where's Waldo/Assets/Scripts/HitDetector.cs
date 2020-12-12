using UnityEngine;

public class HitDetector : MonoBehaviour {

    public Camera viewCamera;
    private GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
            Shoot();
    }
    
    void Shoot() {
        if (gameManager.IsPaused) return;

        RaycastHit hit;
        Ray mouseRay = viewCamera.ScreenPointToRay(Input.mousePosition);
        bool didHit = Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit);
        if (didHit)
            gameManager.CatchCharacter(hit.transform.name);
    }
}
