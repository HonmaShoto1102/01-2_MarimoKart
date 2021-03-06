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
            //　MyGameManagerDataに保存されている次のシーンに移動する
            sceneTransition.NextSceneStart(stage);
        }
    }
}