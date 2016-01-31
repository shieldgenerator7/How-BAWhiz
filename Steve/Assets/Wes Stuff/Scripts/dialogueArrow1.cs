using UnityEngine;
using System.Collections;
using System;

public class dialogueArrow1 : MonoBehaviour {

    public TextLoader textLoader;
    public UnityEngine.UI.Text textGUI;

    public GameObject wipzter;
    public GameObject profdumdoor;

    private UnityEngine.UI.Text uiText;

    public void OnClick()
    {
        updateText();
        // throw new NotImplementedException();
        highlightCharacterIcons();

    }


    // Use this for initialization
    void Start () {
        uiText = textGUI.GetComponent<UnityEngine.UI.Text>();
        updateText();
        highlightCharacterIcons();
    }

    private void updateText()
    {
        uiText.text = textLoader.getNextLine();
        string speaker = textLoader.getSpeaker();
        if (speaker != null && ! speaker.Equals(""))
        {
            uiText.fontStyle = FontStyle.Normal;
        }
        else
        {
            uiText.fontStyle = FontStyle.Italic;
        }
    }

    private void highlightCharacterIcons()
    {
        string speaker = textLoader.getSpeaker();
        bool wactive = speaker.Equals(wipzter.GetComponent<CharacterDisplayer>().scriptName);
        wipzter.GetComponent<CharacterDisplayer>().highlight(wactive);
        bool ddactive = speaker.Equals(profdumdoor.GetComponent<CharacterDisplayer>().scriptName);
        profdumdoor.GetComponent<CharacterDisplayer>().highlight(ddactive);
    }

 //   // Update is called once per frame
 //   void Update () {
        
	
	//}
}
