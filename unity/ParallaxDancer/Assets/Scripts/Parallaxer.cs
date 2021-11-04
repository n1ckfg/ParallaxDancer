using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour {

    public float speed;
    public SpriteRenderer spriteRen;
    public MeshRenderer meshRen;

    [HideInInspector] public bool is3D = false;

    private Parallaxer dupeLayer;
    private bool isDupe = false;
    private float spriteWidth;
    private float startX, endX;
    private Vector2 delta = Vector2.zero;

    private void Start() {
        if (gameObject.name.Split('(')[0] != transform.parent.name.Split('(')[0]) {
            dupeLayer = GameObject.Instantiate(gameObject).GetComponent<Parallaxer>();
            dupeLayer.isDupe = true;
            dupeLayer.transform.SetParent(transform);

            if (spriteRen != null) {
                is3D = false;
                spriteWidth = spriteRen.sprite.rect.width / 100f; // half pixel width / 100
            } else {
                is3D = true;
                spriteWidth = meshRen.bounds.size.x;
            }

            transform.Translate(new Vector3(spriteWidth, 0f, 0f));
            startX = transform.position.x;
            endX = startX - spriteWidth;

            dupeLayer.startX = startX - spriteWidth;
            dupeLayer.transform.position = new Vector3(dupeLayer.startX, transform.position.y, transform.position.z);
        }
    }

    private void Update() {
        if (!isDupe) {
            delta = Vector2.left * speed * Time.deltaTime;

            transform.Translate(delta);

            if (transform.position.x < endX) {
				transform.position = new Vector3(startX, transform.position.y, transform.position.z);
            } else if (transform.position.x > startX) {
                transform.position = new Vector3(endX, transform.position.y, transform.position.z);
            }
        }
    }

}
