using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextContents
{
    public string Title;
    [TextArea]
    public string MainText;
    public Sprite MainImage;
    [TextArea]
    public string SubTitle;
    public GameObject UI;
    public AudioClip TextContentAudioclips;
    public GameObject Model;
    public GameObject Caption;
    public Animator ModelAnimator;
    public int ModelAnimatorPara;
}

public class GameManager : MonoBehaviour
{
    public GameObject IntroUI;
    public GameObject ClassUI;
    public GameObject PageChangeButtonUI;
    public GameObject RButton;
    public GameObject LButton;
    public GameObject PlayButtonUI;
    public GameObject PlayButton;
    public GameObject PauseButton;

    public Text TitleTextBox;
    public GameObject MainTextBox;
    public Text SubtileTextBox;
    public Text VersionText;

    public GameObject CreditsTextBox;
    public GameObject CopyrightsTextBox;

    public List<TextContents> textContents = new List<TextContents>();

    AudioSource AS;

    public GameObject DemoModel;
    public GameObject DemoCaption;
    public GameObject Player;

    private int TextContents = 0;
    public int Pages;

    // Start is called before the first frame update
    void Start()
    {
        VersionText.text = "版本：" + Application.version;
        Pages = 0;
        IntroUI.SetActive(true);
        AS = GetComponent<AudioSource>();
        TitleTextBox.text = "";
        SubtileTextBox.text = "";

        TextContents = textContents.Count;

        //print(textContents.Count);
    }

    void PlayTutor(int _i)
    {
        InitialUI(_i);

        if (_i < TextContents)
        {
            // 動畫按鍵
            if (textContents[_i].ModelAnimatorPara != -1)
            {
                PlayButton.SetActive(true);
            }

            // 標題
            TitleTextBox.text = textContents[_i].Title;

            // 說明文字
            MainTextBox.transform.GetChild(0).GetComponent<Text>().text = "";
            if (textContents[_i].MainText != "")
            {
                MainTextBox.gameObject.SetActive(true);
                MainTextBox.transform.GetChild(0).GetComponent<Text>().text = textContents[_i].MainText;
            }

            // 說明圖片
            MainTextBox.transform.GetChild(1).GetComponent<Image>().sprite = null;
            if (textContents[_i].MainImage != null)
            {
                MainTextBox.gameObject.SetActive(true);
                MainTextBox.transform.GetChild(1).gameObject.SetActive(true);
                MainTextBox.transform.GetChild(1).GetComponent<Image>().sprite = textContents[_i].MainImage;
                MainTextBox.transform.GetChild(1).GetComponent<Image>().preserveAspect = true;
            }

            // 字幕文字
            SubtileTextBox.text = textContents[_i].SubTitle;

            // 語音
            if (textContents[_i].TextContentAudioclips != null)
            {
                AS.clip = textContents[_i].TextContentAudioclips;
                AS.Play();
            }

            // 模型
            if (textContents[_i].ModelAnimator != null)
                textContents[_i].ModelAnimator.SetInteger("Kind", 0);

            if (textContents[_i].Model != null)
            {
                textContents[_i].Model.SetActive(true);
                //Object obj = Resources.Load<GameObject>(textContents[_i].Model);
                //GameObject gobj = Instantiate(obj) as GameObject;
                //gobj.transform.SetParent(DemoModel.transform);
                //gobj.transform.localPosition = Vector3.zero;
                //DemoModel.SetActive(true);
            }

            // 模型標示
            if (textContents[_i].Caption != null)
            {
                DemoCaption = textContents[_i].Caption;
                DemoCaption.SetActive(true);
            }

            // 模型UI
            if (textContents[_i].UI != null)
            {
                textContents[_i].UI.SetActive(true);
            }
        }
        else
        {
            IntroUI.SetActive(true);
            ClassUI.SetActive(false);
            PageChangeButtonUI.SetActive(false);
            PlayButtonUI.SetActive(false);
            AS.Stop();
            Pages = 0;
        }
    }

    public void StartTutorButton()
    {
        IntroUI.SetActive(false);
        ClassUI.SetActive(true);
        PageChangeButtonUI.SetActive(true);
        PlayButtonUI.SetActive(true);
        PlayTutor(Pages);
    }

    public void ShowCredits()
    {
        CreditsTextBox.SetActive(true);
        CopyrightsTextBox.SetActive(false);
    }

    public void ShowCopyrights()
    {
        CreditsTextBox.SetActive(false);
        CopyrightsTextBox.SetActive(true);
    }

    public void PlayContent()
    {
        PlayAnimation(Pages);
    }

    public void PauseContent()
    {
        PauseAnimation(Pages);
    }

    public void NextPage()
    {
        Pages += 1;

        PlayTutor(Pages);
    }

    public void LastPage()
    {
        Pages -= 1;

        PlayTutor(Pages);
    }

    public void HomeButton()
    {
        IntroUI.SetActive(true);
        ClassUI.SetActive(false);
        PlayButton.SetActive(false);
        PageChangeButtonUI.SetActive(false);

        AS.Stop();
    }

    void PlayAnimation(int _i)
    {
        if (textContents[_i].ModelAnimator != null)
        {
            textContents[_i].ModelAnimator.enabled = true;
            textContents[_i].ModelAnimator.SetInteger("Kind", textContents[_i].ModelAnimatorPara);
        }
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
    }

    void PauseAnimation(int _i)
    {
        if (textContents[_i].ModelAnimator != null)
            textContents[_i].ModelAnimator.enabled = false;
        PlayButton.SetActive(true);
        PauseButton.SetActive(false);
    }

    void InitialUI(int _i)
    {
        //if (DemoModel.transform.childCount > 0)
        //    Destroy(DemoModel.transform.GetChild(0).gameObject);

        PlayButton.SetActive(false);
        PauseButton.SetActive(false);
        MainTextBox.SetActive(false);
        MainTextBox.transform.GetChild(1).gameObject.SetActive(false);

        //DemoModel.SetActive(false);
        //DemoCaption.SetActive(false);

        if (_i == 0)
        {
            RButton.SetActive(true);
            LButton.SetActive(false);
        }
        else if (_i == textContents.Count)
        {
            RButton.SetActive(false);
            LButton.SetActive(true);
        }
        else
        {
            RButton.SetActive(true);
            LButton.SetActive(true);
        }

        foreach (var item in textContents)
        {
            if (item.Model != null)
                item.Model.SetActive(false);
            if (item.UI != null)
                item.UI.SetActive(false);
        }
    }
}
    