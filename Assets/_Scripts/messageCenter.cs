using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageCenter : MonoBehaviour {

	public GameObject messagePrefab;

	public List<GameObject> messages;

	void Start () {

	}

	public void createMessage(string input){
		GameObject newMessage = Instantiate(messagePrefab);
		newMessage.transform.position = this.transform.position;
		newMessage.transform.rotation = this.transform.rotation;
		newMessage.transform.SetParent(this.transform);
		newMessage.GetComponent<TextMesh>().text = input;
		if(input == "Assassin killed."){
			newMessage.GetComponent<TextMesh>().color = Color.red;
		}
		//Update positions of all old messages
		int len = messages.Count;
		for(int i=0;i<len;i++){
			if(messages[i] != null){
				Vector3 temp = messages[i].transform.position;
				temp.y -= .05f;
				temp.x = this.transform.position.x;
				temp.z = this.transform.position.z;
				messages[i].transform.position = temp;
			}//else{
			//	messages.Remove(i);
			//}
		}
		//Push new message to list
		messages.Add(newMessage);
	}

}
