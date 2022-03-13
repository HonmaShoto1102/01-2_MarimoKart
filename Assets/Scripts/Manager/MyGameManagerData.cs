using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectData.Manager
{
    [CreateAssetMenu(fileName = "MyGameManagerData", menuName = "MyGameManagerData")]
    public class MyGameManagerData : ScriptableObject
    {
        //　次のシーン名
        [SerializeField]
        private string nextSceneName;
        //　使用するキャラクタープレハブ
        [SerializeField]
        private GameObject character;
        //　使用するカートのパーツ番号
        [SerializeField]
        private int tireNumber;
        [SerializeField]
        private int bodyNumber;
        [SerializeField]
        private int kiteNumber;

        //　データの初期化
        private void OnEnable()
        {
            //　タイトルシーンの時だけリセット
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
