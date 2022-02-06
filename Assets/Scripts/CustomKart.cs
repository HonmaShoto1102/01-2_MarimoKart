using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomKart : MonoBehaviour
{
	//�@�L�����N�^�[�̐e�̃{�[��
	[SerializeField]
	private Transform parentCharactor;
	//�@�^�C���̐e�̃{�[��
	[SerializeField]
	private Transform parentTire;
	//�@�{�f�B�̐e�̃{�[��
	[SerializeField]
	private Transform parentBody;

	//�@�L�����N�^�[�Q�[���I�u�W�F�N�g�z��
	[SerializeField]
	private List<GameObject> Charactors;
	//�@�^�C���Q�[���I�u�W�F�N�g�z��
	[SerializeField]
	private List<GameObject> Tires;
	//�@�{�f�B�Q�[���I�u�W�F�N�g�z��
	[SerializeField]
	private List<GameObject> Bodyies;

	//�@���ݑI�𒆂̃L�����N�^�[
	private GameObject charactor;
	//�@���ݑI�𒆂̃^�C��
	private GameObject tire;
	//�@���ݑI�𒆂̃{�f�B
	private GameObject body;

	//�@���݂̃L�����N�^�[�ԍ�
	private int charactorCount;
	//�@���݂̃^�C���ԍ�
	private int tireCount;
	//�@���݂̃{�f�B�ԍ�
	private int bodyCount;

	[SerializeField]
	private List<CapsuleCollider> capsuleColliders;

	void Start()
	{
		charactorCount = 0;
		tireCount = 0;
		bodyCount = 0;

		//�@�ŏ��͉����I�����Ȃ�
		ChangeCharactor();
		ChangeItem();
	}

	void Update()
	{
		//�@1�L�[�������ꂽ��L�����N�^�[��ύX
		if (Input.GetKeyDown("1"))
		{
			ChangeCharactor();
			//�@2�L�[�������ꂽ�炷�˗p�K�[�h��ύX
		}
		else if (Input.GetKeyDown("2"))
		{
			ChangeItem();
		}
	}

	//�@�L�����N�^�[�ύX�֐�
	void ChangeCharactor()
	{
		//�@���I�����Ă���L�����N�^�[���폜
		if (charactor != null)
		{
			Destroy(charactor);
		}

		//�@�I�����ݒ肳��Ă��鎞
		if (charactorCount != 0)
		{
			var equipInfo = Charactors[charactorCount].GetComponent<EquipInformation>();
			//�@�L�����N�^�[�̔ԍ��Ńv���n�u���C���X�^���X��
			charactor = Instantiate<GameObject>(Charactors[charactorCount]);
			//�@parentArmor��e�v�f�ɐݒ�
			charactor.transform.SetParent(parentCharactor);
			//�@�L�����N�^�[�̈ʒu�E��]�E�傫���̐ݒ���s��
			charactor.transform.localPosition = equipInfo.GetPosition();
			charactor.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			charactor.transform.localScale = equipInfo.GetScale();

			//�@Cloth���g���ꍇ�̓R���C�_��ݒ�
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

	//�@�A�C�e���ύX�֐�
	void ChangeItem()
	{

		//�@���I�����Ă���A�C�e�����폜
		if (tire != null)
		{
			Destroy(tire);
		}
		if (body != null)
		{
			Destroy(body);
		}

		//�@�I�����ݒ肳��Ă��鎞
		if (tireCount != 0)
		{
			var equipInfo = Tires[tireCount].GetComponent<EquipInformation>();
			//�@�^�C���̔ԍ��Ńv���n�u���C���X�^���X��
			tire = GameObject.Instantiate(Tires[tireCount]);
			//�@parentTire��e�v�f�ɐݒ�
			tire.transform.SetParent(parentTire);
			//�@�A�C�e���̈ʒu�E��]�E�傫���̐ݒ���s��
			tire.transform.localPosition = equipInfo.GetPosition();
			tire.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			tire.transform.localScale = equipInfo.GetScale();
			//�@�I�����ݒ肳��Ă��Ȃ����̓L�����N�^�[�C���X�^���X���폜
		}

		tireCount++;
		if (tireCount >= Tires.Count)
		{
			tireCount = 0;
		}
		//�@�I�����ݒ肳��Ă��鎞
		if (bodyCount != 0)
		{
			var equipInfo = Bodyies[bodyCount].GetComponent<EquipInformation>();
			//�@�{�f�B�̔ԍ��Ńv���n�u���C���X�^���X��
			body = GameObject.Instantiate(Bodyies[bodyCount]);
			//�@parentBody��e�v�f�ɐݒ�
			body.transform.SetParent(parentBody);
			//�@�A�C�e���̈ʒu�E��]�E�傫���̐ݒ���s��
			body.transform.localPosition = equipInfo.GetPosition();
			body.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			body.transform.localScale = equipInfo.GetScale();
			//�@�I�����ݒ肳��Ă��Ȃ����̓L�����N�^�[�C���X�^���X���폜
		}

		bodyCount++;
		if (bodyCount >= Bodyies.Count)
		{
			bodyCount = 0;
		}
	}
}
