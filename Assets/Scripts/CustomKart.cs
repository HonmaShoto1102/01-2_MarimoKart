using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomKart : MonoBehaviour
{
	//　キャラクターの親のボーン
	[SerializeField]
	private Transform parentCharactor;
	//　タイヤの親のボーン
	[SerializeField]
	private Transform parentTire;
	//　ボディの親のボーン
	[SerializeField]
	private Transform parentBody;

	//　キャラクターゲームオブジェクト配列
	[SerializeField]
	private List<GameObject> Charactors;
	//　タイヤゲームオブジェクト配列
	[SerializeField]
	private List<GameObject> Tires;
	//　ボディゲームオブジェクト配列
	[SerializeField]
	private List<GameObject> Bodyies;

	//　現在選択中のキャラクター
	private GameObject charactor;
	//　現在選択中のタイヤ
	private GameObject tire;
	//　現在選択中のボディ
	private GameObject body;

	//　現在のキャラクター番号
	private int charactorCount;
	//　現在のタイヤ番号
	private int tireCount;
	//　現在のボディ番号
	private int bodyCount;

	[SerializeField]
	private List<CapsuleCollider> capsuleColliders;

	void Start()
	{
		charactorCount = 0;
		tireCount = 0;
		bodyCount = 0;

		//　最初は何も選択しない
		ChangeCharactor();
		ChangeItem();
	}

	void Update()
	{
		//　1キーが押されたらキャラクターを変更
		if (Input.GetKeyDown("1"))
		{
			ChangeCharactor();
			//　2キーが押されたらすね用ガードを変更
		}
		else if (Input.GetKeyDown("2"))
		{
			ChangeItem();
		}
	}

	//　キャラクター変更関数
	void ChangeCharactor()
	{
		//　今選択しているキャラクターを削除
		if (charactor != null)
		{
			Destroy(charactor);
		}

		//　選択が設定されている時
		if (charactorCount != 0)
		{
			var equipInfo = Charactors[charactorCount].GetComponent<EquipInformation>();
			//　キャラクターの番号でプレハブをインスタンス化
			charactor = Instantiate<GameObject>(Charactors[charactorCount]);
			//　parentArmorを親要素に設定
			charactor.transform.SetParent(parentCharactor);
			//　キャラクターの位置・回転・大きさの設定を行う
			charactor.transform.localPosition = equipInfo.GetPosition();
			charactor.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			charactor.transform.localScale = equipInfo.GetScale();

			//　Clothを使う場合はコライダを設定
			var cloth = charactor.GetComponentInChildren<Cloth>();
			if (cloth != null)
			{
				cloth.capsuleColliders = capsuleColliders.ToArray();
			}
		}
		charactorCount++;

		if (charactorCount >= Charactors.Count)
		{
			charactorCount = 0;
		}
	}

	//　アイテム変更関数
	void ChangeItem()
	{

		//　今選択しているアイテムを削除
		if (tire != null)
		{
			Destroy(tire);
		}
		if (body != null)
		{
			Destroy(body);
		}

		//　選択が設定されている時
		if (tireCount != 0)
		{
			var equipInfo = Tires[tireCount].GetComponent<EquipInformation>();
			//　タイヤの番号でプレハブをインスタンス化
			tire = GameObject.Instantiate(Tires[tireCount]);
			//　parentTireを親要素に設定
			tire.transform.SetParent(parentTire);
			//　アイテムの位置・回転・大きさの設定を行う
			tire.transform.localPosition = equipInfo.GetPosition();
			tire.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			tire.transform.localScale = equipInfo.GetScale();
			//　選択が設定されていない時はキャラクターインスタンスを削除
		}

		tireCount++;
		if (tireCount >= Tires.Count)
		{
			tireCount = 0;
		}
		//　選択が設定されている時
		if (bodyCount != 0)
		{
			var equipInfo = Bodyies[bodyCount].GetComponent<EquipInformation>();
			//　ボディの番号でプレハブをインスタンス化
			body = GameObject.Instantiate(Bodyies[bodyCount]);
			//　parentBodyを親要素に設定
			body.transform.SetParent(parentBody);
			//　アイテムの位置・回転・大きさの設定を行う
			body.transform.localPosition = equipInfo.GetPosition();
			body.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			body.transform.localScale = equipInfo.GetScale();
			//　選択が設定されていない時はキャラクターインスタンスを削除
		}

		bodyCount++;
		if (bodyCount >= Bodyies.Count)
		{
			bodyCount = 0;
		}
	}
}
