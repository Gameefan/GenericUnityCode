using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
	[Header("Movement")]
	public Rigidbody2D rb;
	public float speed = 10f;
	[Header("Camera")]
	public Transform cameraTransform;
	public float cameraSpeed = 10f;
	public float camSmooth = 1f;
	[Header("Animation")]
	public bool moveAnimation = true;
	public Animator gfxAnimator;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		rb.MovePosition((Vector2.up * Time.fixedDeltaTime * speed * Input.GetAxisRaw("Vertical") + Vector2.right * Time.fixedDeltaTime * speed * Input.GetAxisRaw("Horizontal")) + rb.position);
		cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, Vector2.up * Time.fixedDeltaTime * cameraSpeed * Input.GetAxis("Vertical") + Vector2.right * Time.fixedDeltaTime * cameraSpeed * Input.GetAxis("Horizontal") + rb.position, camSmooth);
		//cameraTransform.position = (new Vector3(rb.position.x, rb.position.y) - cameraTransform.position) + new Vector3(rb.position.x, rb.position.y);
		//cameraTransform.position = Vector3.Lerp(cameraTransform.position, Vector2.up * Time.fixedDeltaTime * cameraSpeed * Input.GetAxis("Vertical") + Vector2.right * Time.fixedDeltaTime * cameraSpeed * Input.GetAxis("Horizontal") + rb.position, camSmooth);
		cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, -10f);
		if (moveAnimation)
		{
			gfxAnimator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
			gfxAnimator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		}
	}
}
