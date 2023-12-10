using System.Collections;
using System.Reflection.Emit;
using UnityEngine;

public class FollowPath : BaseProperty
{
    public float speed = 1f;

    Rigidbody2D rb;
    PathScript path;
    bool isFollowing;
    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    override public IEnumerator Complete() {
        path = GameManager.Instance.GetNearestPath(transform.position).GetComponent<PathScript>();
        index = path.GetNearestPointIndex(transform.position);
        isFollowing = true;
        //if (Vector3.Distance(transform.position, path.points[index].position) > 0.1f) 
        while (!isReached) yield return null;
        isReached = false;
        yield return null;
    }
    override public IEnumerator Stop() {
        isFollowing = false;
        rb.velocity = Vector2.zero;
        yield return null;
    }

    int index = 0; bool isReached = false;
    private void FixedUpdate() {
        if (!isFollowing) return;
        
        if (Vector3.Distance(transform.position, path.points[index].position) <= 0.1f)  { 
            index += 1; 
            if (index >= path.points.Count) {
                index = 0;
                isReached = true;
            }
        }
        switch (rb.bodyType) {
            case RigidbodyType2D.Dynamic:
                rb.AddForce((transform.position - path.points[index].position).normalized * -speed * 3f);
                break;
            case RigidbodyType2D.Kinematic:
                rb.velocity = Vector2.Lerp(rb.velocity, (transform.position - path.points[index].position).normalized * -speed * 3f, Time.deltaTime);
                break;
        }
    }
}
