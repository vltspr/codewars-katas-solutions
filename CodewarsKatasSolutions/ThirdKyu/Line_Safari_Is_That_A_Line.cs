namespace ThirdKyu;

using System;
using System.Collections.Generic;

public class Dinglemouse
{
    private static (int, int) _x1Position = (-1, -1);
    private static (int, int) _x2Position = (-1, -1);
    private static (int, int) _position = (-1, -1);
    private static Direction _direction = Direction.Unknown;
    private static char _cursor = 'X';
    private static int _totalCharsInGrid = 0;
    private static int _totalCharsTraversed = 1;
    private static List<(int, int)> _positionsUsed = new();

    public static bool Line(char[][] grid)
    {
        _direction = Direction.Unknown;
        _totalCharsTraversed = 1;
        _totalCharsInGrid = 0;
        _positionsUsed.Clear();
        (_x1Position, _x2Position) = FindXs(grid);
        _position = _x1Position;

        var ret = RunLine(grid);
        if (ret) return true;


        _direction = Direction.Unknown;
        _totalCharsTraversed = 1;
        _totalCharsInGrid = 0;
        _positionsUsed.Clear();
        (_x1Position, _x2Position) = FindXs(grid);
        (_x1Position, _x2Position) = (_x2Position, _x1Position);
        _position = _x1Position;
        ret = RunLine(grid);
        return ret;
    }

    private static bool RunLine(char[][] grid)
    {
        try
        {
            while (_position != _x2Position)
            {
                SetCursor(grid);
                var possibleOutcomes = LookAround(grid);

                if (possibleOutcomes == 0) return false;

                if ((_cursor == 'X' && possibleOutcomes != 1)
                    || (_cursor == '+' && possibleOutcomes > 1)) return false;

                switch (_direction)
                {
                    case Direction.Right:
                        _position.Item2++;
                        _totalCharsTraversed++;
                        break;

                    case Direction.Left:
                        _position.Item2--;
                        _totalCharsTraversed++;
                        break;

                    case Direction.Down:
                        _position.Item1++;
                        _totalCharsTraversed++;
                        break;

                    case Direction.Up:
                        _position.Item1--;
                        _totalCharsTraversed++;
                        break;

                    case Direction.Unknown:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _positionsUsed.Add((_position.Item1, _position.Item2));
            }
        }
        catch (Exception)
        {
            return false;
        }

        return _totalCharsTraversed == _totalCharsInGrid;
    }

    private static void SetCursor(char[][] grid)
    {
        _cursor = grid[_position.Item1][_position.Item2];
    }

    private static int LookAround(char[][] grid)
    {
        var possibleMoves = 0;

        switch (_direction)
        {
            case Direction.Unknown:
                if (LookRight(grid, _position) is '-' or '+' or 'X')
                {
                    possibleMoves++;
                    _direction = Direction.Right;
                }

                if (LookLeft(grid, _position) is '-' or '+' or 'X')
                {
                    possibleMoves++;
                    _direction = Direction.Left;
                }

                if (LookDown(grid, _position) is '|' or '+' or 'X')
                {
                    possibleMoves++;
                    _direction = Direction.Down;
                }

                if (LookUp(grid, _position) is '|' or '+' or 'X')
                {
                    possibleMoves++;
                    _direction = Direction.Up;
                }

                break;
            case Direction.Left:
                if (_cursor == '-')
                {
                    if (LookLeft(grid, _position) == '|') return 0;

                    if (LookLeft(grid, _position) is '-' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Left;
                        return possibleMoves;
                    }
                }

                if (_cursor == '+')
                {
                    if (LookUp(grid, _position) is '|' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Up;
                    }

                    if (LookDown(grid, _position) is '|' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Down;
                    }
                }

                break;
            case Direction.Right:
                if (_cursor == '-')
                {
                    if (LookRight(grid, _position) == '|') return 0;

                    if (LookRight(grid, _position) is '-' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Right;
                        return possibleMoves;
                    }
                }

                if (_cursor == '+')
                {
                    if (LookUp(grid, _position) is '|' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Up;
                    }

                    if (LookDown(grid, _position) is '|' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Down;
                    }
                }

                break;
            case Direction.Up:
                if (_cursor == '|')
                {
                    if (LookUp(grid, _position) == '-') return 0;

                    if (LookUp(grid, _position) is '|' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Up;
                        return possibleMoves;
                    }
                }

                if (_cursor == '+')
                {
                    if (LookLeft(grid, _position) is '-' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Left;
                    }

                    if (LookRight(grid, _position) is '-' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Right;
                    }
                }

                break;
            case Direction.Down:
                if (_cursor == '|')
                {
                    if (LookDown(grid, _position) == '-') return 0;

                    if (LookDown(grid, _position) is '|' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Down;
                        return possibleMoves;
                    }
                }

                if (_cursor == '+')
                {
                    if (LookLeft(grid, _position) is '-' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Left;
                    }

                    if (LookRight(grid, _position) is '-' or '+' or 'X')
                    {
                        possibleMoves++;
                        _direction = Direction.Right;
                    }
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return possibleMoves;
    }

    private static char LookRight(char[][] grid, (int, int) position)
    {
        try
        {
            var nextPos = (position.Item1, position.Item2 + 1);
            if (_positionsUsed.Contains(nextPos)) return 'e';
            return grid[position.Item1][position.Item2 + 1];
        }
        catch (Exception)
        {
            return 'e';
        }
    }

    private static char LookLeft(char[][] grid, (int, int) position)
    {
        try
        {
            var nextPos = (position.Item1, position.Item2 - 1);
            if (_positionsUsed.Contains(nextPos)) return 'e';
            return grid[position.Item1][position.Item2 - 1];
        }
        catch (Exception)
        {
            return 'e';
        }
    }

    private static char LookUp(char[][] grid, (int, int) position)
    {
        try
        {
            var nextPos = (position.Item1 - 1, position.Item2);
            if (_positionsUsed.Contains(nextPos)) return 'e';
            return grid[position.Item1 - 1][position.Item2];
        }
        catch (Exception)
        {
            return 'e';
        }
    }

    private static char LookDown(char[][] grid, (int, int) position)
    {
        try
        {
            var nextPos = (position.Item1 + 1, position.Item2);
            if (_positionsUsed.Contains(nextPos)) return 'e';
            return grid[position.Item1 + 1][position.Item2];
        }
        catch (Exception)
        {
            return 'e';
        }
    }

    private static ((int, int), (int, int)) FindXs(char[][] grid)
    {
        var xPositions = ((-1, -1), (-1, -1));
        for (var i = 0; i < grid.GetLength(0); i++)
        for (var j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] is '-' or '|' or '+' or 'X') _totalCharsInGrid++;

            if (grid[i][j] != 'X') continue;
            if (xPositions.Item1 != (-1, -1))
                xPositions.Item2 = (i, j);
            else
                xPositions.Item1 = (i, j);
        }

        return xPositions;
    }

    private enum Direction
    {
        Unknown,
        Left,
        Right,
        Up,
        Down
    }
}