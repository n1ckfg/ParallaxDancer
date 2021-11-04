using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
	public float lerpSpeed = 0.1f;

    [HideInInspector] public Vector2 screenCoords;
    [HideInInspector] public bool isRunning = false;

    private void Update() {
        screenCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenCoords.x = Mathf.Clamp(screenCoords.x, -screenBounds.x, screenBounds.x); 

        transform.position = Vector2.Lerp(transform.position, new Vector2(screenCoords.x, transform.position.y), lerpSpeed);

		if (screenCoords.x < transform.position.x) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

		if (screenCoords.x > -screenBounds.x/8f && screenCoords.x < screenBounds.x/8f) {
            isRunning = false;
		} else {
            isRunning = true;
        }

        animator.SetBool("Playing", isRunning);
    }

}
