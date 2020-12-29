using System.Collections.Generic;

public class TrainLine
{
    int boxCount;
    public int filledBoxes = 0;

    int lineNumber;
    List<TrainStation> stationList = new List<TrainStation>();
    int[] Scores = new int[2];
    public int[] boxValues { get; set; }
    public StationStatus[] boxTypes { get; set; }

    public TrainLine(int lineNumber, int boxCount, int firstPlace, int secondPlace)
    {
        this.boxCount = boxCount;
        boxValues = new int[boxCount];
        boxTypes = new StationStatus[boxCount];

        this.lineNumber = lineNumber;
        Scores[0] = firstPlace;
        Scores[1] = secondPlace;
    }

    public void addStation(TrainStation station)
    {
        station.addLine(this);
        stationList.Add(station);
    }

    public void advanceLine(StationStatus type, int number)
    {
        boxValues[filledBoxes] = number;
        boxTypes[filledBoxes] = type;
        filledBoxes++;

        List<int> targetStationNumbers = advanceLineTargets(type, number);
        foreach (int stationNumber in targetStationNumbers)
        {
            stationList[stationNumber].status = type;
        }
    }

    public List<int> advanceLineTargets(StationStatus type, int number)
    {
        List<int> targetStationNumbers = new List<int>();

        bool start = false;
        int remain = number;
        for (int i = 0; i < stationList.Count; i++)
        {
            if (stationList[i].status == StationStatus.Empty)
            {
                start = true;
                targetStationNumbers.Add(i);
                remain--;
                if (remain == 0)
                {
                    break;
                }
            }
            else if ((start == true) && (type != StationStatus.CircleFill))
            {
                break;
            }
        }
        return targetStationNumbers;
    }

    public int score()
    {
        int points = 0;
        bool allFilled = true;
        for (int i = 0; i < stationList.Count; i++)
        {
            if (stationList[i].status == StationStatus.Empty)
            {
                allFilled = false;
            }
        }
        if (allFilled)
        {
            points += Scores[0];
        }
        return points;
    }
}