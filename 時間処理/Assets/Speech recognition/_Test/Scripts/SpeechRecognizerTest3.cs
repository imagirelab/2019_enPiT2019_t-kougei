using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using FantomLib;
using System.Text.RegularExpressions;

//Speech Recognizer demo using controllers and localize
//音声認識でコントローラ（～Controller）とローカライズを利用したデモ
public class SpeechRecognizerTest3 : MonoBehaviour {

    public LifePoint LP1;
    public LifePoint LP2;
    public DamageVoice DV;
    public Text displayText;
    public Toggle webSearchToggle;
    public Button recongizerButton;
    public Animator circleAnimator;
    public Animator voiceAnimator;
    string str;
    string strNumber;


    //Message when recognizer start.
    public LocalizeString recognizerStartMessage = new LocalizeString(SystemLanguage.English,
        new List<LocalizeString.Data>()
        {
            new LocalizeString.Data(SystemLanguage.English, "Starting Recognizer..."),    //default language
            new LocalizeString.Data(SystemLanguage.Japanese, "音声認識を起動してます…"),
        });

    //Message when recognizer ready.
    public LocalizeString recognizerReadyMessage = new LocalizeString(SystemLanguage.English,
        new List<LocalizeString.Data>()
        {
            new LocalizeString.Data(SystemLanguage.English, "Waiting voice..."),    //default language
            new LocalizeString.Data(SystemLanguage.Japanese, "音声を待機中…"),
        });

    //Message when recognizer begin.
    public LocalizeString recognizerBeginMessage = new LocalizeString(SystemLanguage.English,
        new List<LocalizeString.Data>()
        {
            new LocalizeString.Data(SystemLanguage.English, "Recognizing voice..."),    //default language
            new LocalizeString.Data(SystemLanguage.Japanese, "音声を取得しています…"),
        });

    public bool isRecognitionMultiChoice = true;        //Use 'MultiChoice' for word selection methods (false is 'SingleChoice').
    public bool appendDateTimeStringOnSave = true;      //Add a DateTime string to the file name.


    //SpeechRecognizer
    public SpeechRecognizerController speechRecognizerControl;
    public SpeechRecognizerDialogController speechRecognizerDialog;

    //Mainly 'WebSearchController.StartSearch' is called.
    public WebSearchController webSearchControl;

    //Mainly 'SelectDialogController.Show' is called.
    public SelectDialogController selectDialogControl;

    //Mainly 'SingleChoiceDialogController.Show' is called.
    public SingleChoiceDialogController singleChoiceDialogControl;

    //Mainly 'MultiChoiceDialogController.Show' is called.
    public MultiChoiceDialogController multiChoiceDialogControl;

    //Mainly 'StorageSaveTextController.Show, .CurrentValue' is called.
    public StorageSaveTextController storageSaveTextControl;

    //When dynamically generating file name to save.
    //保存するファイル名を動的に生成するとき
    public bool autoSavefileName = true;



    //==========================================================

    // Use this for initialization
    private void Start () {

        OnStartRecognizer();
        //if (speechRecognizerDialog != null)
        //{
        //    DisplayText(displayText.text == "" ? "" : "\n", true); 
        //    DisplayText("IsSupportedRecognizer = " + speechRecognizerDialog.IsSupportedRecognizer + "\n"
        //        + "'RECORD_AUDIO' permission = " + speechRecognizerDialog.IsPermissionGranted, true);
        //}
    }
    
    // Update is called once per frame
    //private void Update () {
        
    //}


    //==========================================================
    //Display text string

    //Display text string (and for reading)
    public void DisplayText(object message)
    {
        if (displayText != null)
            displayText.text = message.ToString();
    }

    public void DisplayText(object message, bool add)
    {
        if (displayText != null)
        {
            if (add)
                displayText.text += message;
            else
                displayText.text = message.ToString();
        }
    }

    public void DisplayTextLine(object message)
    {
        DisplayText(message + "\n", true);
    }

    public void DisplayText(object[] words)
    {
        if (displayText != null)
            displayText.text = string.Join("\n", words.Select(e => e.ToString()).ToArray());
    }

    public void DisplayPermission(string permission, bool granted)
    {
        if (displayText != null)
            displayText.text += permission.Replace("android.permission.", "") + " = " + granted + "\n";
    }
    
    //==========================================================
    //Function of text etc.
    
    public void SaveText()
    {
        if (storageSaveTextControl != null && displayText != null && !string.IsNullOrEmpty(displayText.text))
        {
            if (autoSavefileName)
            {
                //Make a part of the text of the first line a file name.    //最初の行のテキストの一部をファイル名にする
                string str = displayText.text.Split('\n')[0];   
                string file = str.Substring(0, Mathf.Min(str.Length, 16));
                if (appendDateTimeStringOnSave)
                    file += "_" + DateTime.Now.ToString("yyMMdd_HHmmss");
                if (string.IsNullOrEmpty(file))
                    file = "NewRecognition";
                if (!file.EndsWith(".txt"))
                    file += ".txt";
                storageSaveTextControl.CurrentValue = file;
            }

            storageSaveTextControl.Show(displayText.text);
        }
    }


