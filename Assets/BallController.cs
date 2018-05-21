using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//	ポイントを表示するテキスト
	private GameObject pointText;
	//ポイントの点数
	public int gamePointFigure;


	// Use this for initialization
	void Start() {
		//シーン中のGameOverText オブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		//シーン中のPointText オブジェクトを取得
		this.pointText = GameObject.Find("PointText");
	}


	
	// Update is called once per frame
	void Update () {
		// ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other) {

		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "SmallStarTag"
			|| other.gameObject.tag == "SmallCloudTag"
			) {
			gamePointFigure += 10;
		} else if (other.gameObject.tag == "LargeStarTag"
			|| other.gameObject.tag == "LargeCloudTag") {
			gamePointFigure += 20;
		}

		this.pointText.GetComponent<Text>().text = gamePointFigure + "点";
			
	} 
}
