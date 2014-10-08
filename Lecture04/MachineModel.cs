using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    public class MachineModel
    {
        public static void M1()
        {
            PointClass p = new PointClass(11, 11);
            PointClass q = new PointClass(22, 222);
            p = q;
            p.x = 33;

            PointStruct r = new PointStruct(44, 444);
            PointStruct s = new PointStruct(55, 555);
            r = s;
            r.x = 66;

            int[] iaar1 = new int[4];
            int[] iaar2 = iaar1;

            iaar1[0] = 77;

            PointStruct[] saar = new PointStruct[3];
            saar[0].x = 88;
            
            M2(2);
        }

        public static void M2(int i)
        {
            if (i > 0)
            {
                M2(i - 1);
            }
        }
    }

    public class PointClass
    {
        protected internal int x;
        protected internal int y;

        public PointClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }

        public override string ToString()
        {
            return string.Format(" + {0} + , + {1} + ", x, y);
        }
    }

    public struct PointStruct
    {
        internal int x;
        internal int y;

        public PointStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public PointStruct Move(int dx, int dy)
        {
            x += dx;
            y += dy;

            return this;
        }

        public override string ToString()
        {
            return string.Format(" + {0} + , + {1} + ", x, y);
        }
    }
}
