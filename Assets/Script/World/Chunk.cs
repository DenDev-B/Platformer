using MyPlatformer.com;
using MyPlatformer.traps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.map
{
    public class Chunk : IChunk
    {
        private List<GameObject> _objs = new List<GameObject>();
        private List<GameObject> _traps = new List<GameObject>();
        private List<GameObject> _coins = new List<GameObject>();

        public int id = 0;
        private Block _block = null;
        public int startPositionX = 0;
        public float startPositionY = -1f;
        public void createChunk(int id, Block block, ref int positionX, Transform parentTransdorm)
        {
            this.id = id;
            _block = block;
            startPositionX = positionX;

            for (var i = 0; i < _block.map.Count; i++)
            {
                positionX = startPositionX;
                for (var j = 0; j < _block.map[i].line.Count; j++)
                {
                    if (startPositionY == -1)
                        startPositionY = i * 1f + 2;
                    Vector3 position = _block.prefabs[_block.map[i].line[j]].GetComponent<Transform>().position + new Vector3(positionX * 1f, i * 1f, 0f);

                    _objs.Add(ManagerPool.Instance.Spawn(PoolType.Box, _block.prefabs[_block.map[i].line[j]], position, _block.prefabs[_block.map[i].line[j]].GetComponent<Transform>().rotation, parentTransdorm));

                    positionX++;
                }
            }
            if (_block.traps.Count > 0)
            {
                for (var i = 0; i < _block.traps.Count; i++)
                {
                    Vector3 position = _block.traps[i].go.GetComponent<Transform>().position + new Vector3(startPositionX + _block.traps[i].x, _block.traps[i].y, 0f);
                    GameObject go = ManagerPool.Instance.Spawn(PoolType.Trap, _block.traps[i].go, position, _block.traps[i].go.GetComponent<Transform>().rotation, parentTransdorm);
                    _traps.Add(go);
                    go.GetComponent<Traps>().trap.OnGo();
                }
            }
            if (_block.coinsXY.Count > 0 && _block.prefab_coins !=null)
            {
                for (var i = 0; i < _block.coinsXY.Count; i++)
                {
                    if (_block.coinsXY[i].Random >= Random.Range(0, 100))
                    {
                        Vector3 position = _block.prefab_coins.GetComponent<Transform>().position + new Vector3(startPositionX + _block.coinsXY[i].x, _block.coinsXY[i].y, 0f);
                        GameObject go = ManagerPool.Instance.Spawn(PoolType.Ui, _block.prefab_coins, position, _block.prefab_coins.GetComponent<Transform>().rotation, parentTransdorm);
                        _coins.Add(go);
                        go.GetComponent<CoinsRotation>().StartRotation();
                        go.GetComponent<CoinsCollider>().chunk = this;
                    }
                }
            }
        }
        public void DellCoins(GameObject goCoins){

            ManagerPool.Instance.Despawn(PoolType.Ui, goCoins);
            _coins.Remove(goCoins);
        }

        public void Remove()
        {
            while (_objs.Count > 0)
            {
                ManagerPool.Instance.Despawn(PoolType.Box, _objs[_objs.Count - 1]);
                _objs.Remove(_objs[_objs.Count - 1]);
            }
            while (_traps.Count > 0)
            {
                ManagerPool.Instance.Despawn(PoolType.Trap, _traps[_traps.Count - 1]);
                _traps.Remove(_traps[_traps.Count - 1]);
            }
            while (_coins.Count > 0)
            {
                ManagerPool.Instance.Despawn(PoolType.Ui, _coins[_coins.Count - 1]);
                _coins.Remove(_coins[_coins.Count - 1]);
            }
        }
    }
}