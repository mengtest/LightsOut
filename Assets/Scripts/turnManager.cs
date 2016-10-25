using UnityEngine;
using System.Collections;

public class turnManager : MonoBehaviour {

	void Start() {
		// Generate the initial cubes in the scene
		int count = 1;
		float gap = 3f;

		for(int i = 0; i < 5; i++){
			for(int j = 0; j < 5; j++){
				GameObject tmpGb = Instantiate(Resources.Load("Cube", typeof(GameObject))) as GameObject;
				tmpGb.transform.position = new Vector3(j*1.5f-gap, i*-1.5f+gap, 0);
				tmpGb.name = count.ToString();
				count++;
			}
		}

		// test: loading a xml level
		this.gameObject.GetComponent<levelHandler>().loadLevel(1);
	}
		
	void Update() {
		// Casting a ray to see which object was clicked
		if (Input.GetMouseButtonUp (0)){
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 100)) {
				makeMove(int.Parse(hit.collider.gameObject.name));
			}
		}
	}

	void makeMove (int name){
		
		turn(name);
		turn(name + 5);
		turn(name - 5);
		if (name%5 != 0){
			turn(name + 1);
		}
		if (name%5 != 1){
			turn(name - 1);
		}
	}

	void turn(int name){
		
		if(name<1 || name > 25) return;

		GameObject turnObj = GameObject.Find(name.ToString()).gameObject;
		turnObj.GetComponent<lightSwitch>().change();
	}
}
