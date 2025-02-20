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

    public GameObject choiceButtons;

    void Start()
    {
        if (scriptText == null)
        {
            Debug.LogError("Script Text is Missing!");
            return;
        }
        // set guide texts
        guideTexts.Add("����? Flappy Knight�� �÷����Ϸ���? ( ��� )");
        guideTexts.Add("����! ������ �����ϴ� �� ���� ��.\n�״��� ���� �� �ƴ϶� ���̾�. ( ��� )");
        guideTexts.Add("������ �ǰ�? ����!");

        Init();
    }

    private void Init()
    {
        textNum = (int)TextOrder.Text0;
        scriptText.text = guideTexts[textNum];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ShowNextText();
    }

    private void ShowNextText()
    {
        if (textNum < guideTexts.Count - 2)
        {
            textNum++;
            scriptText.text = guideTexts[textNum];
        }
        else
        {
            ShowLastText();
        }
    }    
    private void ShowLastText()
    {
        choiceButtons.SetActive(true);
        scriptText.text = guideTexts[(int)TextOrder.Text2];
    }

    public void InitializeTextNum()
    {
        textNum = 0;
        scriptText.text = guideTexts[textNum];
    }

    public void YesText()
    {
        choiceButtons.SetActive(false);
        scriptText.text = "����! ���� ����� ����� �����!";
        // if (Input.GetKeyDown(KeyCode.Space)) 
        SceneManager.LoadScene((int)Scenes.FlappyGameScene);
    }
    public void NoText()
    {
        choiceButtons.SetActive(false);
        scriptText.text = "��Ÿ����. �ڳ׶�� �� �� ���� �� ���Ҵµ�.";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.ShowFlappyGuideScripts(false);
        }
    }
}