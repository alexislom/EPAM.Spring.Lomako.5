using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Logic
{
    /// <summary>
    /// Polynomial with real coefficients
    /// </summary>
    public class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        #region Fields

        private double[] coefficients;
        private int order;

        #endregion

        #region Properties

        public int Degree => this.order;
        public double[] Coefficients => this.coefficients;

        #endregion

        #region Ctors

        public Polynomial() : this(0) { }

        public Polynomial(double a, double b) : this(new double[] { a, b }) { }

        public Polynomial(Polynomial p) : this(p.coefficients) { }

        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException();
            if (coefficients.Length == 0)
                throw new ArgumentException();

            this.coefficients = coefficients;
            this.order = coefficients.Length - 1;

            while((this.order > 0 ) && (coefficients[this.order] == 0.0))
                this.order--;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Evaluates the polynomial for the given input value
        /// </summary>
        /// <param name="x">The value of the variable</param>
        /// <returns>The value of the polynomial in current point</returns>
        public double Evaluate(double x)
        {
            double result = 0.0;
            for(int i = this.coefficients.Length - 1; i >= 0; i--)
                result = (result * x) + this.coefficients[i];
            return result;
        }

        /// <summary>
        /// Gets the specificed coefficient
        /// </summary>
        /// <param name="n">degree</param>
        /// <returns>The coefficient of (x power n)</returns>
        public double Coefficient(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n");
            if (n >= this.coefficients.Length)
                return 0.0;

            return this.coefficients[n];
        }

        /// <summary>
        /// Differentiates the polynomial
        /// </summary>
        /// <returns>The derivative of the polynomail</returns>
        public Polynomial Differentiate()
        {
            double[] coefficients = new double[this.Degree];
            for(int i = 0; i < coefficients.Length; i++)
                coefficients[i] = (i + 1) * this.Coefficient(i + 1);

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Integrates the polynomail
        /// </summary>
        /// <param name="C">The integration constant(coefficient of zero degree)</param>
        /// <returns>The integral of the polynomial</returns>
        public Polynomial Integrate(double C)
        {
            double[] coefficients = new double[this.Degree + 2];
            coefficients[0] = C;
            for (int i = 1; i < coefficients.Length; i++)
                coefficients[i] = this.Coefficient(i - 1) / ((double)i);

            return new Polynomial(coefficients);
        }

        public static Polynomial Negate(Polynomial p)
        {
            return -p;
        }

        public static Polynomial Add(Polynomial p1, Polynomial p2)
        {
            return p1 + p2;
        }

        public static Polynomial Add(Polynomial p, double value)
        {
            return p + value;
        }

        public static Polynomial Add(double value, Polynomial p)
        {
            return p + value;
        }

        public static Polynomial Subtract(Polynomial p1, Polynomial p2)
        {
            return p1 - p2;
        }

        public static Polynomial Multiply(Polynomial p1, Polynomial p2)
        {
            return p1 * p2;
        }

        public static Polynomial Multiply(Polynomial p, double x)
        {
            return p * x;
        }

        public static Polynomial Multiply(double x, Polynomial p)
        {
            return p * x;
        }

        #endregion

        #region Operators 

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            Check(p1,p2);

            double[] coefficients = new double[Math.Max(p1.Degree, p2.Degree) + 1];
            for (int i = 0; i < coefficients.Length; i++)
                coefficients[i] = p1.Coefficient(i) + p2.Coefficient(i);

            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial p)
        {
            Check(p);

            double[] coefficients = new double[p.Degree + 1];
            for (int i = 0; i < coefficients.Length; i++)
                coefficients[i] = -p.Coefficient(i);

            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            Check(p1, p2);

            return p1 + (-p2);
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            Check(p1,p2);

            double[] coefficients = new double[(p1.Degree + p2.Degree) + 1];
            for (int i = 0; i <= p1.Degree; i++)
            {
                for (int j = 0; j <= p2.Degree; j++)
                {
                    coefficients[i + j] += p1.Coefficient(i) * p2.Coefficient(j);
                }
            }
            return new Polynomial(coefficients);
        }

        public static Polynomial operator *(double value, Polynomial p)
        {
            Check(p);

            double[] coefficients = new double[p.Degree + 1];
            for (int i = 0; i < coefficients.Length; i++)
                coefficients[i] = value * p.Coefficient(i);

            return new Polynomial(coefficients);
        }

        public static Polynomial operator *(Polynomial p, double value)
        {
            Check(p);

            return value * p;
        }

        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (ReferenceEquals(p1, null)) return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (ReferenceEquals(p1, null)) return false;
            return !p1.Equals(p2);
        }

        public static implicit operator Polynomial(double value)
        {
            return new Polynomial(value);
        }

        #endregion

        #region Overrides methods

        public override string ToString()
        {
            StringBuilder text = new StringBuilder(this.Coefficient(0).ToString());
            double coefficient;
            for (int i = 1; i < this.Degree + 1; i++)
            {
                coefficient = this.Coefficient(i);
                if(coefficient < 0.0)
                    text.Append($"-{-coefficient }");
                else
                    text.Append($"+{ coefficient }");
                if(i == 1)
                    text.Append("x");
                else
                    text.Append($"x^{ i }");
            }
            return text.ToString();
        }

        public override bool Equals(object obj)
        {
            if (this.Degree != (obj as Polynomial)?.Degree)
                return false;
            return this.coefficients.SequenceEqual(((Polynomial)obj)?.coefficients);
        }

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.coefficients.SequenceEqual(other.coefficients);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.coefficients.GetHashCode();
                return hash;
            }
        }

        public Polynomial Clone()
        {
            return new Polynomial(this);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

        #region Private methods

        private static void Check(params Polynomial[] refs)
        {
            foreach(var i in refs)
            {
                if(i == null)
                    throw new ArgumentNullException(nameof(i));
            }
        }

        #endregion
    }
}

