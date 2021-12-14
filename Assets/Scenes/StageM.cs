using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageM : MonoBehaviour
{
    // ステージを取得する
    [SerializeField] private List<GameObject> stageList = new List<GameObject>();
    public GameObject obj;
    public GameObject obj2;

    public List<int> stage;
    void Start()
    {
        // 親オブジェクト
        Transform parentTransform = obj.transform;

        // 0番目の子を取得 --- 直接
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

        // 子をすべて取得 --- すべてをリストに入れる
        foreach (Transform child in parentTransform)
        {
            stageList.Add(child.gameObject);
            print(child.name);
        }

        print("---------------------------------------------------");

        //// 現在のステージの番号
        //int nowStageNum = 0;
        //// リストの中身 --- ついでに一つのステージを表示してみた
        //for (int i = 0; i < stageList.Count; i++)
        //{
        //    // 表示するステージ --- 数字は０から、ステージは１から始まるので注意が必要
        //    if (i == nowStageNum) stageList[i].SetActive(true);

        //    print(stageList[i].name);
            
        //}
       
    }
}
