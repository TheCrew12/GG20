using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIButtons : MonoBehaviour
    {
        public Button makeAMonster;
        public Button resetMonsters;
        public Button spawnBurger;

        public GameObject BurgerObject;
        public GameObject MonsterMakerUI;
        
        private void Start() 
        {
            makeAMonster.onClick.AddListener(MakeAMonster);
            resetMonsters.onClick.AddListener(ResetMonsters);
            spawnBurger.onClick.AddListener(SpawnBurger);
            
            MakeAMonster(); //Open the UI at startup
        }

        private void MakeAMonster()
        {
            MonsterMakerUI.SetActive(true);
        }
        
        private void ResetMonsters()
        {
            var monsters = GameObject.FindGameObjectsWithTag("Monster");
            
            foreach (GameObject monster in monsters)
            {
                monster.GetComponent<MonsterScript>().Burn();
            }
        }
        
        private void SpawnBurger() 
        {
            var cameraPos = Camera.main.transform.position; //Puts burger in center of screen
            cameraPos.z = 0;
            Instantiate(BurgerObject, cameraPos, new Quaternion());
        }
    }
}