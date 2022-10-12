using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    private List<Ground> groundList;
    [SerializeField] private Sprite _surfaceSprite;
    [SerializeField] private Sprite _solidSoilSprite;
    [SerializeField] private Vector2 _groundSize;
    [SerializeField] private Ground groundPrefab;
    private void Awake()
    {
        groundList = new List<Ground>();
    }

    private void Start()
    {
        SpawnGround(_groundSize);
    }

    public void SpawnGround(Vector2 size)
    {
        Vector3 cachedPos = Vector3.zero;
        Sprite cachedSprite = _surfaceSprite;
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                cachedPos.Set((x - size.x / 2) * 1.28f, y * 1.28f, 0);
                cachedSprite = (y < size.y - 1) ? _solidSoilSprite : _surfaceSprite;
                groundList.Add(CreateGround(cachedPos, cachedSprite));
            }
        }
    }

    private Ground CreateGround(Vector3 pos, Sprite sprite)
    {
        Ground childObject = Instantiate<Ground>(groundPrefab, this.transform);
        Debug.Log("Ground pos: " + pos);
        childObject.name = "Ground";
        childObject.tag = "DestructibleObjects";
        childObject.transform.localPosition = pos;
        childObject.SetTileSprite(sprite);

        return childObject;
    }
}