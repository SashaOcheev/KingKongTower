using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TrumpCtrl : MonoBehaviour {

    private Rigidbody rb;
    private Animation anim;

    [SerializeField]
    private float speed = 4f;

    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
    }

    void Update() {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);
        rb.velocity = movement * speed;

        if (x != 0 && y != 0)
        {
            var yEulerRotation = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yEulerRotation, transform.eulerAngles.z);
        }

        if (x != 0 || y != 0)
        {
            anim.Play("walk");
        }
        else
        {
            anim.Play("idle");
        }
	}
}
