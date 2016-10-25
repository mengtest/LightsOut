using UnityEngine;
using System.Collections;

public class turnManager : MonoBehaviour {

	void Start () {

		int count = 1;

		for(int i = 0; i<5; i++){
			for(int j = 0; j<5; j++){
				GameObject tmpGb = Instantiate(Resources.Load("Cube", typeof(GameObject))) as GameObject;
				tmpGb.transform.position = new Vector3(j*1.5f-3,i*-1.5f+3,0);
				tmpGb.name = count.ToString();
				count++;
			}
		}
	}

}
