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

    // Update is called once per frame
	void Update () {
	
	}
}
