using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;

    [SerializeField]
    bool isPlaced = false;

    PipeGameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PipeGameManager>();
    }

    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        // 처음 시작할 때 정답인지 확인
        if (IsCorrectRotation())
        {
            isPlaced = true;
            gameManager.correctMove();
        }
        else
        {
            isPlaced = false;
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        bool nowCorrect = IsCorrectRotation();

        if (nowCorrect && isPlaced == false)
        {
            isPlaced = true;
            gameManager.correctMove();
        }
        else if (!nowCorrect && isPlaced == true)
        {
            isPlaced = false;
            gameManager.wrongMove();
        }
    }

    bool IsCorrectRotation()
    {
        float z = Mathf.Round(transform.eulerAngles.z);

        if (z == 360)
            z = 0;

        for (int i = 0; i < correctRotation.Length; i++)
        {
            if (z == correctRotation[i])
            {
                return true;
            }
        }

        return false;
    }
}