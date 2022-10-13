namespace EightKyu;

public class SharkPontoon
{
    public static string Shark(
        float pontoonDistance, 
        float sharkDistance, 
        float youSpeed, 
        float sharkSpeed, 
        bool dolphin)
    {
        return sharkDistance / (dolphin ? sharkSpeed / 2 : sharkSpeed) > pontoonDistance / youSpeed
            ? "Alive!"
            : "Shark Bait!";
    }
}