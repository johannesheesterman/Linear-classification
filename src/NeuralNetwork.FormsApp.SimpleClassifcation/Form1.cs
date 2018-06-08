using NeuralNetwork.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork.FormsApp.SimpleClassifcation
{
    public partial class Form1 : Form
    {
        private readonly Perceptron perceptron;

        private readonly Pen blackPen = new Pen(Color.Black, 1f);
        private readonly Pen greenPen = new Pen(Color.Green, 1f);
        private readonly Pen redPen = new Pen(Color.Red, 1f);
        private readonly int circleRadius = 5;

        public Form1()
        {
            InitializeComponent();

            perceptron = new Perceptron();

            // Train the perceptron.
            var random = new Random();
            var trainingPoints = new TrainingPoint[20000];
            for (int i = 0; i < trainingPoints.Length; i++)
            {
                trainingPoints[i] = new TrainingPoint(random, ClientSize.Width, ClientSize.Height);
                perceptron.Train(new float[] {
                    trainingPoints[i].X, trainingPoints[i].Y, 1 },
                    trainingPoints[i].Label);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;

            var random = new Random();
            for (int i = 0; i < 2000; i++)
            {
                var x = random.Next(0, ClientSize.Width);
                var y = random.Next(0, ClientSize.Height);
                Color color = perceptron.FeedForward(new float[] { x, y, 1 }) > 0 ? Color.Green : Color.Red;

                graphics.FillEllipse(new SolidBrush(color), x, y, circleRadius, circleRadius);
            }

            //graphics.DrawLine(blackPen, 0, 0, ClientSize.Width, ClientSize.Height);
        }

        private class TrainingPoint
        {
            public float X;
            public float Y;
            public int Label;

            public TrainingPoint(Random random, int width, int height)
            {
                X = random.Next(0, width);
                Y = random.Next(0, height);

                if (Y < X) Label = 1;
                else Label = -1;
            }
        }
    }
}