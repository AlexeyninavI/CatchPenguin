using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_islands : MonoBehaviour
{
    //public GameObject island;
    //public List<GameObject> cubes = new List<GameObject>();

    //int weight = 4;
    //int hight = 4;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    for (int x = 0; x < weight; x++)
    //    {
    //        for (int y = 0; y < hight; y++)
    //        {
    //            GameObject ice = Instantiate(island, new Vector3(x * 4, 0, y * 4), Quaternion.identity);
    //            ice.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
    //            cubes.Add(ice);
    //        }
    //    }
    //}

    //int count = 10;
    //bool scaleUp;
    //// Update is called once per frame
    //void Update()
    //{
    //    count--;
    //    if(count == 0)
    //    {
    //        for (int i = 0; i < cubes.Count; i++)
    //        {
    //            var obj = cubes[i];
    //            Vector3 scale = obj.transform.localScale;
    //            if ((scale.x >= 1 && scale.y >= 1 && scale.z >= 1))
    //            {
    //                scaleUp = false;
    //            } else if (scale.x <= 0 && scale.y <= 0 && scale.z <= 0)
    //            {
    //                scaleUp = true;
    //            }

    //            if(scaleUp)
    //            {
    //                obj.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
    //            } else
    //            {
    //                obj.transform.localScale -= new Vector3(0.1F, 0.1F, 0.1F);
    //            }
    //        }
    //        count = 20;
    //    }
    //}
}
