using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControl : MonoBehaviour {

    public Player player;
    public float parallaxSpeed = 2f;
    public Parallaxer[] parallaxers;

    private void Update() {
        for (int i = 0; i < parallaxers.Length; i++) {
            if (player.isRunning) {
                parallaxers[i].speed = player.transform.position.x * (i + 1) * parallaxSpeed;
            } else {
                parallaxers[i].speed = 0f;
            }
            if (player.screenCoords.x < player.transform.position.x) parallaxers[i].speed = -Mathf.Abs(parallaxers[i].speed);
        }
    }

}
