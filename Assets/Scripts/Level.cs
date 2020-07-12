using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] int numOfbricks;
    SceneLoader sceneloader;
    [SerializeField] Text currentScore;

    public void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void incrementBricks()
    {
        numOfbricks++;
    }

    public void destroyBricks()
    {
        numOfbricks--;

        if (numOfbricks == 0)
        {
            sceneloader.LoadNextScene();
        }
    }

    public void Update()
    {
        currentScore.text = numOfbricks.ToString();
    }

}
