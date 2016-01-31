using UnityEngine;
using System.Collections;

public class TextLoader : MonoBehaviour {

    class DialogueLine
    {
        public string speaker;
        public string quote;
        public DialogueLine(string speaker, string quote)
        {
            this.speaker = speaker;
            this.quote = quote;
        }
        public string getSpeaker()
        {
            return speaker;
        }
        public string getQuote()
        {
            return quote;
        }
    }

    ArrayList dialogueLines = new ArrayList();
    int currentIndex=-1;

	// Use this for initialization
	void Start () {
        string textStream = System.IO.File.ReadAllText("Assets\\Wes Stuff\\Documents\\Intro Dialogue.txt");
        string[] lines = textStream.Split('\n');
        foreach(string line in lines)
        {
            if (line != null && !line.Equals("") && !line.Equals("\n"))
            {
                Debug.Log(line);
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    DialogueLine dl = new DialogueLine(parts[0].Trim(), parts[1].Trim());
                    dialogueLines.Add(dl);
                }
                else
                {
                    Debug.Log("This line is not formatted properly: " + line);
                    //Proper formatting is:
                    //[speaker]: [quote]
                    //...or, for italicized narration:
                    //: [quote]
                }
            }
        }
        //Debug.Log(textStream.Length);
	}

    public string getNextLine()
    {
        currentIndex++;
        Debug.Log(currentIndex);
        if (currentIndex >= dialogueLines.Count)
        {
            currentIndex--;
        }
        return ((DialogueLine)dialogueLines[currentIndex]).getQuote();
    }

    public string getSpeaker()
    {
        int index = (currentIndex < 0) ? 0 : currentIndex;
        return ((DialogueLine)dialogueLines[index]).getSpeaker();
    }

}
