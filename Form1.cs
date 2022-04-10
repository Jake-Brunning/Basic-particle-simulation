using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace Physics_simulation
{
    public partial class Form1 : Form
    {
        List<particle> particles = new List<particle>();
        static Size particleSize = new Size(10, 10);
        public Form1()
        {
            InitializeComponent();

        }

        private void GlobalTimer_Tick(object sender, EventArgs e)
        {
            //Timer tick is 20ms, so 50 frames per second
            //updating particle locations
            System.Drawing.Graphics graphics = this.CreateGraphics();
            graphics.Clear(Color.White);
            Pen pen = new Pen(Brushes.Blue);
            Point newPosition = new Point();
            for (int i = 0; i < particles.Count; i++)
            {
                newPosition = particles[i].UpdateData();
                graphics.DrawEllipse(pen, new Rectangle(newPosition, particleSize));
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalTimer.Start();
        }

        private void DrawBoundrey() //drawing the boundrey
        {
            
        }
        class particle
        {
            private double currentSpeed = 0;
            private double acceleration = 1;
            private double angleMovingAt = 0; //in radians
            
            public Point currentPosition = new Point(20, 20);
            private double time = 0.02; //how often the timer ticks.
          
            public particle(double currentSpeed, double acceleration, Point currentPosition, double angleMovingAt)
            {
                this.currentSpeed = currentSpeed;
                this.acceleration = acceleration;
                this.currentPosition = currentPosition;

                //Just going to assume that everyone is going to input the particle angle as degree
                //as that is more well known and easier to input
                this.angleMovingAt = (Math.PI / 180) * angleMovingAt;
            }

            public Point UpdateData()
            {
                //need to add function for weird angle happenings
             

                //calculating how far the particle needs to move (Hypontonuse)
                //s = ut + 1/2at^2
                int distance = Convert.ToInt32((currentSpeed * time) + (0.5 * (acceleration * (time * time))));

                //need to calculate x and y vectors and add it to original point
                int xValue = Convert.ToInt32(Math.Cos(angleMovingAt) * distance);
                int yValue = Convert.ToInt32(Math.Sin(angleMovingAt) * distance);

                //If not moving, add on extra time to make proper movement
                if (xValue == 0 & yValue == 0)
                {
                    time += 0.02;
                }
                else
                {
                    time = 0.02;
                }
                
                //updating point particle with new values
                currentPosition.X += xValue;
                currentPosition.Y += yValue;
                
                //update particle speed
                //v = u + at
                currentSpeed += acceleration * time;
                
                //checking if particle needs to bounce
                if(currentPosition.Y > ActiveForm.Height - particleSize.Height)
                {  
                    currentPosition.Y = ActiveForm.Height - particleSize.Height;
                    angleMovingAt = 2  * Math.PI - angleMovingAt;                  
                }
                if(currentPosition.X > ActiveForm.Width - particleSize.Width )
                {
                    currentPosition.X = ActiveForm.Width - particleSize.Width;
                    if(angleMovingAt > Math.PI / 2)
                    {
                        angleMovingAt -= 90;
                    }
                    else
                    {
                        angleMovingAt += 90;
                    }
                }
                if(currentPosition.X < 0)
                {
                    currentPosition.X = 0;
                    if (angleMovingAt > Math.PI / 2)
                    {
                        angleMovingAt -= 90;
                    }
                    else
                    {
                        angleMovingAt += 90;
                    }
                }
                if(currentPosition.Y < 0)
                {
                    currentPosition.Y = 0;
                    angleMovingAt = 2 * Math.PI - angleMovingAt;                    
                }
                
                return currentPosition;
            }


             
        }
       
    
        private void AddParticle_Click(object sender, EventArgs e)
        {
            //getting all data needed to add a new particle
            GlobalTimer.Stop();
            double.TryParse(Interaction.InputBox("Enter particle's start speed", "Particle Speed", "100"), out double currentSpeed);
            double.TryParse(Interaction.InputBox("Enter particle's acceleration speed", "Particle acceleration", "20"), out double acceleration);
            int.TryParse(Interaction.InputBox("Enter particle's x position", "Particle x position", "20"), out int Xvalue);
            int.TryParse(Interaction.InputBox("Enter particle's y position", "Particle x position", "20"), out int Yvalue);
            double.TryParse(Interaction.InputBox("Enter the particle's angle it is moving at (0 degrees = moving right)", "Particle angle", "0") ,out double angleMovingAt);
            particles.Add(new particle(currentSpeed, acceleration, new Point(Xvalue, Yvalue), angleMovingAt));
            GlobalTimer.Start();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            DrawBoundrey();
        }
    }
}
