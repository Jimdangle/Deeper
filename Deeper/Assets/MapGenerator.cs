using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] TextAsset map;

    [SerializeField] GameObject WALL;
    [SerializeField] GameObject FLOOR;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] float spawnOffset;

    // Start is called before the first frame update
    void Start()
    {
        string[] strMap;
        

        strMap = map.text.Split('\n');
        //Debug.Log(strMap);
        for (int i = 0; i < strMap.Length; i++)
        {
            Debug.Log(strMap[i]);
        }

        buildMap(strMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buildMap(string[] stringMap)
    {
        int yHeight = 0;
        foreach(string line in stringMap)
        {
            yHeight--;
            char[] lineMap = line.ToCharArray();
            //Debug.Log(transform.position.y + yHeight);
            for(int i=0; i<lineMap.Length; i++)
            {
                switch (lineMap[i])
                {
                    case '#':
                        break;
                    case '.':
                        break;
                    case '|':
                        placeMapItem(WALL, yHeight, i);
                        break;
                    case '_':
                        placeMapItem(FLOOR, yHeight, i);
                        break;
                    case 'x':
                        placeMapItem(SpawnPoint, yHeight, i);
                        break;

                }
            }
        }

    }

    void placeMapItem(GameObject obj,int y, int z)
    {
        Vector3 spawnPosition = new Vector3(0, (y * spawnOffset) + transform.position.y, (z * spawnOffset) +transform.position.z);
        GameObject temp = Instantiate(obj, spawnPosition, Quaternion.identity);
        
        
        temp.transform.parent = transform;
    }
}
