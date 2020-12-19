//
//класс касса производит расчёты
//
public class Kassa
{
    public static double Сontribution { get; set; } //взнос в кассу
    public static double Cost { get; set; }
    public static double FuelToAmountOfMoney { get; set; }
    public static double GetBalance(double contribution, double cost)
    {
        double balance = contribution - cost;
        
        return balance;
    }
}
