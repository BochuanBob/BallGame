using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed=5.0f;

    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        countText.text = "Scores: " + count;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (Input.touchCount > 0)
        {
            float x = Input.GetTouch(0).deltaPosition.x;
            float y = Input.GetTouch(0).deltaPosition.y;
            movement = new Vector3(x, 0.0f, y);
        }
        //this.transform.position = new Vector3(this.transform.position.x + moveHorizontal, this.transform.position.y, this.transform.position.z+moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
        }

        countText.text = "Scores: " + count;

        if (count == 8)
        {
            winText.text = "You Win!!!";
        }
    }
}
