using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterTextEffect : MonoBehaviour
{
    public string[] letters;
    public float delay;
    public AudioSource aud;
    private Text text;
    private int currentLetter = 0;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(nextLetter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator nextLetter()
    {
        yield return new WaitForSeconds(delay);
        text.text = text.text + letters[currentLetter];
        currentLetter++;
        if (aud != null)
            aud.Play();
        if (currentLetter > letters.Length)
            StartCoroutine(nextLetter());
    }
}
