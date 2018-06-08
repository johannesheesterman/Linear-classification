using NeuralNetwork.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var perceptron = new Perceptron();
            Point[] points = new Point[100];
            var random = new Random();

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(random);
            }

            for (int i = 0; i < points.Length; i++)
            {
                float[] inputs = { points[i].X, points[i].Y, 1 };
                perceptron.Train(inputs, points[i].Label);
            }

            while (true)
            {
                Console.Write("Enter number to guess:");
                var input = new float[3];
                input = Console.ReadLine().Split(' ').Select(str => (float)Convert.ToDecimal(str)).Concat(new float[] { 1 }).ToArray();
                input[2] = 1;

                var guess = perceptron.FeedForward(input);

                Console.WriteLine(guess);
            }
        }
    }

    internal class Point
    {
        public float X;
        public float Y;
        public int Label;

        public Point(Random random)
        {
            X = random.Next(0, 500);
            Y = random.Next(0, 500);

            if (X > Y) Label = 1;
            else Label = -1;
        }
    }
}