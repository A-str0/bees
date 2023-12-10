using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public float time = 1f;
    public float delay = 0.1f;
    public float dumping = 5f;
    public Vector3 offset = new(1f, 2f);
    public TMP_Text textMesh;

    bool isInDialogue;
    Transform target;

    public void SetText(string txt) => StartCoroutine(SetTextCoroutine(txt));
    public void SetText(string[] txt) => StartCoroutine(SetTextCoroutine(txt));

    private void Start() {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate() {
        if (!isInDialogue) return;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * dumping);
    }

    public IEnumerator SetTextCoroutine(string txt) {
        isInDialogue = true;
        yield return TextAppear(txt);
        yield return new WaitForSeconds(time);
        isInDialogue = false;
        gameObject.SetActive(false);
        yield return null;
    }

    public IEnumerator SetTextCoroutine(string[] txt) {
        isInDialogue = true;
        for (int i = 0; i < txt.Length; ++i) {
            yield return TextAppear(txt[i]);
            yield return new WaitForSeconds(time);
        }
        isInDialogue = false;
        gameObject.SetActive(false);
        yield return null;
    }

    private IEnumerator TextAppear(string txt) {
        for (int i = 0; i <= txt.Length; i++) {
			textMesh.text = txt.Substring(0, i);;
			yield return new WaitForSeconds(delay);
		}
    }
}
