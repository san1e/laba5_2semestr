namespace Laba5_2semestr.klym;

public partial class Task1
{


    struct MyFrac
    {
        public long nom, denom;

        public MyFrac(long nom1, long denom1)
        {
            // скорочення дробу
            long gcd = GCD(nom1, denom1);
            nom = nom1 / gcd;
            denom = denom1 / gcd;

            // перевiрка знака знаменника та корекцiя чисельника
            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }
        }

        public override string ToString()
        {
            return $"{nom}/{denom}";
        }

        // знаходження НСД двох чисел (алгоритм Евклiда)
        public long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                long tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }
    }
    static string ToStringWithIntegerPart(MyFrac f)
    {
        long integerPart = f.nom / f.denom;
        long numerator = f.nom % f.denom;
        long denominator = f.denom;

        if (numerator == 0)
        {
            return integerPart.ToString();
        }
        else if (integerPart == 0)
        {
            return $"{numerator}/{denominator}";
        }
        else
        {
            return $"({integerPart}+{Math.Abs(numerator)}/{denominator})";
        }
    }

    static double DoubleValue(MyFrac F)
    {
        return (double)F.nom / F.denom;

    }

    static MyFrac Plus(MyFrac f1, MyFrac f2)
    {
        long nom = f1.nom * f2.denom + f2.nom * f1.denom;
        long denom = f1.denom * f2.denom;
        return new MyFrac(nom, denom);
    }

    static MyFrac Minus(MyFrac f1, MyFrac f2)
    {
        long denom = f1.denom * f2.denom;

        long nom = f1.nom * f2.denom - f2.nom * f1.denom;

        return new MyFrac(nom, denom);
    }

    static MyFrac Multiply(MyFrac f1, MyFrac f2)
    {
        long nom = f1.nom * f2.nom;
        long denom = f1.denom * f2.denom;
        return new MyFrac(nom, denom);
    }

    static MyFrac Divide(MyFrac f1, MyFrac f2)
    {
        long nom = f1.nom * f2.denom;
        long denom = f1.nom * f2.denom;

        return new MyFrac(nom, denom);
    }

    static MyFrac CalcSum1(int n)
    {
        MyFrac res = new MyFrac(1, 2);
        for (int i = 2; i <= n; i++)
        {
            MyFrac frac = new MyFrac(1, i * (i + 1));
            res = Plus(res, frac);
        }

        return res;
    }

    static MyFrac CalcMul(int n)
    {
        MyFrac res = new MyFrac(1, 1);
        for (int i = 2; i <= n; i++)
        {
            MyFrac frac = new MyFrac(i * i - 1, i * i);
            res = Multiply(res, frac);
        }


        return res;
    }

    static long Nom()
    {
        long nom = long.Parse(Console.ReadLine());
        return nom;
    }

    static long Denom()
    {
        long denom = long.Parse(Console.ReadLine());
        return denom;
    }

    public void Main()
    {
        int choice;
        long nom;
        long denom;
        long nom1;
        long denom1;
        do
        {
            Console.WriteLine("1-Додавання");
            Console.WriteLine("2-Вiднiмання");
            Console.WriteLine("3-Множення");
            Console.WriteLine("4-Дiлення");
            Console.WriteLine("5-Вираз(1/n*(n+1)");
            Console.WriteLine("6-Вираз (1-1/n^2)");
            Console.Write("Введiть варiант: ");
            choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Write("Введiть значення чисельника першого дробу :");
                    nom = Nom();
                    Console.Write("Введiть значення знаменника першого дробу :");
                    denom = Denom();
                    Console.WriteLine();
                    Console.Write("Введiть значення чисельника другого дробу :");
                    nom1 = Nom();
                    Console.Write("Введiть значення знаменника другого дробу :");
                    denom1 = Denom();
                    Console.Clear();
                    MyFrac frac1 = new MyFrac(nom, denom);
                    MyFrac frac2 = new MyFrac(nom1, denom1);
                    Console.WriteLine("Перший дрiб: " + frac1.ToString());
                    Console.WriteLine("Другий дрiб: " + frac2.ToString());
                    Console.WriteLine();
                    MyFrac sum = Plus(frac1, frac2);
                    Console.WriteLine("Сума дробiв: " + sum.ToString());
                    if (Math.Abs(sum.nom) > Math.Abs(sum.denom))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Дрiб з цiлою частиною: {ToStringWithIntegerPart(sum)}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Дiйсне значення дробу: {DoubleValue(sum)}");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Write("Введiть значення чисельника першого дробу :");
                    nom = Nom();
                    Console.Write("Введiть значення знаменника першого дробу :");
                    denom = Denom();
                    Console.WriteLine();
                    Console.Write("Введiть значення чисельника другого дробу :");
                    nom1 = Nom();
                    Console.Write("Введiть значення знаменника другого дробу :");
                    denom1 = Denom();
                    Console.Clear();
                    frac1 = new MyFrac(nom, denom);
                    frac2 = new MyFrac(nom1, denom1);
                    Console.WriteLine("Перший дрiб: " + frac1.ToString());
                    Console.WriteLine("Другий дрiб: " + frac2.ToString());
                    Console.Clear();
                    MyFrac minus = Minus(frac1, frac2);
                    Console.WriteLine("Вiднiмання дробiв: " + minus.ToString());
                    if (Math.Abs(minus.nom) > Math.Abs(minus.denom))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Дрiб з цiлою частиною: {ToStringWithIntegerPart(minus)}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Дiйсне значення дробу: {DoubleValue(minus)}");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Write("Введiть значення чисельника першого дробу :");
                    nom = Nom();
                    Console.Write("Введiть значення знаменника першого дробу :");
                    denom = Denom();
                    Console.WriteLine();
                    Console.Write("Введiть значення чисельника другого дробу :");
                    nom1 = Nom();
                    Console.Write("Введiть значення знаменника другого дробу :");
                    denom1 = Denom();
                    Console.Clear();
                    frac1 = new MyFrac(nom, denom);
                    frac2 = new MyFrac(nom1, denom1);
                    Console.WriteLine("Перший дрiб: " + frac1.ToString());
                    Console.WriteLine("Другий дрiб: " + frac2.ToString());
                    MyFrac mul = Multiply(frac1, frac2);
                    Console.WriteLine("Множення дробiв: " + mul.ToString());
                    if (Math.Abs(mul.nom) > Math.Abs(mul.denom))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Дрiб з цiлою частиною: {ToStringWithIntegerPart(mul)}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Дiйсне значення дробу: {DoubleValue(mul)}");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Write("Введiть значення чисельника першого дробу :");
                    nom = Nom();
                    Console.Write("Введiть значення знаменника першого дробу :");
                    denom = Denom();
                    Console.WriteLine();
                    Console.Write("Введiть значення чисельника другого дробу :");
                    nom1 = Nom();
                    Console.Write("Введiть значення знаменника другого дробу :");
                    denom1 = Denom();
                    Console.Clear();
                    frac1 = new MyFrac(nom, denom);
                    frac2 = new MyFrac(nom1, denom1);
                    Console.WriteLine("Перший дрiб: " + frac1.ToString());
                    Console.WriteLine("Другий дрiб: " + frac2.ToString());
                    MyFrac div = Divide(frac1, frac2);
                    Console.WriteLine("Дiлення дробiв: " + div.ToString());
                    if (Math.Abs(div.nom) > Math.Abs(div.denom))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Дрiб з цiлою частиною: {ToStringWithIntegerPart(div)}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Дiйсне значення дробу: {DoubleValue(div)}");
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Ведiть значення n: ");
                    int n = int.Parse(Console.ReadLine());
                    MyFrac sum1 = CalcSum1(n);
                    Console.WriteLine("Результат: " + sum1.ToString());
                    if (Math.Abs(sum1.nom) > Math.Abs(sum1.denom))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Дрiб з цiлою частиною: {ToStringWithIntegerPart(sum1)}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Дiйсне значення дробу: {DoubleValue(sum1)}");
                    Console.WriteLine();
                    break;
                case 6:
                    Console.Write("Ведiть значення n: ");
                    n = int.Parse(Console.ReadLine());
                    MyFrac mul1 = CalcMul(n);
                    Console.WriteLine("Результат: " + mul1.ToString());
                    if (Math.Abs(mul1.nom) > Math.Abs(mul1.denom))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Дрiб з цiлою частиною: {ToStringWithIntegerPart(mul1)}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Дiйсне значення дробу: {DoubleValue(mul1)}");
                    Console.WriteLine();
                    break;
            }
        } while (choice != 0);

    }
}
