using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTrainLine : MonoBehaviour {
    int stationCount;

    public TrainLine line { get; set; }
    public GameObject[] allStationBox = new GameObject[20];
    public GameObject[] allFillBox = new GameObject[5];
    public int[] Scores = new int[2];


    // Use this for initialization
    void Start () {
        for (int j = 0; j < allFillBox.Length; j++)
        {
            allFillBox[j].GetComponent<VisualFillBox>().visualTrainLine = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (line != null) {
            for (int j = 0; j < allFillBox.Length; j++)
            {
                allFillBox[j].GetComponent<VisualFillBox>().value = line.boxValues[j];
                allFillBox[j].GetComponent<VisualFillBox>().type = line.boxTypes[j];
            }
        }
	}

    public void advanceLinePreview(StationStatus type, int number)
    {
        List<int> trainStationNumbers = line.advanceLineTargets(type, number);
        foreach (int trainStationNumber in trainStationNumbers)
        {
            VisualTrainStation trainStation = allStationBox[trainStationNumber].GetComponent<VisualTrainStation>();
            trainStation.preview = VisualTrainStation.StationPreview.Filled;
        }
    }

    public void advanceLinePreviewEnd()
    {
        foreach (GameObject trainStationObject in allStationBox)
        {
            VisualTrainStation trainStation = trainStationObject.GetComponent<VisualTrainStation>();
            trainStation.preview = VisualTrainStation.StationPreview.None;
        }
    }
}
