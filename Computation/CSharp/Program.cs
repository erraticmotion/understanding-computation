namespace ErraticMotion
{
    using System;
    using static Builders;

    public class Program
    {
        public static void Main()
        {
            Machine.Run(Add(Multiply(1, 2), Multiply(3, 4)));
            Console.WriteLine();

            Machine.Run(LessThan(5, Add(2, 2)));
            Console.WriteLine();

            Machine.Run(Add("x".Is(3), "y".Is(4)));
            Console.WriteLine();

            Machine.Run("x".Add(1), "x".Is(2));
            Console.WriteLine();

            Machine.Run("x".If()
                    .Then("y".Assign(1))
                    .Else("y".Assign(2)),
                "x".Is(true), "y".Is(0));
            Console.WriteLine();

            Machine.Run("x".If()
                    .Then("y".Assign(1))
                    .Else("y".DoesNothing()),
                "x".Is(false), "y".Is(0));
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
