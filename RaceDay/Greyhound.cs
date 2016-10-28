using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; 

namespace RaceDay
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox;
        public int Location = 0;
        public int distance = 0;
        public Random MyRandom;

        public Greyhound(PictureBox pictureBox )
        {
            StartingPosition = 10;
            RacetrackLength = 604 - pictureBox.Width;
            MyRandom = new Random();
            this.MyPictureBox = pictureBox;
            TakeStartingPosition();
            
        }

        public bool Run()
        {
            Location = ActualizeCurrentDogPosition(MyRandom.Next(1, 4));
            if (Location >= RacetrackLength)
            {
                return true;
            }
            return false;
        }
        public void TakeStartingPosition()
        {
            Location = 0;
            distance = StartingPosition;
            //ActualizeCurrentDogPosition();
        }
        private int ActualizeCurrentDogPosition(int distance)
        {
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
            MyPictureBox.Refresh();
            return MyPictureBox.Location.X;
        }
    }
}
