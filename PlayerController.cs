using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	[Space(10)]
	[Header("Ship Stats")]
	public float speed;
	[SerializeField]
	private float angularSpeed;
	[SerializeField]



	public GameObject bullet;
	public Text scoreText;
	private int currentScore = 0;



	float[] moveVector = new float[3];     



	Rigidbody rb;


	int movey;
	int movex;
	bool returnOrigin;

	void Start()
	{

		rb = GetComponent<Rigidbody>();


		movey = 0;
		movex = 0;
		returnOrigin = false;



	}


	void Update()
	{
		

		CheckKeyboardInput();


		MoveShip();
	

	}

	void CheckKeyboardInput()
	{
		Vector3 zero = new Vector3 (0, 0, transform.position.z);
		if (Input.GetKey ("up") && transform.position == zero) {movey = 1; movex = 0;  Debug.Log (transform.position.z);   }

		else if (Input.GetKey ("down") && transform.position == zero) {movey = -1; movex = 0;     }

		else if (Input.GetKey ("right") && transform.position == zero) {movex = 1; movey = 0;     }

		else if (Input.GetKey ("left") && transform.position == zero) {movex = -1; movey = 0;     }




	}

	void MoveShip()
	{
		Vector3 movement = Vector3.zero;
		Vector3 forward = transform.forward;
		forward.z = 1;

		transform.position += forward* Time.deltaTime * speed;
		Vector3 pos = transform.position;
		pos.y = Mathf.Clamp(pos.y, -4, 4);
		pos.x = Mathf.Clamp(pos.x, -4, 4);

		transform.position = pos;




		if (movey == 1 ) {
			
			pos.y = Mathf.Clamp(pos.y, 0, 4);
			transform.position = pos;

			if (pos.y == 4 ) {

				if( !Input.GetKey ("up"))
				returnOrigin = true;

				movement.x = 0;

				Quaternion rotat = transform.rotation;
				transform.rotation = Quaternion.RotateTowards (rotat, Quaternion.Euler(0,0,0) , Time.deltaTime*150);
			}

			if (returnOrigin == true ) {
				movement += new Vector3 (1, moveVector [1], moveVector [2]);
				if (pos.y == 0) {
					movement.x = 0;
					Vector3 rotat = transform.rotation.eulerAngles;
					rotat.x = 0;
					transform.rotation = Quaternion.Euler (rotat);
					returnOrigin = false;
					movey = 0;
					Debug.Log (transform.position.z);
				}
			}
			else if(returnOrigin== false && pos.y!=4)
			movement += new Vector3 (-1, moveVector [1], moveVector [2]);

		}

		if (movey == -1 ) {

			pos.y = Mathf.Clamp(pos.y, -4, 0);
			transform.position = pos;

			if (pos.y == -4 ) {

				if( !Input.GetKey ("down"))
					returnOrigin = true;

				movement.x = 0;
				Quaternion rotat = transform.rotation;
				transform.rotation = Quaternion.RotateTowards (rotat, Quaternion.Euler(0,0,0) , Time.deltaTime*150);
			}

			if (returnOrigin == true ) {
				movement += new Vector3 (-1, moveVector [1], moveVector [2]);
				if (pos.y == 0) {
					movement.x = 0;
					Vector3 rotat = transform.rotation.eulerAngles;
					rotat.x = 0;
					transform.rotation = Quaternion.Euler (rotat);
					returnOrigin = false;
					movey = 0;
				}
			}
			else if(returnOrigin== false && pos.y!=-4)
				movement += new Vector3 (1, moveVector [1], moveVector [2]);

		}

		if (movex == 1) {
			pos.x = Mathf.Clamp(pos.x, 0, 4);
			transform.position = pos;
				
			if (pos.x == 4) {

				if( !Input.GetKey ("right"))
					returnOrigin = true;

				movement.y = 0;

				Quaternion rotat = transform.rotation;
				transform.rotation = Quaternion.RotateTowards (rotat, Quaternion.Euler(0,0,0) , Time.deltaTime*150);
			}

			if (returnOrigin) {
				movement += new Vector3 (moveVector [0], -1, moveVector [2]);
				if (pos.x == 0) {
					movement.y = 0;
					Vector3 rotat = transform.rotation.eulerAngles;
					rotat.y = 0;
					transform.rotation = Quaternion.Euler (rotat);
					returnOrigin = false;
					movex = 0;
				}

			}

			else if(returnOrigin== false && pos.x != 4)
				movement += new Vector3 (moveVector [0], 1, moveVector [2]);
			
			
		}

		if (movex == -1) {
			pos.x = Mathf.Clamp(pos.x, -4, 0);
			transform.position = pos;

			if (pos.x == -4) {

				if( !Input.GetKey ("left"))
					returnOrigin = true;

				movement.y = 0;
				Quaternion rotat = transform.rotation;
				transform.rotation = Quaternion.RotateTowards (rotat, Quaternion.Euler(0,0,0) , Time.deltaTime*150);
			}

			if (returnOrigin) {
				movement += new Vector3 (moveVector [0], 1, moveVector [2]);
				if (pos.x == 0) {
					movement.y = 0;
					Vector3 rotat = transform.rotation.eulerAngles;
					rotat.y = 0;
					transform.rotation = Quaternion.Euler (rotat);
					returnOrigin = false;
					movex = 0;
				}

			}

			else if(returnOrigin== false && pos.x != -4)
				movement += new Vector3 (moveVector [0], -1, moveVector [2]);


		}


		Vector3 rot = movement.normalized * angularSpeed * Time.deltaTime;
		transform.Rotate (rot);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Bullet")) 
		{
			currentScore++;
			scoreText.text = "Score: " + currentScore;
			Debug.Log ("çarptı");
			ParticleSystem ps = other.GetComponentInChildren<ParticleSystem> ();

		}

		if (other.CompareTag ("Finish")) 
		{
			Destroy (gameObject);

		}
	}


}
