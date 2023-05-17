using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statistics_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Q = 0;
            double Q1 = 0, Q3 = 0;
            double median = 0f;
            double s = 0, old_counter = 0, new_counter = 0, mode = 0;
            double sum_for_div = 0f;
            Console.WriteLine(" how many numbers would you like to enter ?");
            int x = int.Parse(Console.ReadLine());
            double[] nums = new double[x];
            Console.WriteLine("Enter numbers ");
            for (int i = 0; i < x; i++)
            {
                nums[i] = double.Parse(Console.ReadLine());
            }
            Array.Sort(nums);

            //MEDIAN
            if (x % 2 == 0)
            {
                double first = nums[x / 2];
                double second = nums[(x / 2) - 1];
                double sum = first + second;
                median = sum / 2;
            }
            else
            {
                int g = x + 1;
                int median_index = (g / 2) - 1;
                median = nums[median_index];
            }

            //Q1,Q3
            Console.WriteLine("if you would like more than one quarter please enter 1 ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("please enter which quarter you would like either 1 or 3");
                    int EQ = int.Parse(Console.ReadLine());
                    Q = Quarter(x, EQ);
                    Q = Q - 1;
                    if (EQ == 1)
                    {
                        Q1 = nums[Q + 1];
                    }
                    else
                    {
                        Q3 = nums[Q];
                    }

                }
            }

            //MODE
            for (int i = 0; i < x - 1; i++)
            {
                for (int j = i + 1; j < x - 1; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        new_counter += 1;
                    }
                }
                if (new_counter > old_counter)
                {
                    old_counter = new_counter;
                    mode = nums[i];
                }
            }
            //range
            double range = nums[x - 1] - nums[0];
            //MEAN
            double sum_for_mean = 0;
            for (int i = 0; i < x; i++)
            {
                sum_for_mean = sum_for_mean + nums[i];
            }
            double mean = sum_for_mean / x;
            // standard division
            for (int i = 0; i < x; i++)
            {
                sum_for_div = sum_for_div + ((nums[i] - mean) * (nums[i] - mean));
            }
            double standard_division = sum_for_div / x;
            //p90
            float N_p90 = x * 0.9f - 1;
            double p90 = 0;
            if (N_p90 == Math.Ceiling(N_p90))
            {
                p90 = (nums[(int)N_p90] + nums[(int)N_p90]) / 2;
            }
            else
            {
                p90 = nums[(int)Math.Ceiling(N_p90)];
            }
            //summation of divisions 
            double sub_d = 0;
            double sum_d = 0;
            for (int i = 0; i < x; i++)
            {
                sub_d = nums[0] - mean;
                sum_d = sub_d + sum_d;
            }

            //outlieres 
            double IQR = Q3 - Q1;
            double H_outliere = Q3 + 1.5 * (IQR);
            double L_outliere = Q1 - 1.5 * (IQR);

            //output
            Console.WriteLine(" the mode is : {0}  , the range is : {1} , the median is : {2} , the meam is : {3} , the p90 is : {4} ", mode, range, median, mean, p90);
            Console.WriteLine(" Q1 = {0} , Q2 = {1},IQR = {2} ", Q1, Q3, IQR);
            Console.WriteLine(" Lower boundary = {0} Upper boundary = {1}", L_outliere, H_outliere);
            Console.WriteLine(" Enter number to check if outlier");
            double outlierCheck = double.Parse(Console.ReadLine());
            if (outlierCheck < L_outliere || outlierCheck > H_outliere)
            {
                Console.WriteLine(" {0} is an outlier", outlierCheck);
            }
            else
            {
                Console.WriteLine(" {0} is not an outlier", outlierCheck);
            }
            Console.ReadKey();
        }
        static int Quarter(int x, int EQ)
        {
            int s = (EQ * (x + 1)) / 4;
            if (EQ == 2)
                s = s - 1;
            return s;
        }
    }
}