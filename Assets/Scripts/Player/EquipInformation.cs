using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipInformation : MonoBehaviour
{
	//�@�A�C�e���̎�ނ�\���񋓌^
	public enum KindOfItem
	{
		Charactor,
		Body,
		Tire,
		Kite
	};

	//�@�A�C�e���̎��
	[SerializeField]
	private KindOfItem kindOfItem;
	//�@�ʒu���
	[SerializeField]
	private Vector3 pos;
	//�@�p�x���
	[SerializeField]
	private Vector3 rot;
	//�@Scale���
	[SerializeField]
	private Vector3 scale;

	//�@�A�C�e���̎�ނ�Ԃ�
	public KindOfItem GetKindOfItem()
	{
		return kindOfItem;
	}
	//�@�ʒu����Ԃ�
	public Vector3 GetPosition()
	{
		return pos;
	}

	//�@��]����Ԃ�
	public Vector3 GetRotation()
	{
		return rot;
	}

	//�@�傫������Ԃ�
	public Vector3 GetScale()
	{
		return scale;
	}
}
