using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class levelHandler : MonoBehaviour {

	XmlDocument levelDoc;
	XmlNodeList levelList;
	List<string> levelArray;

	void Start () {
		levelArray = new List<string>();
		levelDoc = new XmlDocument();

		TextAsset xmlFile = Resources.Load("levels", typeof(TextAsset)) as TextAsset;
		levelDoc.LoadXml (xmlFile.text);
		levelList = levelDoc.GetElementsByTagName ("level");
		foreach(XmlNode levelData in levelList) {
			XmlNodeList levelInfo = levelData.ChildNodes;
			foreach(XmlNode data in levelInfo) {
				if (data.Name == "setup"){
					levelArray.Add(data.InnerText);
				}
			}
		}
	}

	public void loadLevel(int nr) {
		string[] levelString = levelArray[nr -1].Split(',');
		foreach(string brick in levelString){
			GameObject.Find(brick).GetComponent<lightSwitch>().change();
		}
	}
}
