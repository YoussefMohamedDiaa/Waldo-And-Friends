using UnityEngine;

public class kayaAnimation : MonoBehaviour {
    
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        anim.SetBool("isCought", true);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            Debug.Log("jere");
            anim.SetBool("isCought", false);
        }
    }
}
