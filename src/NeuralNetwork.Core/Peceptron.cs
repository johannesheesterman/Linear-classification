using System;

namespace NeuralNetwork.Core
{
    /// <summary>
    /// The perceptron algorithm:
    /// 1. For every input, multiply that input by its weight.
    /// 2. Sum all of the weighted inputs.
    /// 3. Compute the ouput of the perceptron based on that sum passed through an activation function (the sign of the sum).
    /// </summary>
    public class Perceptron
    {
        private double[] _weights = new double[3];
        private float _learningRate = 0.01f;

        public Perceptron()
        {
            // Initialize the weights randomly.
            var random = new Random();
            for (int i = 0; i < _weights.Length; i++)
                _weights[i] = random.Next(-1, 1);
        }

        public int FeedForward(float[] inputs)
        {
            if (inputs.Length != 3) throw new ArgumentException("Only 3 inputs are supported right now.");

            // 1. For every input, multiply that input by its weight.
            // 2. Sum all of the weighted inputs.
            double sum = 0;
            for (int i = 0; i < _weights.Length; i++)
            {
                sum += inputs[i] * _weights[i];
            }

            // 3. Compute the ouput of the perceptron based on that sum passed through an activation function (the sign of the sum).
            var output = Activate(sum);
            return output;
        }

        /// <summary>
        /// The activation function, step 3 in the perceptron algorithm.
        /// </summary>
        /// <returns>A 1 if positive, -1 if negative.</returns>
        private int Activate(double n)
        {
            if (n >= 0) return 1;
            return -1;
        }

        public void Train(float[] inputs, int target)
        {
            var guess = FeedForward(inputs);
            var error = target - guess;

            // Tune all the weights.
            for (int i = 0; i < _weights.Length; i++)
            {
                _weights[i] += error * inputs[i] * _learningRate;
            }
        }
    }
}