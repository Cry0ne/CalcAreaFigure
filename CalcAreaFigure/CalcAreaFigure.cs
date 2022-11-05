using static System.Math;

namespace CalcAreaFigure
{
    public enum FigureType
    {
        Circle,
        Triangle
    }

    public abstract class Figure
    {
        public abstract FigureType Type { get; }
        /// <summary>
        /// Возвращает площадь фигуры.
        /// </summary>
        public abstract double CalcArea();
    }

    public class Circle : Figure
    {
        double _radius;
        public override FigureType Type { get; } = FigureType.Circle;

        /// <summary>
        /// Возвращает или устанавливает радиус.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ValuesEqualOrLessZero("Радиус не может быть меньше или равен 0.");
                else
                    _radius = value;
            }
        }

        /// <summary>
        /// Конструктор для создания экземпляра класса <c>Circle</c>.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalcArea()
        {
            double area = PI * _radius * _radius;

            return area;
        }
    }

    public class Triangle : Figure
    {
        double _sideA, _sideB, _sideC;

        public override FigureType Type { get; } = FigureType.Triangle;

        /// <summary>
        /// Возвращает или устанавливает величину стороны A.
        /// </summary>
        public double SideA
        {
            get => _sideA;
            set
            {
                if (value <= 0)
                    throw new ValuesEqualOrLessZero("Сторона A не может быть меньше или равна 0.");
                else if (!IsExists(value, _sideB, _sideC))
                    throw new TriangleCannotExist("Треугольник не существует. Измените величину стороны A.");
                else
                    _sideA = value;
            }
        }
        /// <summary>
        /// Возвращает или устанавливает величину стороны B.
        /// </summary>
        public double SideB
        {
            get => _sideB;
            set
            {
                if (value <= 0)
                    throw new ValuesEqualOrLessZero("Сторона B не может быть меньше или равна 0.");
                else if (!IsExists(_sideA, value, _sideC))
                    throw new TriangleCannotExist("Треугольник не существует. Измените величину стороны B.");
                else
                    _sideB = value;
            }
        }
        /// <summary>
        /// Возвращает или устанавливает величину стороны C.
        /// </summary>
        public double SideC
        {
            get => _sideC;
            set
            {
                if (value <= 0)
                    throw new ValuesEqualOrLessZero("Сторона C не может быть меньше или равна 0.");
                else if (!IsExists(_sideA, _sideB, value))
                    throw new TriangleCannotExist("Треугольник не существует. Измените величину стороны C.");
                else
                    _sideC = value;
            }
        }

        /// <summary>
        /// Является ли треугольник прямоугольным.
        /// </summary>
        public bool IsRectangular => 
                _sideA * _sideA + _sideB * _sideB == _sideC * _sideC 
             || _sideC * _sideC + _sideA * _sideA == _sideB * _sideB
             || _sideB * _sideB + _sideC * _sideC == _sideA * _sideA;

        static bool IsExists(double sideA, double sideB, double sideC)
        {
            return sideA + sideB > sideC && sideC + sideA > sideB && sideB + sideC > sideA;
        }

        /// <summary>
        /// Конструктор для создания экземпляра класса <c>Triangle</c>.
        /// </summary>
        /// <param name="sideA">Сторона A</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (IsExists(sideA, sideB, sideC))
            {
                _sideA = sideA;
                _sideB = sideB;
                _sideC = sideC;
            }
            else
                throw new TriangleCannotExist("Треугольник не существует. Измените величины сторон.");
        }

        public override double CalcArea()
        {
            double p = (_sideA + _sideB + _sideC) / 2;

            double area = Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));

            return area;
        }

        public class TriangleCannotExist : Exception
        {
            public TriangleCannotExist() { }
            public TriangleCannotExist(string message) : base(message) { }
        }
    }

    public class ValuesEqualOrLessZero : Exception
    {
        public ValuesEqualOrLessZero(){}
        public ValuesEqualOrLessZero(string message) : base(message) { }
    }
}