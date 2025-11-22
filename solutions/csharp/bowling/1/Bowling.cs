
public class BowlingGame
{
    private readonly List<(int? Item1, int? Item2, int? Item3)> _frames = [];

    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10)
            throw new ArgumentException("Pin count must be between 0 and 10");

        if (_frames.Count == 0)
        {
            AddFrame(pins);
            return;
        }
        bool lastFrame = _frames.Count == 10;
        var currentFrame = _frames.Last();

        if (currentFrame.Item1 == 10 && !lastFrame)
        {
            AddFrame(pins);
            return;
        }

        if (currentFrame.Item2 != null && !lastFrame)
        {
            AddFrame(pins);
            return;
        }

        if (!lastFrame && (currentFrame.Item1 ?? 0) + pins > 10)
            throw new ArgumentException(
                $"Pin count {pins} exceeds bowling frame limit of 10"
            );

        UpdateFrame(_frames.Count - 1, pins, lastFrame);
    }

    private void AddFrame(int pins) => _frames.Add((pins, null, null));

    private void UpdateFrame(int frameIndex, int pins, bool lastFrame)
    {
        var currentFrame = _frames[frameIndex];

        if (currentFrame.Item2 == null)
        {
            if (!lastFrame || currentFrame.Item1 != 10)
            {
                if ((currentFrame.Item1 ?? 0) + pins > 10)
                    throw new ArgumentException("Pin count exceeds bowling frame limit of 10");
            }

            _frames[frameIndex] = (currentFrame.Item1, pins, currentFrame.Item3);
            return;
        }

        if (!lastFrame)
            throw new ArgumentException("Cannot roll a third ball in a non-final frame");

        if (currentFrame.Item3 != null)
            throw new ArgumentException("Third roll for the frame has already been set");

        int first = currentFrame.Item1 ?? 0;
        int second = currentFrame.Item2 ?? 0;

        if (first == 10)
        {
            if (second != 10 && second + pins > 10)
            {
                throw new ArgumentException(
                    "Two bonus rolls after a strike in the last frame cannot score more than 10 points");
            }

            _frames[frameIndex] = (currentFrame.Item1, currentFrame.Item2, pins);
            return;
        }

        if (first + second != 10)
        {
            throw new ArgumentException("Not eligible for a third roll in the final frame");
        }

        _frames[frameIndex] = (currentFrame.Item1, currentFrame.Item2, pins);

    }

    public int? Score()
    {
        int frameCount = _frames.Count;
        if (frameCount != 10) throw new ArgumentException("Not all frames have been rolled yet");

        var final = _frames[9];
        int first = final.Item1 ?? 0;
        int second = final.Item2 ?? 0;

        if (first == 10)
        {
            if (final.Item2 == null || final.Item3 == null)
                throw new ArgumentException("Both bonus rolls for a strike in the last frame must be rolled before score can be calculated");
        }
        else if (first + second == 10)
        {
            if (final.Item3 == null)
                throw new ArgumentException("Bonus roll for a spare in the last frame must be rolled before score can be calculated");
        }
        else
        {
            if (final.Item2 == null)
                throw new ArgumentException("Final frame is incomplete");
        }

        int score = 0;
        for (int frame = 0; frame < frameCount; frame++)
        {
            score += CalculateFrameScore(frame);
        }
        return score;
    }

    private int CalculateFrameScore(int frameIndex, int depth = 1)
    {
        var frame = _frames[frameIndex];
        if (frameIndex == 9)
            return CalculateFrame10(depth);
        if (frame.Item1 == 10)
            return CalculateStrike(frameIndex, depth);
        if ((frame.Item1 ?? 0) + (frame.Item2 ?? 0) == 10)
            return CalculateSpare(frameIndex, depth);

        return depth == 3 ? (frame.Item1 ?? 0) : (frame.Item1 ?? 0) + (frame.Item2 ?? 0);
    }

    private int CalculateFrame10(int depth = 1)
    {
        var frame10 = _frames[9];
        return depth switch
        {
            1 => (frame10.Item1 ?? 0) + (frame10.Item2 ?? 0) + (frame10.Item3 ?? 0),
            2 => (frame10.Item1 ?? 0) + (frame10.Item2 ?? 0),
            _ => (frame10.Item1 ?? 0),
        };
    }

    private int CalculateStrike(int frameIndex, int depth)
    {
        var frame = _frames[frameIndex];

        if (depth == 3)
            return frame.Item1 ?? 0;

        if (frameIndex == 8)
        {
            return 10 + CalculateFrame10(depth + 1);
        }
        return 10 + CalculateFrameScore(frameIndex + 1, depth + 1);
    }

    private int CalculateSpare(int frameIndex, int depth)
    {
        var frame = _frames[frameIndex];

        if (depth == 3)
            return frame.Item1 ?? 0;

        if (frameIndex == 8)
        {
            return 10 + CalculateFrame10(3);
        }
        return 10 + CalculateFrameScore(frameIndex + 1, 3);
    }
}