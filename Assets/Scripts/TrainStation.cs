using System.Collections.Generic;

public enum StationStatus { Empty, Filled, CircleFill, FreeFill, Star };

public class TrainStation
{
    List<TrainLine> parentLines = new List<TrainLine>();
    public StationStatus status { get; set; }

    public TrainStation()
    {
        status = StationStatus.Empty;
    }

    public void addLine(TrainLine line)
    {
        parentLines.Add(line);
    }

    public int score()
    {
        if (status == StationStatus.Star)
        {
            return 2 * parentLines.Count;
        } else
        {
            return 0;
        }
    }
}