using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChlebnyWindowsFormsPWSG
{

    [Serializable]
    public class RoomItem
    {
        private static int id_counter = 0;
        public string Name { get; set; }
        public Point Center { get; set; }
        public int id { get; private set; }
        public bool IsWall { get; set; }
        [NonSerialized]
        public Image Source;


        //public Image Source
        //{
        //    get
        //    {
        //        return _source;
        //    }
        //    set
        //    {
        //        _source = value;
        //    }
        //}
        public List<Point> points
        {
            get
            {
                return _points;
            }
            private set
            {
                _points = value;
            }
        }
        private List<Point> _points;
        public int source_id { get; private set; }
        [NonSerialized]
        private GraphicsPath _wall;
        public GraphicsPath wall {
            get
            {
                return _wall;
            }
            set
            {
                _wall = value;
            }
        }
        public float Angle { get; set; }
        public RoomItem(int id_S, string name, Point center,Image s = null, bool isWall = false)
        {
            this.source_id = id_S;
            this.Name = name;
            this.Center = center;
            this.IsWall = isWall;
            this.Source = s;
            id = id_counter++;
            this.Angle = 0f;
            if (this.IsWall)
            {
                points = new List<Point>();
                points.Add(new Point(0,0));  //center); // sprawdzić
                wall = new GraphicsPath();
            }
        }

        public int IsInItem(Point p)
        {
            if (IsWall) return int.MaxValue;

            int width = Source.Width;
            int height = Source.Height;

            if (Center.X - width / 2 > p.X || Center.X + width / 2 < p.X)
                return int.MaxValue;
            if (Center.Y - height / 2 > p.Y || Center.Y + height / 2 < p.Y)
                return int.MaxValue;

            int distance = (Center.X - p.X) * (Center.X - p.X)
                         + (Center.Y - p.Y) * (Center.Y - p.Y);
            return distance;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(this.Name);
            sb.Append(Center.ToString());
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is RoomItem item &&
                   id == item.id;
        }

        public override int GetHashCode()
        {
            return id;
        }
        public void DeSerialize()
        {
            if (IsWall == false) return;
            
            this.wall = new GraphicsPath();
            if (points.Count == 1) return;
            var ie = points.Skip(1);
            Point last = points.First();
            foreach (Point p in ie)
            {
                wall.AddLine(last, p);
                last = p;
            }
            if(id_counter < id)
            {
                id_counter = id + 1;
            }
        }

        public bool IsInWall(Point p)
        {
            if (!IsWall) return false;

            Point[] one = new Point[] { RoomPlanner.Minus(p,Center) };
            using(Matrix m = new Matrix())
            {
                m.Rotate(-Angle);
                m.TransformPoints(one);
            }

            return wall.IsOutlineVisible(one[0], RoomPlanner.wallPen);

        }

        public void updateNames((string,Image)[] t)
        {
            this.Name = t[source_id].Item1;
        }
    }
}
