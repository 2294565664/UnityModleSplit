using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SplictTest : MonoBehaviour
{
    public Transform moble;

    private Transform[] modle_childs;

    private int scope;

    private float doMoveDuration;
    private Dictionary<Transform, Vector3> InitChildsPos;

    void Start()
    {
        if(moble == null)
        {
            moble = GameObject.Find("moble").transform;
        }
        modle_childs = moble.GetComponentsInChildren<Transform>();
        InitChildsPos= new Dictionary<Transform, Vector3>();
        foreach (var item in modle_childs)
        {
            InitChildsPos.Add(item.transform, item.position);
        }
        doMoveDuration = 3f;
        scope = 3;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "Split"))
        {
            SplitObject();
        }
        if (GUI.Button(new Rect(0, 70, 100, 50), "Merge"))
        {
            MergeObject();
        }
    }

    /// <summary>
    /// 拉伸
    /// </summary>
    public void SplitObject()
    {
        foreach (var item in modle_childs)
        {
            Vector3 tempV3 = GetSplitObjectPos(moble, item,scope);
            item.transform.DOMove(tempV3, doMoveDuration, false);
        }
    }

    /// <summary>
    /// 缩小
    /// </summary>
    public void MergeObject()
    {
        foreach (var item in modle_childs)
        {
            Vector3 tempV3 = GetMergeObjectPos(item);
            item.transform.DOMove(tempV3, doMoveDuration, false);
        }
    }

    /// <summary>
    /// 获取拉伸位置
    /// </summary>
    /// <param name="m_ParObj">根物体</param>
    /// <param name="_TargetObj">子物体</param>
    /// <param name="_scope">拉伸幅度</param>
    /// <returns></returns>
    private Vector3 GetSplitObjectPos(Transform m_ParObj, Transform _TargetObj,int _scope)
    {
        Vector3 tempV3;
        tempV3.x = (_TargetObj.position.x - m_ParObj.position.x) * _scope;
        tempV3.y = (_TargetObj.position.y - m_ParObj.position.y) * _scope;
        tempV3.z = (_TargetObj.position.z - m_ParObj.position.z) * _scope;
        return tempV3;
    }

    /// <summary>
    /// 获取缩小位置
    /// </summary>
    /// <param name="m_ParObj">根物体</param>
    /// <param name="_TargetObj">子物体</param>
    /// <param name="_scope">拉伸幅度</param>
    /// <returns></returns>
    private Vector3 GetMergeObjectPos(Transform m_ParObj, Transform _TargetObj,int _scope)
    {
        Vector3 tempV3;
        tempV3.x = (_TargetObj.position.x - m_ParObj.position.x) / _scope;
        tempV3.y = (_TargetObj.position.y - m_ParObj.position.y) / _scope;
        tempV3.z = (_TargetObj.position.z - m_ParObj.position.z) / _scope;
        return tempV3;
    }

    /// <summary>
    /// 获取初始位置
    /// </summary>
    /// <param name="_TargetObj">子物体</param>
    /// <returns></returns>
    private Vector3 GetMergeObjectPos(Transform _TargetObj)
    {
        return InitChildsPos.ContainsKey(_TargetObj)? InitChildsPos[_TargetObj]:Vector3.zero;
    }
}
