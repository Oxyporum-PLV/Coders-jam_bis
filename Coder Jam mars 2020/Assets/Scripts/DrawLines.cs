using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public GameObject LinePrefab;
    private GameObject currentLine;

    private LineRenderer lineRend;
    private List<Vector2> LiPlayerPosition = new List<Vector2>();

    [HideInInspector] public bool changeLineColor = false;
    [HideInInspector] public Color lineRendColor;
    private List<Material> liMaterial = new List<Material>();
    private int idNewLine = 0;

    void Start()
    {
        CreateLine();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPlayerPos = transform.position;

        if (Vector2.Distance(currentPlayerPos, LiPlayerPosition[LiPlayerPosition.Count - 1]) > 0.1f)
        {
            ChangeLine(currentPlayerPos);
        }
    }

    public void CreateLine()
    {
        currentLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        lineRend = currentLine.GetComponent<LineRenderer>();
        LiPlayerPosition.Clear();
        LiPlayerPosition.Add(transform.position);
        LiPlayerPosition.Add(transform.position);

        if (changeLineColor)
        {
            Material currentMat = lineRend.material;
            currentMat.color = lineRendColor;
            liMaterial.Add(currentMat);
            lineRend.material = liMaterial[idNewLine];
            idNewLine++;
            lineRend.sortingOrder = idNewLine;
            changeLineColor = false;
        }

        lineRend.SetPosition(0, LiPlayerPosition[0]);
        lineRend.SetPosition(1, LiPlayerPosition[1]);
    }

    void ChangeLine(Vector2 newPlayerPos)
    {
        LiPlayerPosition.Add(newPlayerPos);
        lineRend.positionCount++;
        lineRend.SetPosition(lineRend.positionCount - 1, newPlayerPos);
    }
}
