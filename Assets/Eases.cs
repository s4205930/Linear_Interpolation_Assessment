using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Eases
{

    public static float Linear (float t)
    {
        return t;
    }

    public class Quadratic
    {
        public static float In(float t)
        {
            return t * t;
        }

        public static float Out (float t)
        {
            return t * (2f - t);
        }

        public static float InOut (float t)
        {
            if ((t *= 2f) < 1f) { return 0.5f * t * t; }
            else { return -0.5f * ((t -= 1f) * (t - 2f) - 1f); }
        }
    }

    public class Trig
    {
        public static float SinIn(float t)
        {
            return 1f - MathF.Cos(t * MathF.PI * 0.5f);
        }

        public static float SinOut(float t)
        {
            return MathF.Sin(t * MathF.PI * 0.5f);
        }

        public static float Sine(float t)
        {
            return MathF.Sin(t * MathF.PI * 2);
        }
    }

    public class Other
    {
        public static float InElastic(float t)
        {
            const float cons = (2f * MathF.PI) / 3f;

            if (t == 0f) return 0f;
            if (t == 1f) return 1f;
            else return -MathF.Pow(2, 10 * t - 10) * MathF.Sin((t * 10 - 10.75f) * cons);
        }

        public static float OutElastic(float t)
        {
            const float cons = (2f * MathF.PI) / 3;

            if (t == 0) return 0f;
            if (t == 1) return 1f;
            else return MathF.Pow(2, -10 * t) * MathF.Sin((t * 10 - 0.75f) * cons) + 1;
        }

        public static float InOutElastic(float t)
        {
            const float cons = (2 * MathF.PI) / 4.5f;

            if (t == 0f) return 0f;
            if (t == 1f) return 1f;
            if (t < 0.5f) return -(MathF.Pow(2, 20 * t - 10) * MathF.Sin((20 * t - 11.125f) * cons)) / 2;
            else return (MathF.Pow(2, -20 * t + 10) * MathF.Sin((20 * t - 11.125f) * cons)) / 2 + 1;
        }
    }

    public class Custom
    {
        
    }

}

