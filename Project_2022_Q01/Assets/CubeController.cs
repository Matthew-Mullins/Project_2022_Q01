using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CubeController : MonoBehaviour {
    
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 200f;

    private void Update(){
        Swipe();
        if (transform.rotation != target.transform.rotation) {
            float step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
        }
    }

    void Swipe(){
        if (Input.GetMouseButtonDown(1)) {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(1)){
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            if (LeftSwipe(currentSwipe)){
                target.transform.Rotate(Vector3.up * 90, Space.World);
            } else if (RightSwipe(currentSwipe)) {
                target.transform.Rotate(Vector3.up * -90, Space.World);
            } else if (UpRightSwipe(currentSwipe)){
                target.transform.Rotate(Vector3.right * 90, Space.World);
            } else if (DownLeftSwipe(currentSwipe)) {
                target.transform.Rotate(Vector3.right * -90, Space.World);
            } else if (UpLeftSwipe(currentSwipe)) {
                target.transform.Rotate(Vector3.forward * 90, Space.World);
            } else if (DownRightSwipe(currentSwipe)) {
                target.transform.Rotate(Vector3.forward * -90, Space.World);
            }
        }
    }

    bool LeftSwipe(Vector2 swipe) {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe) {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool UpRightSwipe(Vector2 swipe) {
        return currentSwipe.y > 0 && currentSwipe.x > 0;
    }
    bool DownLeftSwipe(Vector2 swipe) {
        return currentSwipe.y < 0 && currentSwipe.x < 0;
    }
    bool UpLeftSwipe(Vector2 swipe) {
        return currentSwipe.y > 0 && currentSwipe.x < 0;
    }
    bool DownRightSwipe(Vector2 swipe) {
        return currentSwipe.y < 0 && currentSwipe.x > 0;
    }

}
