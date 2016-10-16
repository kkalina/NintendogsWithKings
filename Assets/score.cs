using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

    public int currScore;
    public int dispScore;
    private TextMesh scoreBoard;
    private GameObject playerObj;
    private FPSControl playerController;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("FPS_Player");
        playerController = playerObj.GetComponent<FPSControl>();
        scoreBoard = this.gameObject.GetComponent<TextMesh>();
        dispScore = playerController.damage;
        scoreBoard.text = "$" + dispScore.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currScore = playerController.damage;
        if (currScore > dispScore)
        {
            dispScore += (int)Mathf.Ceil(((currScore + dispScore) *.0005f));
            scoreBoard.text = "$" + dispScore.ToString();
        }
	}
}
