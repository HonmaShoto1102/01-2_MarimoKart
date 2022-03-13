using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectData.Manager.Scene
{
    public class GameStartButton : MonoBehaviour
    {
        private SceneTransition sceneTransition;

        private void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();

        }

        public void OnGameStart(string stage)
        {
            //�@MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
            sceneTransition.NextSceneStart(stage);
        }
    }
}