    //Search words by web.
    public void StartWebSearch(string word)
    {
        if (webSearchControl != null)
            webSearchControl.StartSearch(word);
    }

    //Toggle button (webSearchToggle) to switch WebSearch.
    public void SwitchWebSearch(string[] words)
    {
        bool player1Flag = false;
        bool player2Flag = false;
  
        for(int i = 0; i < words.Length; i++)
        {
            // 音声認識を使いやすくするための変換
            if (words[i].Contains("Player 1"))
            {
                player1Flag = true;
                str = words[i].Replace("Player 1", "");
            }
            else if (words[i].Contains("Player 2"))
            {
                player2Flag = true;
                str = words[i].Replace("Player 2", "");
            }
            else if (words[i].Contains("プレイヤー1"))
            {
                player1Flag = true;
                str = words[i].Replace("プレイヤー1", "");
            }
            else if (words[i].Contains("プレイヤー2"))
            {
                player2Flag = true;
                str = words[i].Replace("プレイヤー2", "");
            }
            else if (words[i].Contains("レイヤー1"))
            {
                player1Flag = true;
                str = words[i].Replace("レイヤー1", "");
            }
            else if (words[i].Contains("レイヤー2"))
            {
                player2Flag = true;
                str = words[i].Replace("レイヤー2", "");
            }
            else if (words[i].Contains("レイヤ1"))
            {
                player1Flag = true;
                str = words[i].Replace("レイヤ1", "");
            }
            else if (words[i].Contains("レイヤ2"))
            {
                player2Flag = true;
                str = words[i].Replace("レイヤ2", "");
            }
            else if (words[i].Contains("プレイヤーに"))
            {
                player2Flag = true;
                str = words[i].Replace("レイヤーに", "");
            }
            else if (words[i].Contains("部屋に"))
            {
                player2Flag = true;
                str = words[i].Replace("部屋に", "");
            }
            else if (words[i].Contains("Player に"))
            {
                player2Flag = true;
                str = words[i].Replace("Player に", "");
            }
            else if (words[i].Contains("Player 市"))
            {
                player1Flag = true;
                str = words[i].Replace("Player 市", "");
            }
            else if (words[i].Contains("プレイヤー市"))
            {
                player1Flag = true;
                str = words[i].Replace("プレイヤー市", "");
            }
            else if (words[i].Contains("プレイヤーズに2000"))
            {
                player2Flag = true;
                str = "1000";
            }
            else if (words[i].Contains("プレイヤーズ2000"))
            {
                player2Flag = true;
                str = "1000";
            }
            else if (words[i].Contains("プレイヤーズ"))
            {
                player2Flag = true;
                str = words[i].Replace("プレイヤーズ", "");
            }
            else if (words[i].Contains("部屋に"))
            {
                player2Flag = true;
                str = words[i].Replace("部屋に", "");
            }
            else if (words[i].Contains("Player 番"))
            {
                player1Flag = true;
                str = words[i].Replace("Player 番", "");
            }
            else if (words[i].Contains("プレイヤー番"))
            {
                player1Flag = true;
                str = words[i].Replace("プレイヤー番", "");
            }
            else if (words[i].Contains("市泉"))
            {
                player1Flag = true;
                str = "5000";
            }
            else if (words[i].Contains("アニメ"))
            {
                player2Flag = true;
                str = words[i].Replace("アニメ", "");
            }
            else if (words[i].Contains("ミニ"))
            {
                player2Flag = true;
                str = words[i].Replace("ミニ", "");
            }
            else if (words[i].Contains("圧"))
            {
                player2Flag = true;
                str = words[i].Replace("圧", "");
            }
            else if (words[i].Contains("プレイヤーついに"))
            {
                player2Flag = true;
                str = words[i].Replace("プレイヤーついに", "");
            }
            else if (words[i].Contains("クレアチニン"))
            {
                player1Flag = true;
                str = words[i].Replace("クレアチニン", "");
            }
            else if (words[i].Contains("Player ワニ"))
            {
                player1Flag = true;
                str = words[i].Replace("Player ワニ", "");
            }
            else if (words[i].Contains("Id"))
            {
                player1Flag = true;
                str = words[i].Replace("Id", "");
            }
            else if (words[i].Contains("Player アプリ"))
            {
                player1Flag = true;
                str = words[i].Replace("Player アプリ", "");
            }
            else if (words[i].Contains("相手に"))
            {
                player1Flag = true;
                str = words[i].Replace("相手に", "");
            }
            else if (words[i].Contains("スレイヤーズ"))
            {
                player2Flag = true;
                str = words[i].Replace("スレイヤーズ", "");
            }


            if (str.Contains("耳栓"))
            {
                str = "2000";
            }
            else if (str.Contains("戦") || str.Contains("宣") || str.Contains("22"))
            {
                str = "1000";
            }
            else if (str.Contains("参戦") || str.Contains("日本人"))
            {
                str = "3000";
            }
            else if (str.Contains("四駆") || str.Contains("240") || str.Contains("4線") || str.Contains("温泉"))
            {
                str = "4000";
            }
            else if (str.Contains("古船") || str.Contains("ニコ生") || str.Contains("御所"))
            {
                str = "5000";
            }
            else if (str.Contains("6線") || str.Contains("宣"))
            {
                str = "6000";
            }
            else if (str.Contains("7線") || str.Contains("7船") || str.Contains("73"))
            {
                str = "7000";
            }
            else if (str.Contains("発展") || str.Contains("埋髪店") || str.Contains("28") || str.Contains("8線"))
            {
                str = "8000";
            }

            strNumber = Regex.Replace(str, @"[^0-9]", "");
        }

        if (int.TryParse(strNumber, out int damage))
        {
            if(player1Flag)
            {
                LP1.Damage(damage);
                DV.DamageVoiceSelector(damage);
            }
            else if(player2Flag)
            {
                LP2.Damage(damage);
                DV.DamageVoiceSelector(damage);
            }
        }

        if (webSearchToggle != null && webSearchToggle.isOn)
        {
            if (words.Length > 1)
            {
                if (selectDialogControl != null)
                    selectDialogControl.Show(words);
            }
            else
                StartWebSearch(words[0]);    //When there is only one word.
        }
        else
        {
            if (words.Length > 1)
            {
                if (isRecognitionMultiChoice)
                {
                    if (multiChoiceDialogControl != null)
                        multiChoiceDialogControl.Show(words);
                }
                else
                {
                    if (singleChoiceDialogControl != null)
                        singleChoiceDialogControl.Show(words);
                }
            }
            else
                DisplayText(words[0]);    //When there is only one word.
        }
    }


