using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageM : MonoBehaviour
{
    // �X�e�[�W���擾����
    [SerializeField] private List<GameObject> stageList = new List<GameObject>();
    public GameObject obj;
    public GameObject obj2;

    public List<int> stage;
    void Start()
    {
        // �e�I�u�W�F�N�g
        Transform parentTransform = obj.transform;

        // 0�Ԗڂ̎q���擾 --- ����
        print(parentTransform.GetChild(0).name);


        //+++++++
        print("index:"+obj.transform.GetSiblingIndex());
        int tt = obj.transform.GetSiblingIndex();
        int ss = obj2.transform.GetSiblingIndex();


        int[] stage = { tt, ss, 2 };

        int[] stagell = new int[5];

        stagell[0] = ss;
        //+++++++
        print("---------------------------------------------------");

        // �q�����ׂĎ擾 --- ���ׂĂ����X�g�ɓ����
        foreach (Transform child in parentTransform)
        {
            stageList.Add(child.gameObject);
            print(child.name);
        }

        print("---------------------------------------------------");

        //// ���݂̃X�e�[�W�̔ԍ�
        //int nowStageNum = 0;
        //// ���X�g�̒��g --- ���łɈ�̃X�e�[�W��\�����Ă݂�
        //for (int i = 0; i < stageList.Count; i++)
        //{
        //    // �\������X�e�[�W --- �����͂O����A�X�e�[�W�͂P����n�܂�̂Œ��ӂ��K�v
        //    if (i == nowStageNum) stageList[i].SetActive(true);

        //    print(stageList[i].name);
            
        //}
       
    }
}
