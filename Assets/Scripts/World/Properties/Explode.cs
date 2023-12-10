using System.Collections;
using UnityEngine;

public class Explode : BaseProperty
{
    float radius = 2f;

    override public IEnumerator Complete() {
        GameObject explosion = Instantiate(GameManager.Instance.explosion, transform.position, Quaternion.identity, transform.parent);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.up);
        foreach (var h in hits) {
            if (h.collider.gameObject.CompareTag("HoneyContainer")) {
                h.collider.gameObject.GetComponent<HoneyContainerScript>().Fill();
            }
        }
        transform.gameObject.SetActive(false);
        yield return null;
    }
    override public IEnumerator Stop() {
        yield return null;
    }
}
