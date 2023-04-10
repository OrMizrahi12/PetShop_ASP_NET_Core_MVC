namespace PetShopClientServise.Utils.Validations;

public class NumberValidation 
{
    public static bool IsNumber(string number) => int.TryParse(number, out int val) && IsInRange(val);
    public static bool IsInRange(int number) => number > 0 && number < int.MaxValue;
}
