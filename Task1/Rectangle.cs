using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Rectangle
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Rectangle rect = obj as Rectangle;
            if (rect != null)
            {
                if ((this.width == rect.width) && (this.height == rect.height))
                    return true;
            }
            else
                return base.Equals(obj);
            return false;
        }
        public static Rectangle operator +(Rectangle leftRect, Rectangle rRect)
        {
            if (ReferenceEquals(leftRect, null) || ReferenceEquals(rRect, null))
            {
                if (ReferenceEquals(leftRect, null) && ReferenceEquals(rRect, null))
                {
                    return new Rectangle(default(int), default(int));
                }
                else
                {
                    if (ReferenceEquals(leftRect, null))
                    {
                        return leftRect;
                    }
                    else
                        return rRect;
                }
            }
            return new Rectangle(leftRect.width + rRect.width, leftRect.height + leftRect.height);
        }
    }
}
