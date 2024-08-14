using FigLib;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal.Execution;

namespace TestProject
{
    public class Tests
    {
        private readonly FigureFactory _figureFactory = new FigureFactory();

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(2, 12.56)]
        public void TestCircle(double r1, double area)
        {
            var figure = _figureFactory.GetFigure(r1);
            if (figure is Circle circle)
            {
                Assert.IsTrue(IsEquals(figure.Area, area));
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestCase(3, 4, 5, 6)]
        [TestCase(3, 3, 3, 3.89)]
        public void TestTriangle(double s1, double s2, double s3, double area)
        {
            var figure = _figureFactory.GetFigure(s1, s2, s3);
            if (figure is Triangle triangle)
            {
                TriangleInfo(triangle);
                Assert.IsTrue(IsEquals(figure.Area, area));
            } else
            {
                Assert.Fail();
            }
        }

        [TestCaseSource(nameof(TriangleData))]
        public void TestTriangle(Point p1, Point p2, Point p3, double area)
        {
            var figure = _figureFactory.GetFigure(p1, p2, p3);
            if (figure is Triangle triangle)
            {
                TriangleInfo(triangle);
                Assert.IsTrue(IsEquals(figure.Area, area));
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestCaseSource(nameof(QuadrilateralData))]
        public void TestQuadrilateral(Point p1, Point p2, Point p3, Point p4, double area)
        {
            var figure = _figureFactory.GetFigure(p1, p2, p3, p4);
            if (figure is Quadrilateral q)
            {
                QuadrilateralInfo(q);
                Assert.IsTrue(IsEquals(figure.Area, area));
            }
            else
            {
                Assert.Fail();
            }
        }

        public static IEnumerable<object[]> TriangleData
        {
            get
            {
                yield return new object[] { new Point(0, 0), new Point(0, 3), new Point(3, 0), 4.5 };

                yield return new object[] { new Point(3, 0), new Point(0, 4), new Point(3, 4), 6.0 };
            }
        }

        public static IEnumerable<object[]> QuadrilateralData
        {
            get
            {
                yield return new object[] { new Point(0, 2), new Point(2, 0), new Point(2, 2), new Point(0, 0), 4.0 };

                yield return new object[] { new Point(0, 0), new Point(0, 2), new Point(3, 2), new Point(5, 0), 8.0 };
            }
        }

        private bool IsEquals(double n1, double n2, double eps = 0.01)
        {
            return Math.Abs(n1 - n2) < eps;
        }

        private void TriangleInfo(Triangle triangle)
        {
            var equilateral = triangle.CheckType<EquilateralTriangle>();
            if (equilateral != null)
            {
                TestContext.WriteLine($"\nТреугольник является равносторонним со стороной {equilateral.Side}");
            }

            var isosceles = triangle.CheckType<IsoscelesTriangle>();
            if (isosceles != null)
            {
                TestContext.WriteLine($"\nТреугольник является равнобедренным со бедром {isosceles.Side1.Length} и основанием {isosceles.Base.Length}");
            }

            var right = triangle.CheckType<RightTriangle>();
            if (right != null)
            {
                TestContext.WriteLine($"Треугольник является прямоугольным со катетами {right.Leg1.Length} и {right.Leg2.Length}, и гипотенузой {right.Hypotenuse.Length}");
            }
        }

        private void QuadrilateralInfo(Quadrilateral q)
        {
            var square = q.CheckType<Square>();
            if (square != null)
            {
                TestContext.WriteLine($"\nЧетырехугольник является квадратом со стороной {square.Side}");
            }

            var trapezoid = q.CheckType<Trapezoid>();
            if (trapezoid != null)
            {
                TestContext.WriteLine($"\nЧетырехугольник является трапецией со бедрами {trapezoid.Legs[0].Length} и {trapezoid.Legs[1].Length}, и основаниями {trapezoid.Bases[0].Length} и {trapezoid.Bases[1].Length}");
            }
        }
    }
}