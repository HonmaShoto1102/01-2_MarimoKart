using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateEnemy : MonoBehaviour
{

    //�쐬����G�l�~�[�̐�
    [SerializeField]
    public int EnemyCount;
    //�쐬����G�l�~�[�̌�
    [SerializeField]
    public GameObject EnemyPrefabs;

    //�@�G�l�~�[�̍쐬�ナ�X�g
    private List<GameObject> EnemyList;
    //�G�l�~�[��prefab�o���K�w
    private List<GameObject> enemyKartModel;
    //�G�l�~�[�̐e�I�u�W�F�N�g
    private List<Transform> parentObject;

    //prefab�̃��X�g
    //�@�L�����N�^�[�̃Q�[���I�u�W�F�N�g�z��
    public List<GameObject> CharacterList;
    //�@�{�f�B�̃Q�[���I�u�W�F�N�g�z��
    public List<GameObject> BodyList;
    //�@�^�C���̃Q�[���I�u�W�F�N�g�z��
    public List<GameObject> TireList;
    //�@�O���C�_�[�̃Q�[���I�u�W�F�N�g�z��
    public List<GameObject> KiteList;

    //�@���݂̃^�C���ԍ�
    private int characterCount;
    //�@���݂̃{�f�B�ԍ�
    private int bodyCount;
    //�@���݂̃^�C���ԍ�
    private int tireCount;
    //�@���݂̃O���C�_�[�ԍ�
    private int kiteCount;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            //prefab��EnemyCount�̐��܂Ő���
            EnemyList[i]=Instantiate(EnemyPrefabs, Vector3.zero, Quaternion.identity);
            //EnemyList[i]�̎q����KartModel�̃Q�[���I�u�W�F�N�g��T��
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
