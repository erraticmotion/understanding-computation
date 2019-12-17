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
            static void Sep()
            {
                Console.WriteLine(new string('-', 40));
            }

            Run(Add(1.Multiply(2), 3.Multiply(4)))
                .ExpressionResult()
                .Should().Be(14);
            Sep();

            Run(5.LessThan(2.Add(2)))
                .ExpressionResult()
                .Should().Be(false);

            Run(Add("x".Is(3), "y".Is(4)))
                .ExpressionResult()
                .Should().Be(7);
            Sep();

            Run("x".Assign("x".Add(1)), "x".Is(2))
                .State("x")
                .Should().Be(3);
            Sep();

            Run("x".If()
                        .Then("y".Assign(1))
                        .Else("y".Assign(2)),
                "x".Is(true), "y".Is(0))
                .State("y")
                .Should().Be(1);
            Sep();

            Run("x".If()
                        .Then("y".Assign(1))
                        .Else("y".DoesNothing()),
                    "x".Is(false), "y".Is(0))
                .State("y")
                .Should().Be("do-nothing");
            Sep();

            var sequenceResult = Run(Sequence(
                "x".Assign(1.Add(1)),
                "y".Assign("x".Add(3))),
                "x".Is(0), "y".Is(0));

            sequenceResult.State("x").Should().Be(2);
            sequenceResult.State("y").Should().Be(5);

            Run(While("x".LessThan(5), "x".Assign("x".Multiply(3))),
                    "x".Is(1))
                .State("x")
                .Should().Be(9);
            Sep();

            Console.ReadLine();
        }
    }
}
