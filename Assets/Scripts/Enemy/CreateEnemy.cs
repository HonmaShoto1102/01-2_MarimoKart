using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateEnemy : MonoBehaviour
{

    //作成するエネミーの数
    [SerializeField]
    public int EnemyCount;
    //作成するエネミーの元
    [SerializeField]
    public GameObject EnemyPrefabs;

    //　エネミーの作成後リスト
    private List<GameObject> EnemyList;
    //エネミーのprefab出現階層
    private List<GameObject> enemyKartModel;
    //エネミーの親オブジェクト
    private List<Transform> parentObject;

    //prefabのリスト
    //　キャラクターのゲームオブジェクト配列
    public List<GameObject> CharacterList;
    //　ボディのゲームオブジェクト配列
    public List<GameObject> BodyList;
    //　タイヤのゲームオブジェクト配列
    public List<GameObject> TireList;
    //　グライダーのゲームオブジェクト配列
    public List<GameObject> KiteList;

    //　現在のタイヤ番号
    private int characterCount;
    //　現在のボディ番号
    private int bodyCount;
    //　現在のタイヤ番号
    private int tireCount;
    //　現在のグライダー番号
    private int kiteCount;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            //prefabをEnemyCountの数まで生成
            EnemyList[i]=Instantiate(EnemyPrefabs, Vector3.zero, Quaternion.identity);
            //EnemyList[i]の子からKartModelのゲームオブジェクトを探す
            parentObject[i] = EnemyList[i].transform.Find("KartModel").transform;

            var equipInfo = BodyList[bodyCount].GetComponent<EquipInformation>();

            int bodyCnt = Random.RandomRange(0, BodyList.Count);
            GameObject bodyObject = GameObject.Instantiate(BodyList[bodyCnt]);

            //enemyKartModel.transform.position = StartPositionsList[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
