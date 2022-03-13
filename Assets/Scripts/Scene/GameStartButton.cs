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
            //@MyGameManagerData‚É•Û‘¶‚³‚ê‚Ä‚¢‚éŸ‚ÌƒV[ƒ“‚ÉˆÚ“®‚·‚é
            sceneTransition.NextSceneStart(stage);
        }
    }
}