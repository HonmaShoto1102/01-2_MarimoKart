using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectData.Manager.Scene
{
    public class RaceStart : MonoBehaviour
    {
        //Player��Enemy�̃X�^�[�g�ʒu
        [SerializeField]
        public List<GameObject> StartPositionsList;

        //Player
        private GameObject player;
        //Player�ɕt���Ă���J����
        private GameObject playerCamera;
        //Player�̎q��Kart
        private GameObject kart;

        //Enemy
        public GameObject enemy;

 


        private MyGameManagerData myGameManagerData;

        private void Start()
        {
            {//Race�ɕK�v�ȃI�u�W�F�N�g��ON�ɂ��Ă���
                myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
                player = GameObject.FindGameObjectWithTag("Player");
                playerCamera = player.transform.Find("PlayerCamera").gameObject;
                playerCamera.SetActive(true);
                kart = player.transform.Find("Kart").gameObject;
                kart.GetComponent<SelectData.Manager.Player.KartController>().enabled = true;
            }

            {//Player�̏o���ʒu
                int cnt = Random.RandomRange(0, StartPositionsList.Count);
                player.transform.position = StartPositionsList[cnt].transform.position;
                Debug.Log("cnt:" + cnt);
               
                //Enemy�̏o���ʒu

                for (int i = 0; i < StartPositionsList.Count; i++)
                {
                    if (cnt != i)
                    enemy.transform.position= StartPositionsList[i].transform.position;
                }
            }

            //�����𐶐�����Ăяo���ɕς���
            //Instantiate(myGameManagerData.GetKart(), Vector3.zero, Quaternion.identity);
        }

    }
}