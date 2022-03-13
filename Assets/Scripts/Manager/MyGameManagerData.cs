using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectData.Manager
{
    [CreateAssetMenu(fileName = "MyGameManagerData", menuName = "MyGameManagerData")]
    public class MyGameManagerData : ScriptableObject
    {
        //�@���̃V�[����
        [SerializeField]
        private string nextSceneName;
        //�@�g�p����L�����N�^�[�v���n�u
        [SerializeField]
        private GameObject character;
        //�@�g�p����J�[�g�̃p�[�c�ԍ�
        [SerializeField]
        private int tireNumber;
        [SerializeField]
        private int bodyNumber;
        [SerializeField]
        private int kiteNumber;

        //�@�f�[�^�̏�����
        private void OnEnable()
        {
            //�@�^�C�g���V�[���̎��������Z�b�g
            if (SceneManager.GetActiveScene().name == "SelectCharacterTitle")
            {
                nextSceneName = "";
                character = null;
            }
        }

        public void SetNextSceneName(string nextSceneName)
        {
            this.nextSceneName = nextSceneName;
        }

        public string GetNextSceneName()
        {
            return nextSceneName;
        }

        public void SetCharacter(GameObject character)
        {
            this.character = character;
        }

        public GameObject GetCharacter()
        {
            return character;
        }

        public void SetTireNumber(int tireNumber)
        {
            this.tireNumber = tireNumber;
        }

        public int GetTireNumber()
        {
            return tireNumber;
        }
        public void SetBodyNumber(int bodyNumber)
        {
            this.bodyNumber = bodyNumber;
        }

        public int GetBodyNumber()
        {
            return bodyNumber;
        }

        public void SetKiteNumber(int kiteNumber)
        {
            this.kiteNumber = kiteNumber;
        }

        public int GetKiteNumber()
        {
            return kiteNumber;
        }

    }
}
