using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5_2semestr.Shab
{
    struct MyTime
    {
        public int hour, minute, second;

        public MyTime(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }

        public override string ToString()
        {
            return $"{hour:D}:{minute:D2}:{second:D2}";
        }
    }
    public partial class Shab
    {
        public void Main()
        {
            static int TimeSinceMidnight(MyTime t)
            {
                int seconds = t.hour * 3600 + t.minute * 60 + t.second;
                return seconds;
            }

            static MyTime TimeSinceMidnight(int t)
            {
                int hours = t / 3600;
                int minutes = (t % 3600) / 60;
                int seconds = t % 60;

                MyTime time = new MyTime(hours, minutes, seconds);
                return time;
            }
            static MyTime AddOneSecond(MyTime t)
            {
                t.second++;
                if (t.second >= 60)
                {
                    t.second = 0;
                    t.minute++;
                    if (t.minute >= 60)
                    {
                        t.minute = 0;
                        t.hour++;
                        if (t.hour >= 24)
                        {
                            t.hour = 0;
                        }
                    }
                }
                return t;
            }

            static MyTime AddOneMinute(MyTime t)
            {
                t.minute++;
                if (t.minute >= 60)
                {
                    t.minute = 0;
                    t.hour++;
                    if (t.hour >= 24)
                    {
                        t.hour = 0;
                    }
                }
                return t;
            }

            static MyTime AddOneHour(MyTime t)
            {
                t.hour++;
                if (t.hour >= 24)
                {
                    t.hour = 0;
                }
                return t;
            }
            static MyTime AddSeconds(MyTime t, int s)
            {
                int totalSeconds = t.hour * 3600 + t.minute * 60 + t.second;
                totalSeconds += s;

                if (totalSeconds < 0)
                {
                    totalSeconds = 86400 - Math.Abs(totalSeconds) % 86400;
                }
                else
                {
                    totalSeconds %= 86400;
                }

                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = totalSeconds % 60;

                MyTime newTime = new MyTime(hours, minutes, seconds);
                return newTime;
            }
            static int Difference(MyTime mt1, MyTime mt2)
            {
                int totalSeconds1 = mt1.hour * 3600 + mt1.minute * 60 + mt1.second;
                int totalSeconds2 = mt2.hour * 3600 + mt2.minute * 60 + mt2.second;

                int difference = totalSeconds1 - totalSeconds2;

                if (difference < -43200)
                {
                    difference += 86400;
                }
                else if (difference > 43200)
                {
                    difference -= 86400;
                }

                return difference;
            }

            static string WhatLesson(MyTime mt)
            {
                MyTime lesson1Start = new MyTime(8, 0, 0);
                MyTime lesson2Start = new MyTime(9, 40, 0);
                MyTime lesson3Start = new MyTime(11, 20, 0);
                MyTime lesson4Start = new MyTime(13, 0, 0);
                MyTime lesson5Start = new MyTime(14, 40, 0);
                MyTime lesson6Start = new MyTime(16, 10, 0);

                MyTime lesson1End = new MyTime(9, 20, 0);
                MyTime lesson2End = new MyTime(11, 0, 0);
                MyTime lesson3End = new MyTime(12, 40, 0);
                MyTime lesson4End = new MyTime(14, 20, 0);
                MyTime lesson5End = new MyTime(16, 0, 0);
                MyTime lesson6End = new MyTime(17, 30, 0);

                if (IsBefore(mt, lesson1Start))
                {
                    return "Lessons have not started yet";
                }
                else if (IsBetween(mt, lesson1Start, lesson1End))
                {
                    return "1-st lesson";
                }
                else if (IsBetween(mt, lesson1End, lesson2Start))
                {
                    return "Break between 1-st and 2-nd lessons";
                }
                else if (IsBetween(mt, lesson2Start, lesson2End))
                {
                    return "2-nd lesson";
                }
                else if (IsBetween(mt, lesson2End, lesson3Start))
                {
                    return "Break between 2-nd and 3-rd lessons";
                }
                else if (IsBetween(mt, lesson3Start, lesson3End))
                {
                    return "3-rd lesson";
                }
                else if (IsBetween(mt, lesson3End, lesson4Start))
                {
                    return "Break between 3-rd and 4-th lessons";
                }
                else if (IsBetween(mt, lesson4Start, lesson4End))
                {
                    return "4-th lesson";
                }
                else if (IsBetween(mt, lesson4End, lesson5Start))
                {
                    return "Break between 4-th and 5-th lessons";
                }
                else if (IsBetween(mt, lesson5Start, lesson5End))
                {
                    return "5-th lesson";
                }
                else if (IsBetween(mt, lesson5End, lesson6Start))
                {
                    return "Break between 5-th and 6-th lessons";
                }
                else if (IsBetween(mt, lesson6Start, lesson6End))
                {
                    return "6-th lesson";
                }
                else
                {
                    return "Lessons have ended";
                }

                static bool IsBefore(MyTime time, MyTime referenceTime)
                {
                    return time.hour < referenceTime.hour ||
                           (time.hour == referenceTime.hour && time.minute < referenceTime.minute) ||
                           (time.hour == referenceTime.hour && time.minute == referenceTime.minute && time.second < referenceTime.second);
                }

                static bool IsBetween(MyTime time, MyTime startTime, MyTime endTime)
                {
                    return (IsAfterOrEqual(time, startTime) || time.Equals(startTime)) &&
                           (IsBefore(time, endTime) || time.Equals(endTime));
                }

                static bool IsAfterOrEqual(MyTime time, MyTime referenceTime)
                {
                    return time.hour > referenceTime.hour ||
                           (time.hour == referenceTime.hour && time.minute > referenceTime.minute) ||
                           (time.hour == referenceTime.hour && time.minute == referenceTime.minute && time.second >= referenceTime.second);
                }


            }
            static void Main()
            {
            cw:
                Console.WriteLine("Enter a number of block to do(1 or 2): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1 | choice == 2)
                {
                    switch (choice)
                    {
                        case 1:
                            Block1();
                            break;
                        case 2:
                            Block2();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2");
                    goto cw;
                }
            }
            static void Block2()
            {
                string filePath = "data1.txt";
                string[] lines = File.ReadAllLines(filePath);

                int count = 0;
                Console.WriteLine("Students with all excellent marks (mark 5): ");
                foreach (string line in lines)
                {
                    string[] studentData = line.Split(' ');

                    string lastName = studentData[0];
                    string firstName = studentData[1];
                    string patronymic = studentData[2];
                    int mathGrade = int.Parse(studentData[5]);
                    int physicsGrade = int.Parse(studentData[6]);
                    int informaticsGrade = int.Parse(studentData[7]);
                    int scholarship = int.Parse(studentData[8]);

                    if (mathGrade == 5 && physicsGrade == 5 && informaticsGrade == 5)
                    {
                        Console.WriteLine($"Last name: {lastName}, first name: {firstName}, patronomic: {patronymic}, sholarship: {scholarship}");
                        count++;
                    }
                }
                Console.WriteLine($"Count of students with excellent marks: {count}");
            }
            static void Block1()
            {
                Console.WriteLine("Enter time through spaces: hours, minutes, seconds ");
                string[] stime = Console.ReadLine().Trim().Split();
                int hour = int.Parse(stime[0]);
                int min = int.Parse(stime[1]);
                int sec = int.Parse(stime[2]);
                MyTime time = new MyTime(hour, min, sec);
                Console.WriteLine("Time: " + time.ToString());

                int midnightSeconds = TimeSinceMidnight(time);
                Console.WriteLine("Time since midnight in seconds: " + midnightSeconds);

                MyTime midnightTime = TimeSinceMidnight(midnightSeconds);
                Console.WriteLine("Time since midnight: " + midnightTime.ToString());

                MyTime addSecond = AddOneSecond(time);
                Console.WriteLine("Time with added second: " + addSecond.ToString());

                addSecond = AddOneMinute(addSecond);
                Console.WriteLine("Time with added minute: " + addSecond.ToString());

                addSecond = AddOneHour(addSecond);
                Console.WriteLine("Time with added hour: " + addSecond.ToString());

                Console.WriteLine("Enter count of seconds to add to time: ");
                int secondsToAdd = int.Parse(Console.ReadLine());
                MyTime addSeconds = AddSeconds(time, secondsToAdd);
                Console.WriteLine("Result time with added seconds: " + addSeconds.ToString());

                Console.WriteLine("Enter second time through spaces to find a difference: hours, minutes, seconds ");
                string[] stime2 = Console.ReadLine().Trim().Split();
                int hour2 = int.Parse(stime2[0]);
                int min2 = int.Parse(stime2[1]);
                int sec2 = int.Parse(stime2[2]);
                MyTime time2 = new MyTime(hour2, min2, sec2);
                Console.WriteLine("Second time: " + time2.ToString());
                int diff = Difference(time, time2);
                if (diff < 0)
                {
                    diff = Math.Abs(diff);
                    Console.WriteLine("Difference between times: " + "-" + TimeSinceMidnight(diff));
                }
                else
                {
                    Console.WriteLine("Difference between times: " + TimeSinceMidnight(diff));
                }
                Console.WriteLine("What lesson is now? Now is: " + WhatLesson(time));
            }
        }
    }
}
