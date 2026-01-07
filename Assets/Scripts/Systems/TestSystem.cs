// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2026/01/07 12:35
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Creators;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Views;

namespace Systems
{
    public class TestSystem : MonoBehaviour
    {
        [SerializeField] private HandView handView;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CardView cardView = CardViewCreator.Instance.CreateCardView(transform.position, Quaternion.identity);
                handView.AddCard(cardView).Forget();
            }
        }
    }
}
