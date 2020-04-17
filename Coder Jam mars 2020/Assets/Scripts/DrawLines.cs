using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public GameObject LinePrefab;
    private GameObject currentLine;

    private LineRenderer lineRend;
    private List<Vector2> LiPlayerPosition = new List<Vector2>();
    [HideInInspector] public List<GameObject> liObjectColor = new List<GameObject>();

    [HideInInspector] public bool changeLineColor = false;
    [HideInInspector] public Color lineRendColor;
    private List<Material> liMaterial = new List<Material>();
    private int idMaterial = 0;

    private bool gotLine = true;

    void Start()
    {
        CreateLine();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPlayerPos = transform.position;

        if (!gotLine)
            return;

        if (Vector2.Distance(currentPlayerPos, LiPlayerPosition[LiPlayerPosition.Count - 1]) > 0.1f)
        {
            ChangeLine(currentPlayerPos);
        }
    }

    public void CreateLine()
    {
        gotLine = true;
        currentLine = Instantiate(LinePrefab, new Vector3(0f,0f, GameManager.Instance.IdLayer), Quaternion.identity);
        liObjectColor.Add(currentLine);
        lineRend = currentLine.GetComponent<LineRenderer>();
        LiPlayerPosition.Clear();
        LiPlayerPosition.Add(transform.position);
        LiPlayerPosition.Add(transform.position);

        if (changeLineColor)
        {
            Material currentMat = lineRend.material;
            currentMat.color = lineRendColor;
            liMaterial.Add(currentMat);
            lineRend.material = liMaterial[idMaterial];
            idMaterial++;
            changeLineColor = false;
            Debug.Log(currentMat.color);
            Debug.Log(currentMat);
        }

        lineRend.SetPosition(0, LiPlayerPosition[0]);
        lineRend.SetPosition(1, LiPlayerPosition[1]);
        GameManager.Instance.IdLayer--;
    }

    void ChangeLine(Vector2 newPlayerPos)
    {
        LiPlayerPosition.Add(newPlayerPos);
        lineRend.positionCount++;
        lineRend.SetPosition(lineRend.positionCount - 1, newPlayerPos);
    }

    public void ClearLine()
    {
        gotLine = false;
        foreach (GameObject obj in liObjectColor)
        {
            Destroy(obj);
        }
        liObjectColor.Clear();
        liMaterial.Clear();
        idMaterial = 0;
        GameManager.Instance.IdLayer = 1000;
    }
}
