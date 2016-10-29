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
        public int StartingPosition = 10;
        public int RacetrackLength;
        public PictureBox MyPictureBox;
        public int Location = 0;
        private readonly Random myRandom;

        public Greyhound(PictureBox pictureBox )
        {
            RacetrackLength = 604 - pictureBox.Width;
            this.myRandom = new Random();
            this.MyPictureBox = pictureBox;
            TakeStartingPosition();
            
        }

        public bool Run()
        {
            Location = ActualizeCurrentDogPosition(this.myRandom.Next(1, 5));
            if (Location >= RacetrackLength)
            {
                return true;
            }
            return false;
        }
        public void TakeStartingPosition()
        {
            var p = MyPictureBox.Location;
            p.X = StartingPosition;
            MyPictureBox.Location = p;
        }
        private int ActualizeCurrentDogPosition(int distance)
        {
            var p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
            MyPictureBox.Refresh();
            return MyPictureBox.Location.X;
        }
    }
}
