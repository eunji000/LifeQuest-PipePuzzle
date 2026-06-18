using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField]
    int totalPipes = 0;

    [SerializeField]
    int correctedPipes = 0;

    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedPipes += 1;

        Debug.Log("맞은 파이프 수: " + correctedPipes + " / 전체 파이프 수: " + totalPipes);

        if (correctedPipes == totalPipes)
        {
            Debug.Log("파이프를 모두 맞췄어!");
        }
    }

    public void wrongMove()
    {
        correctedPipes -= 1;

        if (correctedPipes < 0)
            correctedPipes = 0;

        Debug.Log("맞은 파이프 수: " + correctedPipes + " / 전체 파이프 수: " + totalPipes);
    }
}