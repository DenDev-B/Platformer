using MyPlatformer.com;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.map
{
    public class MapGenerator : MonoBehaviour
    {
        private int chankId = 0;
        public int positionX = 0;
        public int cameraLeftPosition = 0;
        public Block startBlock;
        public List<Block> bloks = new List<Block>();
        public List<Chunk> chanks = new List<Chunk>();
        private Transform parentTransdorm;
        public void createMap()
        {
            Block block = null;
            parentTransdorm = GetComponentInParent<Transform>();
            if (chankId == 0)
            {
                block = startBlock;
            }
            else
            {
                var k = UnityEngine.Random.Range(0, bloks.Count);
                block = bloks[k];
            }

            Chunk chank = new Chunk();
            chank.createChunk(chankId, block, ref positionX, parentTransdorm);
            chanks.Add(chank);
            chankId++;
            cameraLeftPosition = chanks[0].startPositionX;
        }

        public void createChank()
        {
            createMap();
            if (chanks.Count == 3)
            {
                chanks[0].Remove();
                chanks.Remove(chanks[0]);
                cameraLeftPosition = chanks[0].startPositionX;

            }

        }
        public void RemoveMap()
        {
            while (chanks.Count>0)
            {
                chanks[0].Remove();
                chanks.Remove(chanks[0]);
            }
        }
    }

} 
