using UnityEngine;
using System.Collections;

public class LessonStatus : MonoBehaviour
{

    public PhysicalStatus PhysicalStatus;
    public VerbalStatus VerbalStatus;
    public SomaticStatus SomaticStatus;

    private PlayerProgress Progress
    {
        get { return PlayerProgress.Instance; }
    }

    // Use this for initialization
	void Start ()
	{
        PhysicalStatus.Show();
	    VerbalStatus.Show();
        SomaticStatus.Show();
	}

    private void populateSomatic()
    {
        throw new System.NotImplementedException();
    }

    private void populateVerbal()
    {
        throw new System.NotImplementedException();
    }

    private void populatePhysical()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
	void Update () {
	
	}
}
