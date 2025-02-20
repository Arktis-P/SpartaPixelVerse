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
        guideTexts.Add("뭐야? Flappy Knight를 플레이하려고?");
        guideTexts.Add("좋지! 하지만 조심하는 게 좋을 걸.\n그다지 쉬운 건 아니라서 말이야.");
        guideTexts.Add("도전할 건가? 허헛!");

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
        scriptText.text = "좋아! 가서 기록을 세우고 오라고!";
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(1);
    }
    private void NoText()
    {
        scriptText.text = "안타깝군. 자네라면 할 수 있을 것 같았는데.";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.ShowFlappyGuideScripts(false);
        }
    }
}