using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipInformation : MonoBehaviour
{
	//　アイテムの種類を表す列挙型
	public enum KindOfItem
	{
		Charactor,
		Body,
		Tire,
		Kite
	};

	//　アイテムの種類
	[SerializeField]
	private KindOfItem kindOfItem;
	//　位置情報
	[SerializeField]
	private Vector3 pos;
	//　角度情報
	[SerializeField]
	private Vector3 rot;
	//　Scale情報
	[SerializeField]
	private Vector3 scale;

	//　アイテムの種類を返す
	public KindOfItem GetKindOfItem()
	{
		return kindOfItem;
	}
	//　位置情報を返す
	public Vector3 GetPosition()
	{
		return pos;
	}

	//　回転情報を返す
	public Vector3 GetRotation()
	{
		return rot;
	}

	//　大きさ情報を返す
	public Vector3 GetScale()
	{
		return scale;
	}
}
