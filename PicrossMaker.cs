using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PicrossMaker : MonoBehaviour
{
    [SerializeField] float distanceFromTop = 0;
    [SerializeField] float distanceFromLeft = 0;
    [SerializeField] float distanceFromEachOtherBase = 1;
    [SerializeField] GameObject Square;
    [SerializeField] int level = 1;
    [SerializeField] float baseScale = 1f;
    [SerializeField] TMP_Text horizontalLines;
    [SerializeField] TMP_Text verticalLines;
    string rowNumber = "";
    int rowCount = 0;
    int currentSpot = 0;
    public List<string> rowHolder = new List<string>();
    public List<string> colHolder = new List<string>();
    GameObject currentSquare;
    int[,] list;
    public TMP_Text[] numberLines;
    public TMP_Text[] numberColumns;
    float totalScale;
    // Start is called before the first frame update
    void Start()
    {
        levelCheck(level);
        picrossBuilder();
        findRows(list);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void levelCheck (int currentLevel)
    {
        switch (level)
        {
            case 1:
                list = new int[5, 5] { { 1, 0, 1, 1, 0 }, { 0, 1, 1, 1, 1 }, { 1, 1, 1, 1, 0 }, { 0, 1, 1, 1, 1 }, { 0, 0, 1, 1, 0 } };
                break;
            case 2:
                list = new int[7, 7] { { 1, 0, 1, 1, 0, 0, 0 }, { 0, 1, 1, 1, 1, 0, 0 }, { 1, 1, 1, 1, 0, 0, 0}, { 0, 1, 1, 1, 1, 0, 0 }, { 0, 0, 1, 1, 0, 0, 0 }, { 0, 1, 1, 1, 1, 0, 0 }, { 0, 0, 1, 1, 0, 0, 0 } };
                break;
        }
        totalScale = baseScale / list.GetLength(0);
        numberLines = new TMP_Text[list.GetLength(0)];
        numberColumns = new TMP_Text[list.GetLength(0)];
        currentSpot = list.GetLength(0)-1;
    }
    private void findRows(int[,] rowList)
    {
        string colNumber = "";
        int colCount = 0;
        for (int j = list.GetLength(0)-1; j >=0; j--)
        {
            for (int i = 0; i < list.GetLength(0); i++)
            {
                
                if (list[i, j] == 1)
                {
                    colCount++;

                }
                else if (colCount != 0)
                {
                    colNumber += colCount.ToString() + " ";
                    colCount = 0;
                }
            }
            if (colCount != 0)
            {
                colNumber += colCount.ToString() + " ";
                colCount = 0;

            }
            colHolder.Add(colNumber);
            if (colNumber == "")
                colNumber = "0";
            numberLines[j].text = colNumber;
            colNumber = "";

        }
    }
    
    private void picrossBuilder()
    {
        float distanceFromEachOther = distanceFromEachOtherBase / list.GetLength(0);

        for (int i = 0; i < list.GetLength(0); i++)
        {
            for (int j = list.GetLength(0) -1; j >= 0; j--)
            {
                currentSquare = Instantiate(Square, new Vector3(distanceFromLeft + (i * distanceFromEachOther), distanceFromTop + (j * distanceFromEachOther), 0), Square.transform.rotation);
                currentSquare.transform.localScale = new Vector3(baseScale / list.GetLength(0), baseScale / list.GetLength(0), baseScale / list.GetLength(0));
                if (list[i, j] == 1)
                {
                    rowCount++;
                    currentSquare.tag = "GoodSquare";
                }
                else if (rowCount != 0)
                {
                    rowNumber += rowCount.ToString()+"\n";
                    rowCount = 0;
                }
                if (i == 0)
                {
                    createUILists(currentSquare, rowNumber);
                }
            }
            if (rowCount != 0)
            {
                rowNumber += rowCount.ToString()+"\n";
                rowCount = 0;
            }
            labelUI(currentSquare, rowNumber, i);
            rowHolder.Add(rowNumber);
           if (rowNumber != null)
                numberColumns[i].text = rowNumber;
            else
                numberColumns[i].text = "0";
            rowNumber = "";

        }
    }
   private void createUILists(GameObject activeSquare, string rowNumber)
    {
        GameObject bigCanvas = GameObject.Find("Canvas");
        numberLines[currentSpot] = Instantiate(horizontalLines, new Vector3(transform.position.x, activeSquare.transform.position.y, 0), transform.rotation, bigCanvas.transform);
        numberLines[currentSpot].transform.position = new Vector3(activeSquare.transform.position.x-3f*totalScale, activeSquare.transform.position.y, horizontalLines.transform.position.z);
        numberLines[currentSpot].transform.localScale = new Vector3(baseScale / list.GetLength(0) * 5, baseScale / list.GetLength(0) * 5, baseScale / list.GetLength(0)*5);
        numberLines[currentSpot].alignment = TextAlignmentOptions.Right;
        currentSpot--;

    } 
    private void labelUI(GameObject activeSquare, string rowNumber, int space)
    {
        GameObject bigCanvas = GameObject.Find("Canvas");
        numberColumns[space] = Instantiate(horizontalLines, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation, bigCanvas.transform);
        numberColumns[space].transform.position = new Vector3(activeSquare.transform.position.x, activeSquare.transform.position.y-(1.5f*totalScale), transform.position.z);
        numberColumns[space].transform.localScale = new Vector3(baseScale / list.GetLength(0)*5, baseScale / list.GetLength(0)*5, baseScale / list.GetLength(0)*5);
        numberColumns[space].alignment = TextAlignmentOptions.Top;
    }
    
}
