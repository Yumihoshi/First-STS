// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2026/01/07 11:58
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Splines;

namespace Views
{
    public class HandView : MonoBehaviour
    {
        [SerializeField] [LabelText("样条曲线")] private SplineContainer splineContainer;
        private readonly List<CardView> _cards = new();

        public async UniTask AddCard(CardView cardView)
        {
            _cards.Add(cardView);
            await UpdateCardPositions(0.15f);
        }

        private async UniTask UpdateCardPositions(float duration)
        {
            if (_cards.Count == 0) return;
            float cardSpacing = 1f / 10f;
            float firstCardPosition = 0.5f - (_cards.Count - 1) * cardSpacing / 2f;
            Spline spline = splineContainer.Spline;
            for (int i = 0; i < _cards.Count; i++)
            {
                float p = firstCardPosition + i * cardSpacing;
                Vector3 splinePosition = spline.EvaluatePosition(p);
                Vector3 forward = spline.EvaluateTangent(p);
                Vector3 up = spline.EvaluateUpVector(p);
                Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up, forward).normalized);
                _cards[i].transform.DOMove(splinePosition + transform.position + 0.01f * i * Vector3.back, duration);
                _cards[i].transform.DORotate(rotation.eulerAngles, duration);
            }

            await UniTask.WaitForSeconds(duration);
        }
    }
}
