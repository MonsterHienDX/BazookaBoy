using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollComponent : MonoBehaviour
{
    [SerializeField] private HingeJoint2D[] joint2DList;
    [SerializeField] private Rigidbody2D mainBodyRb2D;
    private List<Vector3> startPosList;
    private List<Vector3> startRotList;

    private Vector3 bodyStartPos;
    private Vector3 bodyStartRot;

    private int partAmount;

    private void Awake()
    {
        this.partAmount = joint2DList.Length;
    }

    private void Start()
    {
        startPosList = new List<Vector3>();
        startRotList = new List<Vector3>();
        Init();
        EnableRagdollState(true);
    }

    public void Init()
    {
        bodyStartPos = mainBodyRb2D.transform.position;
        bodyStartRot = mainBodyRb2D.transform.localEulerAngles;
        foreach (HingeJoint2D joint2D in joint2DList)
        {
            startPosList.Add(joint2D.transform.position);
            startRotList.Add(joint2D.transform.localEulerAngles);
        }
    }

    public void EnableRagdollState(bool enable)
    {
        foreach (HingeJoint2D joint2D in joint2DList)
        {
            joint2D.attachedRigidbody.bodyType = (enable) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
        }
    }

    public void ResetState()
    {
        mainBodyRb2D.transform.position = bodyStartPos;
        mainBodyRb2D.transform.localEulerAngles = bodyStartRot;
        mainBodyRb2D.velocity = Vector2.zero;

        for (int i = 0; i < partAmount; i++)
        {
            joint2DList[i].transform.position = startPosList[i];
            joint2DList[i].transform.localEulerAngles = startRotList[i];
        }
    }
}
