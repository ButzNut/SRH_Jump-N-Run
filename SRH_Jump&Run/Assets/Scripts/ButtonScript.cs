using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject Text;

    public void TextButton()
    {
        Text.gameObject.SetActive(true);
    }

    public void HideText()
    {
        Text.gameObject.SetActive(false);
    }

}
