using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectData
{
	public class CustomKart : MonoBehaviour
	{
		private MyGameManagerData myGameManagerData;

		//�@�L�����N�^�[�̐e�̃{�[��
		[SerializeField]
		private Transform parentCharacter;
		//�@�^�C���̐e�̃{�[��
		[SerializeField]
		private Transform parentTire;
		//�@�{�f�B�̐e�̃{�[��
		[SerializeField]
		private Transform parentBody;
		//�@�O���C�_�[�̐e�̃{�[��
		[SerializeField]
		private Transform parentKite;


		
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
		private GameObject character;
		//�@���ݑI�𒆂̃^�C��
		private GameObject tire;
		//�@���ݑI�𒆂̃{�f�B
		private GameObject body;
		//�@���ݑI�𒆂̃O���C�_�[
		private GameObject kite;

		//�@���݂̃^�C���ԍ�
		private int tireCount;
		//�@���݂̃{�f�B�ԍ�
		private int bodyCount;
		//�@���݂̃O���C�_�[�ԍ�
		private int kiteCount;

		//�O���C�_�[�p
		[SerializeField]
		private List<CapsuleCollider> capsuleColliders;

		//myGamemanager����L�����N�^�[���擾�o���Ȃ������ꍇ(�f�o�b�O�p)
		public GameObject prefabCharacter;

		void Start()
		{
			myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();

			tireCount = 0;
			bodyCount = 0;

			//�@�ŏ��͉����I�����Ȃ�
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
				//Debug.Log("tire�J�E���g:" + tireCount);
				//Debug.Log("tire�Q�[���I�u�W�F�N�g:" + tire);
				//Debug.Log("tire���X�g:" + TiresList);
			}
			else if (Input.GetKeyDown("3"))
			{
				kite.SetActive(true);
				ChangeKite();
			}
			
		}

		//�쐬����Player�̏���myGameManager�ɓ����
		public void OnCompleteCharacter(GameObject player)
        {
			kite.SetActive(false);
			//scene�J�ڂ��Ă��j������Ȃ��悤�ɂ���
			DontDestroyOnLoad(player);
			myGameManagerData.SetCharacter(player);
        }

        //�@�L�����N�^�[�ύX�֐�
        void ChangeCharacter()
        {
            //�@�L�����N�^�[���ݒ肳��Ă��鎞
            if (myGameManagerData.GetCharacter() != null)
            {
                Debug.Log("myGameManagerData.GetCharacter().gameObject!=null");

                var equipInfo = myGameManagerData.GetCharacter().GetComponent<EquipInformation>();
                //�@�L�����N�^�[�̔ԍ��Ńv���n�u���C���X�^���X��
                character = Instantiate<GameObject>(myGameManagerData.GetCharacter());
                //�@parentArmor��e�v�f�ɐݒ�
                character.transform.SetParent(parentCharacter);
                //�@�L�����N�^�[�̈ʒu�E��]�E�傫���̐ݒ���s��
                character.transform.localPosition = equipInfo.GetPosition();
                character.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
                character.transform.localScale = equipInfo.GetScale();


            }
            else
            {
                Debug.Log("myGameManagerData.GetCharacter().gameObject==null");
                //myGamemanager����L�����N�^�[���擾�o���Ȃ������ꍇ
                myGameManagerData.SetCharacter(prefabCharacter);

                var equipInfo = myGameManagerData.GetCharacter().GetComponent<EquipInformation>();
                //�@�L�����N�^�[�̔ԍ��Ńv���n�u���C���X�^���X��
                character = Instantiate<GameObject>(myGameManagerData.GetCharacter());
                //�@parentArmor��e�v�f�ɐݒ�
                character.transform.SetParent(parentCharacter);
                //�@�L�����N�^�[�̈ʒu�E��]�E�傫���̐ݒ���s��
                character.transform.localPosition = equipInfo.GetPosition();
                character.transform.localRotation = Quaternion.Euler(equipInfo.GetRotation());
                character.transform.localScale = equipInfo.GetScale();
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
}