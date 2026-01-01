// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2026/01/01 21:43
// @version: 1.0
// @description:
// *****************************************************************************

using Architects;
using QFramework;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace ViewControllers
{
    public class CardViewController : MonoBehaviour, IController
    {
        [SerializeField] [LabelText("卡片标题")] private TMP_Text title;
        [SerializeField] [LabelText("卡片描述")] private TMP_Text description;
        [SerializeField] [LabelText("卡片法力值")] private TMP_Text mana;
        [SerializeField] private SpriteRenderer imageSR;
        [SerializeField] private GameObject wrapper;
        
        public IArchitecture GetArchitecture()
        {
            return CardApp.Interface;
        }
    }
}
