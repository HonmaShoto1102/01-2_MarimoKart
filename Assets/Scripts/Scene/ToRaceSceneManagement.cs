using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRaceSceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        // �C�x���g�ɓo�^
        SceneManager.sceneLoaded += GameSceneLoaded;

        // �V�[���؂�ւ�
        SceneManager.LoadScene("RaceScene");
    }
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // �V�[���؂�ւ���̃X�N���v�g���擾
        //var gameManager = GameObject.FindWithTag("Player").GetComponent<KartController>();

        // �f�[�^��n������
        //gameManager.gameObject=

        // �C�x���g����폜
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
