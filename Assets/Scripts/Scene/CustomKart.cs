using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectData
{
	public class CustomKart : MonoBehaviour
	{
		private MyGameManagerData myGameManagerData;

		//　キャラクターの親のボーン
		[SerializeField]
		private Transform parentCharacter;
		//　タイヤの親のボーン
		[SerializeField]
		private Transform parentTire;
		//　ボディの親のボーン
		[SerializeField]
		private Transform parentBody;
		//　グライダーの親のボーン
		[SerializeField]
		private Transform parentKite;


		
		//　タイヤゲームオブジェクト配列
		[SerializeField]
		private List<GameObject> TiresList;
		//　ボディゲームオブジェクト配列
		[SerializeField]
		private List<GameObject> BodyiesList;
		//　グライダーゲームオブジェクト配列
		[SerializeField]
		private List<GameObject> KitesList;



		//　現在選択中のキャラクター
		private GameObject character;
		//　現在選択中のタイヤ
		private GameObject tire;
		//　現在選択中のボディ
		private GameObject body;
		//　現在選択中のグライダー
		private GameObject kite;

		//　現在のタイヤ番号
		private int tireCount;
		//　現在のボディ番号
		private int bodyCount;
		//　現在のグライダー番号
		private int kiteCount;

		//グライダー用
		[SerializeField]
		private List<CapsuleCollider> capsuleColliders;

		//myGamemanagerからキャラクターを取得出来なかった場合(デバッグ用)
		public GameObject prefabCharacter;

		void Start()
		{
			myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();

			tireCount = 0;
			bodyCount = 0;

			//　最初は何も選択しない
			ChangeCharacter();
			ChangeBody();
			ChangeTire();
			ChangeKite();

			kite.SetActive(false);
		}

		void Update()
		{
			
			if (Input.GetKeyDown("1"))
			{
				kite.SetActive(false);
				ChangeBody();
			}
			else if (Input.GetKeyDown("2"))
			{
				kite.SetActive(false);
				ChangeTire();
				//Debug.Log("tireカウント:" + tireCount);
				//Debug.Log("tireゲームオブジェクト:" + tire);
				//Debug.Log("tireリスト:" + TiresList);
			}
			else if (Input.GetKeyDown("3"))
			{
				kite.SetActive(true);
				ChangeKite();
			}
			
		}

		//作成したPlayerの情報をmyGameManagerに入れる
		public void OnCompleteCharacter(GameObject player)
        {
			kite.SetActive(false);
			//scene遷移しても破棄されないようにする
			DontDestroyOnLoad(player);
			myGameManagerData.SetCharacter(player);
        }

        //　キャラクター変更関数
        void ChangeCharacter()
        {
            //　キャラクターが設定されている時
            if (myGameManagerData.GetCharacter() != null)
            {
                Debug.Log("myGameManagerData.GetCharacter().gameObject!=null");

                var equipInfo = myGameManagerData.GetCharacter().GetComponent<EquipInformation>();
                //　キャラクターの番号でプレハブをインスタンス化
                character = Instantiate<GameObject>(myGameManagerData.GetCharacter());
                //　parentArmorを親要素に設定
                character.transform.SetParent(parentCharacter);
                //　キャラクターの位置・回転・大きさの設定を行う
                character.transform.localPosition = equipInfo.GetPosition();
                character.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
                character.transform.localScale = equipInfo.GetScale();


            }
            else
            {
                Debug.Log("myGameManagerData.GetCharacter().gameObject==null");
                //myGamemanagerからキャラクターを取得出来なかった場合
                myGameManagerData.SetCharacter(prefabCharacter);

                var equipInfo = myGameManagerData.GetCharacter().GetComponent<EquipInformation>();
                //　キャラクターの番号でプレハブをインスタンス化
                character = Instantiate<GameObject>(myGameManagerData.GetCharacter());
                //　parentArmorを親要素に設定
                character.transform.SetParent(parentCharacter);
                //　キャラクターの位置・回転・大きさの設定を行う
                character.transform.localPosition = equipInfo.GetPosition();
                character.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
                character.transform.localScale = equipInfo.GetScale();
            }

        }

        //　アイテム変更関数
        void ChangeBody()
		{

			//　今選択しているアイテムを削除
			if (body != null)
			{
				Destroy(body);
			}

			//　選択が設定されている時
			if (bodyCount < BodyiesList.Count)
			{
				var equipInfo = BodyiesList[bodyCount].GetComponent<EquipInformation>();
				//　ボディの番号でプレハブをインスタンス化
				body = GameObject.Instantiate(BodyiesList[bodyCount]);
				//　parentBodyを親要素に設定
				body.transform.SetParent(parentBody);
				//　アイテムの位置・回転・大きさの設定を行う
				body.transform.localPosition = equipInfo.GetPosition();
				body.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
				body.transform.localScale = equipInfo.GetScale();
				//　選択が設定されていない時はボディインスタンスを削除
			}

			bodyCount++;
			if (bodyCount >= BodyiesList.Count)
			{
				bodyCount = 0;
			}
		}

		void ChangeTire()
		{
			//　今選択しているアイテムを削除
			if (tire != null)
			{
				Destroy(tire);
			}

			//　選択が設定されている時
			if (tireCount < TiresList.Count)
			{
				var equipInfo = TiresList[tireCount].GetComponent<EquipInformation>();
				//　タイヤの番号でプレハブをインスタンス化
				tire = GameObject.Instantiate(TiresList[tireCount]);
				//　parentTireを親要素に設定
				tire.transform.SetParent(parentTire);
				//　アイテムの位置・回転・大きさの設定を行う
				tire.transform.localPosition = equipInfo.GetPosition();
				tire.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
				tire.transform.localScale = equipInfo.GetScale();
				//　選択が設定されていない時はタイヤインスタンスを削除
			}

			tireCount++;
			if (tireCount >= TiresList.Count)
			{
				tireCount = 0;
			}


		}
		void ChangeKite()
		{
			//　今選択しているアイテムを削除
			if (kite != null)
			{
				Destroy(kite);
			}

			//　選択が設定されている時
			if (kiteCount < KitesList.Count)
			{
				var equipInfo = KitesList[kiteCount].GetComponent<EquipInformation>();
				//　タイヤの番号でプレハブをインスタンス化
				kite = GameObject.Instantiate(KitesList[kiteCount]);
				//　parentTireを親要素に設定
				kite.transform.SetParent(parentKite);
				//　アイテムの位置・回転・大きさの設定を行う
				kite.transform.localPosition = equipInfo.GetPosition();
				kite.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
				kite.transform.localScale = equipInfo.GetScale();
				//　選択が設定されていない時はグライダーインスタンスを削除
			}

			kiteCount++;
			if (kiteCount >= KitesList.Count)
			{
				kiteCount = 0;
			}
		}


	}
}