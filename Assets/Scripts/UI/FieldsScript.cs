using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldsScript : MonoBehaviour
{
    public void SetActiveField(string text) {
        switch (text) {
            case "Touch":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Near":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "Explode":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "FollowPath":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "Freeze":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(4).gameObject.SetActive(true);
                break;
            case "Impulse":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(5).gameObject.SetActive(true);
                break;
            case "Wait":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(6).gameObject.SetActive(true);
                break;
            case "Weight":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(7).gameObject.SetActive(true);
                break;
            case "ZeroGravity":
                for (int i = 0; i < transform.childCount ; ++i) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                transform.GetChild(8).gameObject.SetActive(true);
                break;
        }
    }
}
