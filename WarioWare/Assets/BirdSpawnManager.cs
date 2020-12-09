using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrapioWare
{
    namespace Climb
    {
        public class BirdSpawnManager : MonoBehaviour
        {

            //GameObject with Children.
            [Header("OiseauManager")]
            public List<GameObject> OiseauGenerator1 = new List<GameObject>();
            public List<GameObject>  OiseauStoredPoints1 = new List<GameObject>();
            public List<GameObject> OiseauGenerator2 = new List<GameObject>();
            public List<GameObject> OiseauStoredPoints2 = new List<GameObject>();
            public List<GameObject> OiseauGenerator3 = new List<GameObject>();
            public List<GameObject> OiseauStoredPoints3 = new List<GameObject>();
            //Number of spawner available.
            [SerializeField] private int numberOfSpawner1 = 0;
            private int failed1 = 0;
            [SerializeField] private int numberOfSpawner2 = 0;
            [SerializeField] private int numberOfSpawner3 = 0;


            [Header("Difficulty")]
            public int numberOfMaxGenerator;

            // Start is called before the first frame update
            void Start()
            {
                SetDifficultyAlt();
            }

            void InitialisationGenerator1()
            {
                if(numberOfSpawner1 != numberOfMaxGenerator)
                {
                    int random1 = Random.Range(0, OiseauGenerator1.Count);

                    OiseauStoredPoints1.Add(OiseauGenerator1[random1]);
                    OiseauGenerator1.Remove(OiseauGenerator1[random1]);
                    numberOfSpawner1++;
                    InitialisationGenerator1();
                }
            }

            void InitialisationGenerator2()
            {
                if (numberOfSpawner2 != numberOfMaxGenerator)
                {
                    int random2 = Random.Range(0, OiseauGenerator2.Count);

                    OiseauStoredPoints2.Add(OiseauGenerator2[random2]);
                    OiseauGenerator2.Remove(OiseauGenerator2[random2]);
                    numberOfSpawner2++;
                    InitialisationGenerator2();
                }

            }

            void InitialisationGenerator3()
            {
                if (numberOfSpawner3 != numberOfMaxGenerator)
                {
                    int random3 = Random.Range(0, OiseauGenerator3.Count);

                    OiseauStoredPoints3.Add(OiseauGenerator3[random3]);
                    OiseauGenerator3.Remove(OiseauGenerator3[random3]);
                    numberOfSpawner3++;
                    InitialisationGenerator3();
                }

            }

            void SetDifficultyAlt()
            {
                numberOfMaxGenerator = Random.Range(2, 5);
                InitialisationGenerator1();
                InitialisationGenerator2();
                InitialisationGenerator3();
            }


            void SetDifficulty()
            {
                //NumberOfMaxGenerator according difficulty
                switch (ClimbGameManager.Instance.difficulty)
                {
                    case 0:
                        numberOfMaxGenerator = 2;
                        InitialisationGenerator1();
                        InitialisationGenerator2();
                        InitialisationGenerator3();
                        break;
                    case 1:
                        numberOfMaxGenerator = 3;
                        InitialisationGenerator1();
                        InitialisationGenerator2();
                        InitialisationGenerator3();
                        break;
                    case 2:
                        numberOfMaxGenerator = 4;
                        InitialisationGenerator1();
                        InitialisationGenerator2();
                        InitialisationGenerator3();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
