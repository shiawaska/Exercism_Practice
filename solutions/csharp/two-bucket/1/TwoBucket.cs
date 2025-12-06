public enum Bucket
{
    One,
    Two,
}

internal class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}

internal class BucketState
{
    public Bucket Bucket { get; set; }
    public int Amount { get; set; }
    public int Size { get; set; }
    public bool IsStartBucket { get; set; }
}

internal class TwoBucket
{
    private BucketState[] _buckets = new BucketState[2];

    public int Moves;

    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        _buckets[0] = new BucketState
        {
            Size = bucketOne,
            Bucket = Bucket.One,
            IsStartBucket = startBucket == Bucket.One,
            Amount = 0,
        };

        _buckets[1] = new BucketState
        {
            Size = bucketTwo,
            Bucket = Bucket.Two,
            IsStartBucket = startBucket == Bucket.Two,
            Amount = 0,
        };
    }

    public TwoBucketResult Measure(int goal)
    {
        if (goal > Math.Max(_buckets[0].Size, _buckets[1].Size))
            throw new ArgumentException("Goal larger than both buckets.");

        if (goal % Gcd(_buckets[0].Size, _buckets[1].Size) != 0)
            throw new ArgumentException("Goal is not reachable (not a multiple of gcd).");

        return TwoBucketTest(goal);
    }

    public void FillBucket(Bucket startBucket)
    {
        int bucket = startBucket == Bucket.One ? 0 : 1;
        _buckets[bucket].Amount = _buckets[bucket].Size;
    }

    public void EmptyBucket(Bucket targetBucket)
    {
        int bucket = targetBucket == Bucket.One ? 0 : 1;
        _buckets[bucket].Amount = 0;
    }

    public void PourBucket(Bucket pourBucket, Bucket targetBucket)
    {
        int fromBucket = pourBucket == Bucket.One ? 0 : 1;
        int toBucket = targetBucket == Bucket.One ? 0 : 1;
        if (fromBucket == toBucket)
            return;
        for (
            int i = 0;
            _buckets[fromBucket].Amount != 0
                && _buckets[toBucket].Amount != _buckets[toBucket].Size;
            i++
        )
        {
            _buckets[toBucket].Amount++;
            _buckets[fromBucket].Amount--;
        }

        if (_buckets[fromBucket].Amount == 0 && _buckets[toBucket].Amount == _buckets[toBucket].Size)
        {
            FillBucket(pourBucket);
        }
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }

        return Math.Abs(a);
    }

    private static bool GoalReached(int amount, int goal) => amount == goal;

    private TwoBucketResult TwoBucketTest(int goal)
    {
        var fromBucket = _buckets.First(b => b.IsStartBucket);
        var toBucket = _buckets.First(b => !b.IsStartBucket);

        if (fromBucket.Size == goal)
        {
            FillBucket(fromBucket.Bucket);
            Moves++;
            return new TwoBucketResult
            {
                Moves = Moves,
                GoalBucket = fromBucket.Bucket,
                OtherBucket = 0,
            };
        }
        if (toBucket.Size == goal)
        {
            FillBucket(fromBucket.Bucket);
            Moves++;
            FillBucket(toBucket.Bucket);
            Moves++;
                
            return new TwoBucketResult
            {
                Moves = Moves,
                GoalBucket = toBucket.Bucket,
                OtherBucket = fromBucket.Amount
            };
        }
        while (!GoalReached(toBucket.Amount, goal) && !GoalReached(fromBucket.Amount, goal))
        {
            if (fromBucket.Amount == 0)
            {
                FillBucket(fromBucket.Bucket);
                if (GoalReached(toBucket.Amount, goal))
                    FillBucket(fromBucket.Bucket);
            }
            else if (toBucket.Amount == toBucket.Size)
                EmptyBucket(toBucket.Bucket);
            else
            {
                PourBucket(fromBucket.Bucket, toBucket.Bucket);
            }

            Moves++;
        }

        return new TwoBucketResult
        {
            Moves = Moves,
            GoalBucket = toBucket.Amount == goal ? toBucket.Bucket : fromBucket.Bucket,
            OtherBucket = fromBucket.Amount == goal ? toBucket.Amount : fromBucket.Amount,
        };

    }

}
