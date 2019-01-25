using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesDiary : MonoBehaviour {

    private bool isOn;

    private GameObject Diary;
    [SerializeField] private Text textChapter;
    [SerializeField] private Text text1;
    [SerializeField] private Image image1;
    [SerializeField] private Text text2;
    [SerializeField] private Image image2;
    [SerializeField] private Text text3;
    [SerializeField] private Image image3;

    [SerializeField]
    private int currentChapter;
    [SerializeField]
    private int currnetIndex;

    public Sprite unknown;

    [SerializeField] public List<DialogueNote> Notes1 = new List<DialogueNote>();
    [SerializeField] public List<DialogueNote> Notes2 = new List<DialogueNote>();
    [SerializeField] public List<DialogueNote> Notes3 = new List<DialogueNote>();
    private List<List<DialogueNote>> Notes = new List<List<DialogueNote>>();

    private static DialoguesDiary diaryInstance;
    public static DialoguesDiary DiaryInstance
    {
        get
        {
            if (diaryInstance == null)
            {
                diaryInstance = GameObject.FindObjectOfType<DialoguesDiary>();
            }
            return diaryInstance;
        }
    }

    private string[] Chapters = {
        "Chapter 1",
        "Chapter 2",
        "Chapter 3"
    };
    


	// Use this for initialization
	void Start () {
        currentChapter = 1;
        currnetIndex = 0;
        Diary = GameObject.Find("DialogueNotes");
        Diary.SetActive(false);
        Notes.Add(Notes1);
        Notes.Add(Notes2);
        Notes.Add(Notes3);
    }

	// Update is called once per frame
	void Update () {
        if(Notes1.Count != 0 || Notes2.Count != 0 || Notes3.Count != 0)
            turnOnDiary();
        setChapterText();
    }

    private void setChapterText()
    {
        textChapter.text = Chapters[currentChapter - 1];
    }

    public void loadNextPage()
    {
        currnetIndex += 3;
        loadCurrentPage();
    }

    public void loadPreviousPage()
    {
       // Debug.Log("Przed" + currnetIndex);
        int mod = currnetIndex % 3;    
        currnetIndex =  currnetIndex - 3 + mod;
       // Debug.Log("Po" + currnetIndex);
        if (currnetIndex < 0)
        {
            currentChapter--;
            if(currentChapter < 1)
            {
                currentChapter = 3;
            }
            currnetIndex = 0;
        }
        loadCurrentPage();
    }

    private void loadCurrentPage()
    {
        int temp = Notes[currentChapter - 1].Count;
        //Debug.Log(temp);
        if (currnetIndex < temp)
        {
            //Debug.Log("Pierwsze okno " + currnetIndex);
            image1.enabled = true;
            text1.enabled = true;
            image1.sprite = Notes[currentChapter-1][currnetIndex].sprite;
            text1.text = Notes[currentChapter-1][currnetIndex].text;
            setChapterText();
            //currnetIndex++;
        }
        else
        {
            //Debug.Log("KURWA" + currnetIndex + " " + temp);
            if(currentChapter == 3)
            {
                currentChapter = 1;
                setChapterText();
                currnetIndex = 0;
            }
            else
            {
                currentChapter++;
                setChapterText();
                currnetIndex = 0;
            }
            loadCurrentPage();
        }
        if (currnetIndex + 1 < temp)
        {
            //Debug.Log("Drugie okno " + currnetIndex + 1);
            image2.enabled = true;
            text2.enabled = true;
            image2.sprite = Notes[currentChapter - 1][currnetIndex + 1].sprite;
            text2.text = Notes[currentChapter - 1][currnetIndex + 1].text;
            //currnetIndex++;
        }
        else
        {
            image2.enabled = false;
            text2.enabled = false;
        }
        if (currnetIndex + 2 < temp)
        {
            //Debug.Log("Trzecie okno " + currnetIndex + 2);
            image3.enabled = true;
            text3.enabled = true;
            image3.sprite = Notes[currentChapter - 1][currnetIndex + 2].sprite;
            text3.text = Notes[currentChapter - 1][currnetIndex + 2].text;
            //currnetIndex++;
        }
        else
        {
            image3.enabled = false;
            text3.enabled = false;
        }
    }


    private void turnOnDiary()
    {
        if(Input.GetKeyDown(KeyCode.Z) )
        {
            if(!isOn)
            {
                if (Notes1.Count > 0)
                {
                    currentChapter = 1;
                   // Debug.Log("Wybrałem 1");
                }
                else if (Notes2.Count > 0)
                {
                    currentChapter = 2;
                   // Debug.Log("Wybrałem 2");
                }  
                else if (Notes3.Count > 0)
                {
                    currentChapter = 3;
                   // Debug.Log("Wybrałem 3");
                }
                currnetIndex = 0;
                Notes.Clear();
                Notes.Add(Notes1);
                Notes.Add(Notes2);
                Notes.Add(Notes3);
                loadCurrentPage();
                setChapterText();
                Diary.SetActive(true);
                isOn = true;
            }
            else
            {
                Diary.SetActive(false);
                isOn = false;
            }
                
        }
    }

}
