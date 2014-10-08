using System;
using System.Security.Cryptography.X509Certificates;

namespace Lecture01
{
    public static class Choice
    {
        public static double Absolute(double x)
        {
            if (x >= 0)
                return x;
            else
                return -x;
        }

        public static double Absolute2(double x)
        {
            if (x >= 0)
            {
                return x;
            }
            else
            {
                return -x;
            }
        }

        public static double Absolute3(double x)
        {
            return x >= 0 ? x : -x;
        }

        public static double Absolute4(double x)
        {
            return Math.Abs(x);
        }

        public static string AgeGroup(int age)
        {
            string group;

            if (age <= 12)
            {
                group = "child";
            }
            else if (age <= 19)
            {
                group = "teenager";
            }
            else if (age <= 45)
            {
                group = "young";
            }
            else if (age <= 60)
            {
                group = "middle-age";
            }
            else
            {
                group = "old";
            }

            return group;
        }

        public static string FindCountry(int prefix)
        {
            switch (prefix)
            {
                default:
                    return "Unknown";
                case 1:
                    return "North America";
                case 44:
                    return "Great Britain";
                case 45:
                    return "Denmark";
                case 299:
                    return "Greenland";
                case 46:
                    return "Sweden";
                case 7:
                    return "Russia";
                case 972:
                    return "Israel";
            }
        }

        public static string FindCountry2(int prefix)
        {
            string country = "Unknown";

            switch (prefix)
            {
                case 1:
                    country = "North America";
                    break;
                case 44:
                    country = "Great Britain";
                    break;
                case 45:
                    country = "Denmark";
                    break;
                case 299:
                    country = "Greenland";
                    break;
                case 46:
                    country = "Sweden";
                    break;
                case 7:
                    country = "Russia";
                    break;
                case 972:
                    country = "Israel";
                    break;
            }

            return country;
        }
    }
}
