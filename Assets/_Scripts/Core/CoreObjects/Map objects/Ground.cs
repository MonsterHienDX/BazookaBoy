using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Ground : DestructiblePlatform
{
    [field: SerializeField] public Sprite spriteShape { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        this._rb2D.bodyType = RigidbodyType2D.Dynamic;
    }

    protected override void OnValidate()
    {
        // base.OnValidate();
        SetShape(spriteShape);
    }

    public override void Init(Vector3 pos, Vector3 groundCenterPos)
    {
        this.name = "Ground";
        this.tag = "DestructibleObjects";
        this.transform.localPosition = pos;
        this._startPos = pos;
        this._startRot = this.transform.localEulerAngles;
        this._instanceIDInit = GetInstanceID();
        this._rb2D.bodyType = RigidbodyType2D.Static;
    }

    public void SetShape(Sprite spriteShape)
    {
        Debug.Log($"{this.name}._spriteRenderer.enabled: " + (this._spriteRenderer.enabled));
        this.SetSprite(spriteShape);
        this._destructibleSprite.Shape = spriteShape;

        this._destructibleSprite.Clear();

        this._destructibleSprite.Rebuild();

        this._destructibleSprite.Trim();

        OptimizeWhenInitShape(2);

        this.spriteShape = spriteShape;
    }

    private void OptimizeWhenInitShape(int optimizeCount)
    {
        for (int i = 0; i < optimizeCount; i++)
            this._destructibleSprite.Optimize();
    }
}
