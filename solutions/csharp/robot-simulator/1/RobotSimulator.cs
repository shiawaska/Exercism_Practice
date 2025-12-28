public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    private Direction _direction;
    private int _x;
    private int _y;

    public RobotSimulator(Direction direction, int x, int y)
    {
        _direction = direction;
        _x = x;
        _y = y;
    }

    public Direction Direction => _direction;
    public int X => _x;
    public int Y => _y;

    public void Move(string instructions)
    {
        foreach (char instruction in instructions)
        {
            switch (instruction)
            {
                case 'R':
                    _direction = (Direction)(((int)_direction + 1) % 4);
                    break;
                case 'L':
                    _direction = (Direction)(((int)_direction - 1 + 4) % 4);
                    break;
                case 'A':
                    switch (_direction)
                    {
                        case Direction.North:
                            _y++;
                            break;
                        case Direction.East:
                            _x++;
                            break;
                        case Direction.South:
                            _y--;
                            break;
                        case Direction.West:
                            _x--;
                            break;
                    }
                    break;
            }
        }
    }
}