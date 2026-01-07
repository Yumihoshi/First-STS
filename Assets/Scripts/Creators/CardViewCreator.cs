// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2026/01/07 12:30
// @version: 1.0
// @description:
// *****************************************************************************

using DG.Tweening;
using QFramework;
using UnityEngine;

namespace Creators
{
    public class CardViewCreator : MonoSingleton<CardViewCreator>
    {
        [SerializeField] private CardView cardViewPrefab;

        public CardView CreateCardView(Vector3 position, Quaternion rotation)
        {
            CardView cardView = Instantiate(cardViewPrefab, position, rotation);
            cardView.transform.localScale = Vector3.zero;
            cardView.transform.DOScale(Vector3.one, 0.15f);
            return cardView;
        }
    }
}
