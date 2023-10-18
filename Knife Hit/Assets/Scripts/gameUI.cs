using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;
    [Header("knife Count Display")]
    [SerializeField]
    private GameObject panelKnives;
    [SerializeField]
    private  GameObject iconKnife;
    [SerializeField]
    private Color iconcolor;

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

   public void KnifeCount(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(iconKnife, panelKnives.transform);

        }
    }
    private int knifeIconIndex = 0;
    public void DecrementKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndex++).GetComponent<Image>().color = iconcolor;
    }
}
