using System;
using SFML.Graphics;

namespace VertexArray
{
    class Program
    {
        const uint POINT_NUMBER = 400;
        public static void UpdateBuffer(ref SFML.Graphics.VertexArray buffer, ref Random rnd)
        {
            for (uint i = 0; i < POINT_NUMBER; i++)
            {
                ref Vertex vertex =  ref buffer.GetVertex(i);
                vertex.Color.R = (byte)rnd.Next(256);
                vertex.Color.G = (byte)rnd.Next(256);
                vertex.Color.B = (byte)rnd.Next(256);
                vertex.Position.X = rnd.Next(800);
                vertex.Position.Y = rnd.Next(600);
            }
        }
        static void Main(string[] args)
        {
            var rnd = new Random();
            var buffer = new SFML.Graphics.VertexArray(PrimitiveType.LineStrip, POINT_NUMBER);
            var mode = new SFML.Window.VideoMode(800, 600);
            var window = new SFML.Graphics.RenderWindow(mode, "VertexArray example");

            window.Closed += (sender, e) => window.Close();

            window.SetFramerateLimit(60);
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Cyan);
                UpdateBuffer(ref buffer, ref rnd);
                window.Draw(buffer);
                window.Display();
            }
        }
    }
}
