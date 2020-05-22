using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	[SerializeField] private Transform target;

	[SerializeField] private float distance = 10;

	private float initalDistance;

	[SerializeField] private float height = 2;



	void Start(){
		initalDistance = distance;

	}

	void LateUpdate ()
	{
		
		if (!target)
			return;


		float wantedHeight = target.position.y + height;


		float currentHeight = transform.position.y;


		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, 2 * Time.deltaTime);

	
		transform.position = target.position;
		transform.position -= Vector3.forward * distance;


		transform.position = new Vector3(0, currentHeight, transform.position.z);


	}
       
    }

		

