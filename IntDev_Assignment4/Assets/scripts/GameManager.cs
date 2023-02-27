using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool goal1Reached;
    public bool goal2Reached;

    public TextMeshProUGUI myText1;
    public TextMeshProUGUI myText2;
    public int score1;
    public int score2;

    public bool leaf1Collect;
    public bool leaf2Collect;

    // Start is called before the first frame update
    void Start()
    {
        myText1.text = "Area 1 Leaves: 0";
        myText2.text = "Area 2 Leaves: 0";
    }

    // Update is called once per frame
    void Update()
    {
        myText1.text = "Area 1 Leaves: " + score1;
        myText2.text = "Area 2 Leaves: " + score2;

        if (leaf1Collect)
        {
            score1 = score1 + 1;
        }

        if (leaf2Collect)
        {
            score2 = score2 + 1;
        }

        if (score1 == 3)
        {
            goal1Reached = true;
        }

        if (goal1Reached == true)
        {
            SceneManager.LoadScene(1);
        }

        if (score2 == 7)
        {
            goal2Reached = true;
        }

        if (goal2Reached == true)
        {
            SceneManager.LoadScene(2);
        }
    }
}
