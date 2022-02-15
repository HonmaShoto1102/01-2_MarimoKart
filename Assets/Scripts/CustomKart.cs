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
	//�@�O���C�_�[�̐e�̃{�[��
	[SerializeField]
	private Transform parentKite;


	//�@�L�����N�^�[�Q�[���I�u�W�F�N�g�z��
	[SerializeField]
	private List<GameObject> CharactorsList;
	//�@�^�C���Q�[���I�u�W�F�N�g�z��
	[SerializeField]
	private List<GameObject> TiresList;
	//�@�{�f�B�Q�[���I�u�W�F�N�g�z��
	[SerializeField]
	private List<GameObject> BodyiesList;
	//�@�O���C�_�[�Q�[���I�u�W�F�N�g�z��
	[SerializeField]
	private List<GameObject> KitesList;



	//�@���ݑI�𒆂̃L�����N�^�[
	private GameObject charactor;
	//�@���ݑI�𒆂̃^�C��
	private GameObject tire;
	//�@���ݑI�𒆂̃{�f�B
	private GameObject body;
	//�@���ݑI�𒆂̃O���C�_�[
	private GameObject kite;

	//�@���݂̃L�����N�^�[�ԍ�
	private int charactorCount;
	//�@���݂̃^�C���ԍ�
	private int tireCount;
	//�@���݂̃{�f�B�ԍ�
	private int bodyCount;
	//�@���݂̃O���C�_�[�ԍ�
	private int kiteCount;

	[SerializeField]
	private List<CapsuleCollider> capsuleColliders;

	void Start()
	{
		charactorCount = 0;
		tireCount = 0;
		bodyCount = 0;

		//�@�ŏ��͉����I�����Ȃ�
		ChangeCharactor();
		ChangeBody();
		ChangeTire();
		ChangeKite();

	}

	void Update()
	{
		//�@1�L�[�������ꂽ��L�����N�^�[��ύX
		if (Input.GetKeyDown("1"))
		{
			ChangeCharactor();
		}
		else if (Input.GetKeyDown("2"))
		{
			ChangeBody();
		}
		else if (Input.GetKeyDown("3"))
		{
			ChangeTire();
			//Debug.Log("tire�J�E���g:" + tireCount);
			//Debug.Log("tire�Q�[���I�u�W�F�N�g:" + tire);
			//Debug.Log("tire���X�g:" + TiresList);
		}
		else if (Input.GetKeyDown("4"))
		{
			ChangeKite();
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
		if (charactorCount < CharactorsList.Count)
		{
			var equipInfo = CharactorsList[charactorCount].GetComponent<EquipInformation>();
			//�@�L�����N�^�[�̔ԍ��Ńv���n�u���C���X�^���X��
			charactor = Instantiate<GameObject>(CharactorsList[charactorCount]);
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

		if (charactorCount >= CharactorsList.Count)
		{
			charactorCount = 0;
		}
	}

	//�@�A�C�e���ύX�֐�
	void ChangeBody()
	{

		//�@���I�����Ă���A�C�e�����폜
		if (body != null)
		{
			Destroy(body);
		}

		//�@�I�����ݒ肳��Ă��鎞
		if (bodyCount < BodyiesList.Count)
		{
			var equipInfo = BodyiesList[bodyCount].GetComponent<EquipInformation>();
			//�@�{�f�B�̔ԍ��Ńv���n�u���C���X�^���X��
			body = GameObject.Instantiate(BodyiesList[bodyCount]);
			//�@parentBody��e�v�f�ɐݒ�
			body.transform.SetParent(parentBody);
			//�@�A�C�e���̈ʒu�E��]�E�傫���̐ݒ���s��
			body.transform.localPosition = equipInfo.GetPosition();
			body.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			body.transform.localScale = equipInfo.GetScale();
			//�@�I�����ݒ肳��Ă��Ȃ����̓{�f�B�C���X�^���X���폜
		}

		bodyCount++;
		if (bodyCount >= BodyiesList.Count)
		{
			bodyCount = 0;
		}
	}

	void ChangeTire()
	{
		//�@���I�����Ă���A�C�e�����폜
		if (tire != null)
		{
			Destroy(tire);
		}

		//�@�I�����ݒ肳��Ă��鎞
		if (tireCount < TiresList.Count)
		{
			var equipInfo = TiresList[tireCount].GetComponent<EquipInformation>();
			//�@�^�C���̔ԍ��Ńv���n�u���C���X�^���X��
			tire = GameObject.Instantiate(TiresList[tireCount]);
			//�@parentTire��e�v�f�ɐݒ�
			tire.transform.SetParent(parentTire);
			//�@�A�C�e���̈ʒu�E��]�E�傫���̐ݒ���s��
			tire.transform.localPosition = equipInfo.GetPosition();
			tire.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			tire.transform.localScale = equipInfo.GetScale();
			//�@�I�����ݒ肳��Ă��Ȃ����̓^�C���C���X�^���X���폜
		}

		tireCount++;
		if (tireCount >= TiresList.Count)
		{
			tireCount = 0;
		}

		
	}
	void ChangeKite()
	{
		//�@���I�����Ă���A�C�e�����폜
		if (kite != null)
		{
			Destroy(kite);
		}

		//�@�I�����ݒ肳��Ă��鎞
		if (kiteCount < KitesList.Count)
		{
			var equipInfo = KitesList[kiteCount].GetComponent<EquipInformation>();
			//�@�^�C���̔ԍ��Ńv���n�u���C���X�^���X��
			kite = GameObject.Instantiate(KitesList[kiteCount]);
			//�@parentTire��e�v�f�ɐݒ�
			kite.transform.SetParent(parentKite);
			//�@�A�C�e���̈ʒu�E��]�E�傫���̐ݒ���s��
			kite.transform.localPosition = equipInfo.GetPosition();
			kite.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
			kite.transform.localScale = equipInfo.GetScale();
			//�@�I�����ݒ肳��Ă��Ȃ����̓O���C�_�[�C���X�^���X���폜
		}

		kiteCount++;
		if (kiteCount >= KitesList.Count)
		{
			kiteCount = 0;
		}
	}


}
