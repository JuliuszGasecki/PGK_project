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

    private int currentChapter;
    private int currnetIndex;

    public Sprite unknown;

    [SerializeField] public List<DialogueNote> Notes1 = new List<DialogueNote>();
    [SerializeField] public List<DialogueNote> Notes2 = new List<DialogueNote>();
    [SerializeField] public List<DialogueNote> Notes3 = new List<DialogueNote>();
    [SerializeField] public List<DialogueNote> Notes4 = new List<DialogueNote>();
    [SerializeField] public List<DialogueNote> Notes5 = new List<DialogueNote>();
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
        "Chapter 3",
        "Chapter 4",
        "Chapter 5"
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
        Notes.Add(Notes4);
        Notes.Add(Notes5);
    }

	// Update is called once per frame
	void Update () {
        turnOnDiary();
    }

    private void indexOverflow()
    {
        if(currnetIndex >= Notes[currentChapter-1].Count)
        {
            currnetIndex = 0;
        }
    }

    private bool isIndexOverflow()
    {
        if(currnetIndex >= Notes[currentChapter-1].Count)
        {
            return true;
        }
        return false;
    }

    private bool isIndexOverflow(int lol)
    {
        if (lol >= Notes.Count)
        {
            return true;
        }
        return false;
    }

    private void setChapterText()
    {
        textChapter.text = Chapters[currentChapter - 1];
    }

    public void loadNextPage()
    {
        loadCurrentPage();
    }

    public void loadPreviousPage()
    {
        Debug.Log("Przed" + currnetIndex);
        currnetIndex = currnetIndex - 3;
        Debug.Log("Po" + currnetIndex);
        if (currnetIndex <= 0)
        {
            currentChapter--;
            if(currentChapter < 1)
            {
                currentChapter = 5;
            }
            currnetIndex = 0;
        }
            
        loadCurrentPage();
    }

    private void loadCurrentPage()
    {
        int temp = Notes[currentChapter - 1].Count;
        if (currnetIndex < temp)
        {
            text1.enabled = true;
            image1.sprite = Notes[currentChapter-1][currnetIndex].sprite;
            text1.text = Notes[currentChapter-1][currnetIndex].text;
            setChapterText();
            if(!Notes[currentChapter - 1][currnetIndex].isActive)
            {
                text1.enabled = false;
                image1.sprite = unknown;
            }
            currnetIndex++;
        }
        else
        {
            if(currentChapter + 1 >5)
            {
                currentChapter = 1;
                currnetIndex = 0;
                setChapterText();
            }
            else
            {
                currentChapter++;
                currnetIndex = 0;
            }
            loadCurrentPage();
        }
        if (currnetIndex < temp)
        {
            image2.enabled = true;
            text2.enabled = true;
            image2.sprite = Notes[currentChapter - 1][currnetIndex].sprite;
            text2.text = Notes[currentChapter - 1][currnetIndex].text;
            if (!Notes[currentChapter - 1][currnetIndex].isActive)
            {
                text2.enabled = false;
                image2.sprite = unknown;
            }
            currnetIndex++;
        }
        else
        {
            image2.enabled = false;
            text2.enabled = false;
        }
        if (currnetIndex < temp)
        {
            image3.enabled = true;
            text3.enabled = true;
            image3.sprite = Notes[currentChapter - 1][currnetIndex].sprite;
            text3.text = Notes[currentChapter - 1][currnetIndex].text;
            indexOverflow();
            if (!Notes[currentChapter - 1][currnetIndex].isActive)
            {
                text3.enabled = false;
                image3.sprite = unknown;
            }
            currnetIndex++;
        }
        else
        {
            image3.enabled = false;
            text3.enabled = false;
            if (currentChapter + 1 > 5)
            {
                currentChapter = 1;
                currnetIndex = 0;
            }
            else
            {
                currentChapter++;
                currnetIndex = 0;
            }
        }

    }


    private void turnOnDiary()
    {
        if(Input.GetKeyDown(KeyCode.Z) )
        {
            if(!isOn)
            {
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
