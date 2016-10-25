using UnityEngine;
using System.Collections;

public class lightSwitch : MonoBehaviour {

	public bool isOn = false;

	public void change() {
		if(isOn){
			isOn = false;
			this.transform.localEulerAngles = new Vector3(0,45,0);
		}else{
			isOn = true;
			this.transform.localEulerAngles = Vector3.zero;
		}
	}
}
