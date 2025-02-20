using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum TextOrder
{
    Text0, Text1, Text2
}

public class FlappyGuideScript : MonoBehaviour
{
    public Text scriptText;
    private List<string> guideTexts = new List<string>();

    private int textNum;
    private bool isYes;

    void Start()
    {
        if (scriptText == null)
        {
            Debug.LogError("Script Text is Missing!");
            return;
        }
        // set guide texts
        guideTexts.Add("����? Flappy Knight�� �÷����Ϸ���?");
        guideTexts.Add("����! ������ �����ϴ� �� ���� ��.\n�״��� ���� �� �ƴ϶� ���̾�.");
        guideTexts.Add("������ �ǰ�? ����!");

        textNum = (int)TextOrder.Text0;
        scriptText.text = guideTexts[textNum];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textNum++;
            if (textNum < guideTexts.Count - 1) scriptText.text = guideTexts[textNum];
            else
            {
                scriptText.text = guideTexts[(int)TextOrder.Text2];
                if (Input.GetKeyDown(KeyCode.Space)) YesText();
                else if (Input.GetKeyDown(KeyCode.N)) NoText();
            }
        }
    }

    public void initializeTextNum()
    {
        textNum = -1;
    }

    private void YesText()
    {
        scriptText.text = "����! ���� ����� ����� �����!";
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(1);
    }
    private void NoText()
    {
        scriptText.text = "��Ÿ����. �ڳ׶�� �� �� ���� �� ���Ҵµ�.";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.ShowFlappyGuideScripts(false);
        }
    }
}