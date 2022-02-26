using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectData
{
    public class RaceStart : MonoBehaviour
    {
        private MyGameManagerData myGameManagerData;

        private void Start()
        {
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();

            //‚±‚±‚ğ¶¬‚©‚çŒÄ‚Ño‚µ‚É•Ï‚¦‚é
            Instantiate(myGameManagerData.GetCharacter(), Vector3.zero, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}