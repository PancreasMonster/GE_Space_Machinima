using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yes : MonoBehaviour
{
    public string[] letters;
    public float delay, pauseLenght;
    public AudioSource aud;
    public bool pause;
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
        if (pause)
        {
            yield return new WaitForSeconds(pauseLenght);
            pauseLenght = 0;
        }

        text.text = text.text + letters[currentLetter];
        yield return new WaitForSeconds(delay);
        currentLetter++;
        if (aud != null && !aud.isPlaying)
            aud.Play();
        if (currentLetter < letters.Length)
            StartCoroutine(nextLetter());
        if (currentLetter == letters.Length && aud != null)
        {
            aud.Stop();
        }
    }
}
