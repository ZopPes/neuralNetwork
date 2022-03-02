using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network
{
    public struct ActivationFunction
    {
        public Func<double, double> Equation { get; set; }
        public Func<double, double> Derivative { get; set; }

        public static ActivationFunction Sigmoid
        {
            get
            {
                ActivationFunction function = new ActivationFunction();
                function.Equation = (double x) => { return 1.0 / (1.0 + Math.Exp(-x)); };
                function.Derivative = (double x) => { var sigmoid = function.Equation(x); return sigmoid / (1 - sigmoid); };
                return function;
            }
        }

        public static ActivationFunction Gaussian
        {
            get
            {
                ActivationFunction Function = new ActivationFunction();
                Function.Equation = (double x) => { return Math.Pow(Math.E, -Math.Pow(x, 2)); };
                Function.Derivative = (double x) => { return -2 * x * Function.Equation(x); };
                return Function;
            }
        }

        public static ActivationFunction FunctionHeaviside
        {
            get
            {
                ActivationFunction function = new ActivationFunction();
                function.Equation = (double x) =>
                {
                    if (x < 0) return 0;
                    return 1;
                };
                function.Derivative = (double x) =>
                {
                    if (x != 0)
                    {
                        return 0;
                    }
                    return x;
                };
                return function;
            }
        }

        public static ActivationFunction UpdateLeakyRelu
        {
            get
            {
                ActivationFunction function = new ActivationFunction();
                function.Equation = (double x) =>
                {
                    if (x > 1) return 1 + 0.01 * (x - 1);
                    if (x < 0) return x * 0.01;
                    return x;
                };
                function.Derivative = (double x) =>
                {
                    if (x > 1) return 0.01;
                    if (x < 0) return 0.01;
                    return 1;
                };
                return function;

            }
        }

        public ActivationFunction(Func<double, double> equation, Func<double, double> derivativ)
        {
            Equation = equation;
            this.Derivative = derivativ;
        }
    }
}
