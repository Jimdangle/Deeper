using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] TextAsset map;
    [SerializeField] float spawnOffset;

    [SerializeField] GameObject Block;
    [SerializeField] GameObject LightFab;

    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject EndPoint;

    [SerializeField] GameObject Slider;
    

    

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
        float width = 0;
        foreach(string line in stringMap)
        {
            yHeight--;
            char[] lineMap = line.ToCharArray();
            //Debug.Log(transform.position.y + yHeight);
            for(int i=0; i<lineMap.Length; i++)
            {
                width++;
                switch (lineMap[i])
                {
                    //empty
                    case '#':
                        break;
                    case '.':
                        break;

                    //Block
                    case '$':
                        placeMapItem(Block, yHeight, i);
                        break;

                    // spawn point
                    case 'x':
                        placeMapItem(SpawnPoint, yHeight, i);
                        break;
                    // end point
                    case 'e':
                        placeMapItem(EndPoint, yHeight, i);
                        break;

                    //Obstacles
                    case 's':
                        placeMapItem(Slider, yHeight, i);
                        break;

                    case '1':
                        placeLight(LightFab, yHeight, i,6,"g",0);
                        break;
                    case '2':
                        placeLight(LightFab, yHeight, i, 3, "r", 20);
                        break;
                    case '3':
                        placeLight(LightFab, yHeight, i, 8, "b", 4);
                        break;



                }
            }
        }

        width = width / Mathf.Abs(yHeight);
        yHeight = yHeight * -1;

        Vector3 middlePoint = new Vector3(-2, yHeight / 2, width / 2);
        GameObject backGround = Instantiate(Block, middlePoint, Quaternion.identity);
        backGround.transform.localScale= new Vector3(2, yHeight, width);

    }


    // places the given prefab at the x and y position given
    void placeMapItem(GameObject obj,int y, int z)
    {
        Vector3 spawnPosition = new Vector3(0, (y * spawnOffset) + transform.position.y, (z * spawnOffset) +transform.position.z);
        GameObject temp = Instantiate(obj, spawnPosition, Quaternion.identity);
        
        
        temp.transform.parent = transform;
    }


    // place a light with a ceiling floor or wall 
    void placeLight(GameObject obj, int y, int z,float brightness,string inColor,float time)
    {
        Vector3 spawnPosition = new Vector3(0, (y * spawnOffset) + transform.position.y, (z * spawnOffset) + transform.position.z);

        GameObject outObj = Instantiate(obj, spawnPosition, Quaternion.identity);
        Strobe strobe = outObj.GetComponent<Strobe>();

        Color outColor = new Color();
        switch (inColor)
        {
            case "g":
                outColor.r = 0;
                outColor.g = 255;
                outColor.b = 0;
                break;
            
            case "r":
                outColor.r = 255;
                outColor.g = 0;
                outColor.b = 0;
                break;

            case "b":
                outColor.r = 0;
                outColor.g = 0;
                outColor.b = 255;
                break;
            
            default:
                outColor.r = 255;
                outColor.g = 255;
                outColor.b = 255;
                break;
        }

        strobe.StrobeTime = time;
        strobe.intensityMax = brightness;
        strobe.color = outColor;
    }
}
