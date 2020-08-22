using System.Collections.Generic;
using UnityEngine;

public class GlobalSpawnBlocks : MonoBehaviour
{
    // blocks
    public List<IceBlockObject> blocks = new List<IceBlockObject>();
    public int min_tick_blocks = 0;
    public int max_tick_blocks = 4;

    // Percent active block
    public int percent_down = 10;

    private bool isGenerated = false;
    public bool rebakeNavMesh = false;

    public int repeatTime = 1;
    public int recoveryTime = 5;

    public void AddCube(IceBlockObject obj)
    {
        blocks.Add(obj);
        obj.recoveryTime = recoveryTime;
    }

    public void RemoveCube(IceBlockObject obj)
    {
        blocks.Remove(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("tick", repeatTime, repeatTime);
        isGenerated = true;
    }

    public void generateBlocks()
    {
        int N = Random.Range(min_tick_blocks, max_tick_blocks);
        for (int i = 0; i < N; i++)
        {
            int j = Random.Range(0, blocks.Count);
            IceBlockObject targetBlock = blocks[j];
            double r = Random.value;
            double chance = 1 - (percent_down / 100);

            // loh
            if (r <= chance)
            {
                List<IceBlockObject> list = GetConnectedBlocksInRadius(targetBlock, 30);
                if (list.Count > 1)
                {
                    if (!targetBlock.isDown)
                    {
                        targetBlock.startDamage = true;
                    }
                }
            }


            // Проверьте одиночные блоки
            for (int k = 0; k < blocks.Count; k++)
            {
                targetBlock = blocks[k];
                List<IceBlockObject> list = GetConnectedBlocksInRadius(targetBlock, 30);
                if (list.Count == 0)
                {
                    //targetBlock.checkerSwim(false);
                    //targetBlock.unityObject.SetActive(false);
                }
            }
        }
    }

    void tick()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (!gm.isPaused) // Если игра не на паузе, то делай то, что делал...
        {
            generateBlocks();
            if (rebakeNavMesh)
            {
                GameObject navMeshBaker = GameObject.Find("NavMeshBaker");
                Baker baker = navMeshBaker.GetComponent<Baker>();
                baker.UpdateNavMesh();
            }
        }
    }

    List<IceBlockObject> GetConnectedBlocksInRadius(IceBlockObject obj, float rangeSqr)
    {
        List<IceBlockObject> list = new List<IceBlockObject>();
        foreach (IceBlockObject ibo in blocks)
        {
            float distanceSqr = (obj.unityObject.transform.position - ibo.unityObject.transform.position).sqrMagnitude;
            if ((distanceSqr > 0) && (distanceSqr < rangeSqr))
            {
                if (!ibo.isDown)
                {
                    list.Add(ibo);
                }
            }
        }
        return list;
    }
}
