// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2026/01/07 11:54
// @version: 1.0
// @description:
// *****************************************************************************

using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] [LabelText("卡片标题")] private TMP_Text title;
    [SerializeField] [LabelText("卡片描述")] private TMP_Text description;
    [SerializeField] [LabelText("卡片法力值")] private TMP_Text mana;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;
}
