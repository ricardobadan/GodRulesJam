using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    public GameObject continueButton;
    public AudioSource typeSound;
    public GameObject dialogBox;
    bool startedTyping;
    public bool canFire;
    public AudioManager audioManager;
    public GameObject objToActivate;


    void Start()
    {
        index = 0;
        dialogBox.SetActive(false);
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
            else
            {
                continueButton.SetActive(false);
            }
        }
    }

    public IEnumerator Type()
    {
        continueButton.SetActive(true);
        dialogBox.SetActive(true);
        canFire = false;
        if(textDisplay.text == "" && !startedTyping)
        {
            startedTyping = true;
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                typeSound.Play();
                yield return new WaitForSeconds(typingSpeed);
            }
            startedTyping = false;
        }

    }

    public IEnumerator TypeWithFire()
    {
        continueButton.SetActive(false);
        dialogBox.SetActive(true);
        if (textDisplay.text == "" && !startedTyping)
        {
            startedTyping = true;
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                typeSound.Play();
                yield return new WaitForSeconds(typingSpeed);
            }
            startedTyping = false;
        }
        yield return new WaitForSeconds(1f);

        NextSentence();

    }

    public void NextSentence()
    {
        
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            canFire = true;
            continueButton.SetActive(false);
            dialogBox.SetActive(false);
        }
        if(objToActivate != null)
        {
            objToActivate.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        dialogBox.SetActive(true);
        StartCoroutine(Type());
    }
}
