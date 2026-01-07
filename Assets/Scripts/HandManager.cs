using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using QFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Splines;

public class HandManager : MonoBehaviour
{
    [SerializeField] [LabelText("最大手持卡牌数")] private int maxHandSize;
    [SerializeField] [LabelText("卡牌预制体")] private GameObject cardPrefab;
    [SerializeField] [LabelText("样条曲线")] private SplineContainer splineContainer;
    [SerializeField] [LabelText("卡牌生成点")] private Transform spawnPoint;

    private List<GameObject> _handCards = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) DrawCard();
    }

    private void DrawCard()
    {
        if (_handCards.Count >= maxHandSize) return;
        GameObject g = Instantiate(cardPrefab, spawnPoint.position, spawnPoint.rotation);
        _handCards.Add(g);
        UpdateCardPositions();
    }

    private void UpdateCardPositions()
    {
        if (_handCards.Count == 0) return;
        float cardSpacing = 1f / maxHandSize;
        float firstCardPosition = 0.5f - (_handCards.Count - 1) * cardSpacing / 2f;
        Spline spline = splineContainer.Spline;
        for (int i = 0; i < _handCards.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            _handCards[i].transform.DOMove(splinePosition, 0.25f);
            _handCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }
    }
}
