namespace ErraticMotion
{
    using System;
    using FluentAssertions;
    using static Builders;
    using static Machine;

    public class Program
    {
        public static void Main()
        {
            Run(Add(1.Multiply(2), 3.Multiply(4)))
                .ExpressionResult()
                .Should().Be(14);

            Run(5.LessThan(2.Add(2)))
                .ExpressionResult()
                .Should().Be(false);

            Run(Add("x".Is(3), "y".Is(4)))
                .ExpressionResult()
                .Should().Be(7);

            Run("x".Add(1), "x".Is(2))
                .State("x")
                .Should().Be(3);

            Run("x".If()
                        .Then("y".Assign(1))
                        .Else("y".Assign(2)),
                "x".Is(true), "y".Is(0))
                .State("y")
                .Should().Be(1);

            Run("x".If()
                        .Then("y".Assign(1))
                        .Else("y".DoesNothing()),
                    "x".Is(false), "y".Is(0))
                .State("y")
                .Should().Be("do-nothing");


            Console.ReadLine();
        }
    }
}
