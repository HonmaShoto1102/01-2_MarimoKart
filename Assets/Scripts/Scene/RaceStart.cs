using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectData.Manager.Scene
{
    public class RaceStart : MonoBehaviour
    {
        //PlayerとEnemyのスタート位置
        [SerializeField]
        public List<GameObject> StartPositionsList;

        //Player
        private GameObject player;
        //Playerに付いているカメラ
        private GameObject playerCamera;
        //Playerの子のKart
        private GameObject kart;

        //Enemy
        public GameObject enemy;

 


        private MyGameManagerData myGameManagerData;

        private void Start()
        {
            {//Raceに必要なオブジェクトをONにしていく
                myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
                player = GameObject.FindGameObjectWithTag("Player");
                playerCamera = player.transform.Find("PlayerCamera").gameObject;
                playerCamera.SetActive(true);
                kart = player.transform.Find("Kart").gameObject;
                kart.GetComponent<SelectData.Manager.Player.KartController>().enabled = true;
            }

            {//Playerの出現位置
                int cnt = Random.RandomRange(0, StartPositionsList.Count);
                player.transform.position = StartPositionsList[cnt].transform.position;
                Debug.Log("cnt:" + cnt);
               
                //Enemyの出現位置

                for (int i = 0; i < StartPositionsList.Count; i++)
                {
                    if (cnt != i)
                    enemy.transform.position= StartPositionsList[i].transform.position;
                }
            }

            //ここを生成から呼び出しに変える
            //Instantiate(myGameManagerData.GetKart(), Vector3.zero, Quaternion.identity);
        }

    }
}