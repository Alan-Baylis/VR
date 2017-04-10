using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewspaperHeadlineScript : MonoBehaviour
{

    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;

        eachLine = new List<string>();
        eachLine.AddRange(
                    theWholeFileAsOneLongString.Split("\n"[0]));

        StartCoroutine(ChangeHeadline(eachLine));
    }


    IEnumerator ChangeHeadline(List<string> lines)
    {
        int lenght = lines.Count;
        int i = 0;
        while (true)
        {
            if (i == lines.Count)
            {
                i = 0;
            }
            GetComponent<TMPro.TMP_Text>().text = lines[i];
                //ResolveTextSize(lines[i],33);
            i += 1;
            yield return new WaitForSeconds(3);
        }

    }

    // Wrap text by line height (actually unneccessary with TMPro)
    private string ResolveTextSize(string input, int lineLength)
    {

        // Split string by char " "         
        string[] words = input.Split(" "[0]);

        // Prepare result
        string result = "";

        // Temp line string
        string line = "";

        // for each all words        
        foreach (string s in words)
        {
            // Append current word into line
            string temp = line + " " + s;

            // If line length is bigger than lineLength
            if (temp.Length > lineLength)
            {

                // Append current line into result
                result += line + "\n";
                // Remain word append into new line
                line = s;
            }
            // Append current word into current line
            else
            {
                line = temp;
            }
        }

        // Append last line into result        
        result += line;

        // Remove first " " char
        return result.Substring(1, result.Length - 1);
    }


}
