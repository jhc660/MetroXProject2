using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTrainStation : MonoBehaviour {

    public enum StationPreview { None, Filled, CircleFill, FreeFill, Star };

    public TrainStation station { get; set; }
    public StationStatus status;
    public StationPreview preview;
    static int delay;

	void Start () {
        preview = StationPreview.None;
    }

    void OnMouseDown()
    {
        if ((status == StationStatus.Empty)&&(BoardController.CurrentCard != null) && (BoardController.CurrentCard.type == StationStatus.FreeFill))
        {
            station.status = StationStatus.FreeFill;
            BoardController.CurrentCard = null;
        }
    }

    void Update () {
        if (station != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            status = station.status;
            if (preview == StationPreview.Filled)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().color = Color.blue;
            } else if (status == StationStatus.Star)
            {
                GetComponentInChildren<TextMesh>().text = station.score().ToString();
            } else if (status != StationStatus.Empty)
            {
                    GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
            } else if ((BoardController.CurrentCard != null) && (BoardController.CurrentCard.type == StationStatus.FreeFill))
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
