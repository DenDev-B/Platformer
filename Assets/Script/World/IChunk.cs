using UnityEngine;

public interface IChunk
{
    void createChunk(int _id, Block _block, ref int positionX, Transform parentTransform);
    void Remove();
}
