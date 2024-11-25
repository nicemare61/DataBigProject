using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

public class UIUpdate : MonoBehaviour
{
    [SerializeField] private OOPPlayer player;

    [SerializeField] private OOPExit exit;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdatePoint());

    }

    private IEnumerator UpdatePoint()
    {
        while (true)
        {
            Debug.Log("Yes");
            exit.Point = player.UpGradePoint;
            yield return new WaitForSeconds(1);
        }
    }

}
