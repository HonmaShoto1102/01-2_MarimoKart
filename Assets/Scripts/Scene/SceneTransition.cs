using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectData.Manager.Scene
{
    public class SceneTransition : MonoBehaviour
    {
        private MyGameManagerData myGameManagerData;

        private void Start()
        {
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        
        public void NextSceneStart(string stage)
        {
            //�@���̃V�[���f�[�^��MyGameManager�ɕۑ�
            myGameManagerData.SetNextSceneName(stage);
            //�@MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}

