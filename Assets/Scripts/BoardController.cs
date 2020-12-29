using System.Collections.Generic;
using UnityEngine;

public enum GameStatus { Animation, Complete, Choice };

public class BoardController : MonoBehaviour
{
    public GameObject[] visualLines = new GameObject[10];
    public GameObject[] scoreDraw = new GameObject[5];
    public GameObject drawCard;

    TrainLine[] trainLines;
    List<TrainStation> trainStations = new List<TrainStation>();

    GameStatus state = GameStatus.Choice;

    CardDeck Deck;
    public static Card CurrentCard;

    // Use this for initialization
    void Start()
    {
        trainLines = new TrainLine[visualLines.Length];

        Deck = new CardDeck();

        for (int i = 0; i < visualLines.Length; i++)
        {
            VisualTrainLine visTrainLine = visualLines[i].GetComponent<VisualTrainLine>();
            trainLines[i] = new TrainLine(i, visTrainLine.allFillBox.Length, visTrainLine.Scores[0], visTrainLine.Scores[1]);
            visTrainLine.line = trainLines[i];

            for (int j = 0; j < visTrainLine.allStationBox.Length; j++)
            {
                VisualTrainStation visStation = visTrainLine.allStationBox[j].GetComponent<VisualTrainStation>();
                if (visStation.station == null)
                {
                    TrainStation station = new TrainStation();
                    visStation.station = station;
                    trainStations.Add(station);
                }
                trainLines[i].addStation(visStation.station);
            }
        }

        //trainLines[0].advanceLine(StationStatus.Filled, 6);
        //trainLines[0].advanceLine(StationStatus.Filled, 6);
        //trainLines[3].advanceLine(StationStatus.Filled, 2);
        //trainLines[3].advanceLine(StationStatus.CircleFill, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if ((CurrentCard == null) && (state == GameStatus.Choice))
        {
            CurrentCard = Deck.Draw();
            //CurrentCard = new Card(StationStatus.FreeFill, 1);
            string text = CurrentCard.type.ToString() + CurrentCard.value.ToString();
            if (CurrentCard.type == StationStatus.Filled)
            {
                text = CurrentCard.value.ToString();
            }
            else if (CurrentCard.type == StationStatus.CircleFill)
            {
                text = "Circ" + CurrentCard.value.ToString();
            }
            else if (CurrentCard.type == StationStatus.Star)
            {
                text = "Star";
            }
            else if (CurrentCard.type == StationStatus.FreeFill)
            {
                text = "Free";
            }
            drawCard.GetComponentInChildren<TextMesh>().text = text;

            int ScoreComp = 0;
            for (int j = 0; j < trainLines.Length; j++)
            {
                ScoreComp += trainLines[j].score();
            }
            int ScoreCross = 0;
            int EmptyStations = 0;
            for (int j = 0; j < trainStations.Count; j++)
            {
                if (trainStations[j].status == StationStatus.Empty)
                {
                    EmptyStations++;
                }
                else
                {
                    ScoreCross += trainStations[j].score();
                }
            }
            scoreDraw[0].GetComponent<DrawScore>().number = ScoreComp;
            scoreDraw[1].GetComponent<DrawScore>().number = ScoreCross;
            scoreDraw[2].GetComponent<DrawScore>().number = EmptyStations;
            scoreDraw[3].GetComponent<DrawScore>().number = NegativeScore(EmptyStations);
            scoreDraw[4].GetComponent<DrawScore>().number = ScoreComp + ScoreCross + scoreDraw[3].GetComponent<DrawScore>().number;
        }
    }

    public int NegativeScore(int emptyCount)
    {
        if (emptyCount >= 21)
        {
            return -10;
        }
        else if (emptyCount >= 19)
        {
            return -9;
        }
        else if (emptyCount >= 17)
        {
            return -8;
        }
        else if (emptyCount >= 15)
        {
            return -7;
        }
        else if (emptyCount >= 13)
        {
            return -6;
        }
        else if (emptyCount >= 11)
        {
            return -5;
        }
        else if (emptyCount >= 9)
        {
            return -4;
        }
        else if (emptyCount >= 8)
        {
            return -3;
        }
        else if (emptyCount >= 7)
        {
            return -2;
        }
        else if (emptyCount >= 6)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
