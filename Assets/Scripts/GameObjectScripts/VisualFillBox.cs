using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFillBox : MonoBehaviour {

    public int value { get; set; }
    public StationStatus type { get; set; }
    public VisualTrainLine visualTrainLine;

	// Use this for initialization
	void Start () {
        type = StationStatus.Empty;
    }

    void OnMouseDown()
    {
        if (type == StationStatus.Empty)
        {
            visualTrainLine.advanceLinePreviewEnd();

            if ((visualTrainLine.line.filledBoxes < visualTrainLine.line.boxValues.Length) && (!BoardController.CurrentCard.Equals(null)) && (BoardController.CurrentCard.type != StationStatus.FreeFill))
            {
                visualTrainLine.line.advanceLine(BoardController.CurrentCard.type, BoardController.CurrentCard.value);
                BoardController.CurrentCard = null;
            }
        }
    }

    private void OnMouseOver()
    {
        if (type == StationStatus.Empty)
        {
            visualTrainLine.advanceLinePreview(BoardController.CurrentCard.type, BoardController.CurrentCard.value);
        }
    }

    private void OnMouseExit()
    {
        visualTrainLine.advanceLinePreviewEnd();
    }
    // Update is called once per frame

    void Update () {
        string drawString = "";
        if (type == StationStatus.CircleFill)
        {
            drawString += "Circ";
        }
        else if (type == StationStatus.FreeFill)
        {
            drawString += "Free";
        }
        else if (type == StationStatus.Star)
        {
            drawString += "Star";
        }
        if (value != 0)
        {
            drawString += value;
        }
        GetComponentInChildren<TextMesh>().text = drawString;

        if ((visualTrainLine.line.filledBoxes < visualTrainLine.line.boxValues.Length) 
            && (BoardController.CurrentCard != null) 
            && (BoardController.CurrentCard.type != StationStatus.FreeFill)
            && (type == StationStatus.Empty))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
