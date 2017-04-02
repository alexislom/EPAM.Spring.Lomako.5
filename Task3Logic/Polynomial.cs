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
    public class Polynomial
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

        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException();
            if (coefficients.Length < 1)
                throw new ArgumentException();

            this.coefficients = coefficients;
            this.order = coefficients.Length - 1;

            while((this.order > 0 ) && (coefficients[this.order] == 0.0))
                this.order--;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new polynomial with the given coefficients
        /// </summary>
        /// <param name="coefficients">The coefficients of the polynomial</param>
        /// <returns>The specified polynomial</returns>
        public static Polynomial FromCoefficients(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("coefficients");
            if (coefficients.Length == 0)
                throw new InvalidOperationException();
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Evaluates the polynomial for the given input value
        /// </summary>
        /// <param name="x">The value of the variable</param>
        /// <returns>The value of the polynomial</returns>
        public double Evaluate(double x)
        {
            double t = 0.0;
            for(int i = this.coefficients.Length - 1; i >= 0; i--)
            {
                t = (t * x) + this.coefficients[i];
            }
            return t;
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
            {
                coefficients[i] = (i + 1) * this.Coefficient(i + 1);
            }
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Integrates the polynomail
        /// </summary>
        /// <param name="C">The integration constant</param>
        /// <returns>The integral of the polynomial</returns>
        public Polynomial Integrate(double C)
        {
            double[] coefficients = new double[this.Degree + 2];
            coefficients[0] = C;
            for (int i = 1; i < coefficients.Length; i++)
            {
                coefficients[i] = this.Coefficient(i - 1) / ((double)i);
            }
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Computes the quotient of two polynomials
        /// </summary>
        /// <param name="p1">The dividend polynomial</param>
        /// <param name="p2">The divisor polynomial</param>
        /// <param name="remainder">The remainder polynomial</param>
        /// <returns>The quotient polynomial</returns>
        /// <remarks>p1 = q*p2 + r</remarks>
        public static Polynomial Divide(Polynomial p1, Polynomial p2, out Polynomial remainder)
        {
            if (p1 == null)
                throw new ArgumentNullException("p1");
            if (p2 == null)
                throw new ArgumentNullException("p2");
            if (p2.Degree >= p1.Degree)
                throw new InvalidOperationException();
            
            double a = p2.Coefficient(p2.Degree);
            double[] r = new double[p1.Degree + 1];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = p1.Coefficient(i);
            }
            double[] q = new double[(p1.Degree - p2.Degree) + 1];
            for(int k = q.Length - 1; k >= 0; k--)
            {
                q[k] = r[p2.Degree + k] / a;
                r[p2.Degree + k] = 0.0;
                for(int j = (p2.Degree + k) - 1; j >= k; j--)
                {
                    r[j] -= q[k] * p2.Coefficient(j - k);
                }
            }
            remainder = new Polynomial(r);
            return new Polynomial(q);
        }

        #endregion

        #region Operators 

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
                throw new ArgumentNullException("p1");
            if (p2 == null)
                throw new ArgumentNullException("p2");
            double[] coefficients = new double[Math.Max(p1.Degree, p2.Degree) + 1];
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = p1.Coefficient(i) + p2.Coefficient(i);
            }
            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial p)
        {
            if (p == null)
                throw new ArgumentNullException("p");
            double[] coefficients = new double[p.Degree + 1];
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = -p.Coefficient(i);
            }
            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
                throw new ArgumentNullException("p1");
            if (p2 == null)
                throw new ArgumentNullException("p2");
            return p1 + (-p2);
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null)
                throw new ArgumentNullException("p1");
            if (p2 == null)
                throw new ArgumentNullException("p2");
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
            if (p == null)
                throw new ArgumentNullException("p");
            double[] coefficients = new double[p.Degree + 1];
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = value * p.Coefficient(i);
            }
            return new Polynomial(coefficients);
        }

        public static Polynomial operator *(Polynomial p, double value)
        {
            if (p == null)
                throw new ArgumentNullException("p");
            return value * p;
        }

        #endregion

        #region Override methods from object

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
            return coefficients.SequenceEqual(((Polynomial)obj)?.coefficients);
        }

        public override int GetHashCode() => this.coefficients.GetHashCode();

        #endregion

        //public bool Equals(Polynomial p)
        //{
        //    if(this == p)
        //}
    }
}