    //==========================================================
    //Example with Google dialog

    //Receive results from speech recognition with dialog.
    public void OnResultSpeechRecognizerDialog(string[] words)
    {
        DisplayText(words);
        SwitchWebSearch(words);
    }


    //==========================================================
    //Example without dialog (Callback handlers)

    //Callback handler for start Speech Recognizer
    public void OnStartRecognizer()
    {
        if (speechRecognizerControl != null)
        {
            if (speechRecognizerControl.IsSupportedRecognizer && speechRecognizerControl.IsPermissionGranted)
            {
                DisplayText(recognizerStartMessage);
                StartUI();
            }
        }
    }

    //Callback handler for microphone standby state
    public void OnReady()
    {
        DisplayText(recognizerReadyMessage);
        ReadyUI();
    }

    ///Callback handler for microphone begin speech recognization state
    public void OnBegin()
    {
        DisplayText(recognizerBeginMessage);
        BeginUI();
    }

    //Receive the result when speech recognition succeed.
    public void OnResult(string[] words)
    {
        ResetUI();
        DisplayText(words);
        SwitchWebSearch(words);
    }

    //Receive the error when speech recognition fail.
    public void OnError(string message)
    {
        ResetUI();
        DisplayText(message);
    }


    //==========================================================
    //UI

    //Start Recognizer UI
    private void StartUI()
    {
        if (recongizerButton != null)
            recongizerButton.interactable = false;
    }

    //Microphone standby UI
    private void ReadyUI()
    {
        if (circleAnimator != null)
            circleAnimator.SetTrigger("ready");

        if (voiceAnimator != null)
            voiceAnimator.SetTrigger("ready");
    }

    //Microphone begin speech recognization UI
    private void BeginUI()
    {
        if (circleAnimator != null)
            circleAnimator.SetTrigger("speech");

        if (voiceAnimator != null)
            voiceAnimator.SetTrigger("speech");
    }

    //Reset UI
    public void ResetUI()
    {
        if (circleAnimator != null)
            circleAnimator.SetTrigger("stop");

        if (voiceAnimator != null)
            voiceAnimator.SetTrigger("stop");

        if (recongizerButton != null)
            recongizerButton.interactable = true;
    }

    //Callback handler for locale change dropdown (OnValueChanged)
    public void OnLocaleValueChanged(Dropdown localeDropdown)
    {
        if (localeDropdown == null)
            return;

        string loc = localeDropdown.captionText.text;
        if (speechRecognizerControl != null)
            speechRecognizerControl.Locale = (loc == AndroidLocale.Default) ? "" : loc; //To make it the system default, put an empty character ("").
        if (speechRecognizerDialog != null)
            speechRecognizerDialog.Locale = (loc == AndroidLocale.Default) ? "" : loc;  //To make it the system default, put an empty character ("").
    }
}
