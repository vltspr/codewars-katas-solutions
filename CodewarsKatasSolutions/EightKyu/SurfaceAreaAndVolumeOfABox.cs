namespace EightKyu;

public class SurfaceAreaAndVolumeOfABox
{
    public static int[] Get_size(int width, int height, int depth)
    {
        return new[] { 2 * width * height + 2 * width * depth + 2 * height * depth, width * height * depth };
    }
}