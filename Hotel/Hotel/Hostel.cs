using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Hotel
{
    class Hostel
    {
        private string HostelName { get; set; }
        private int stars { get; set; }
        protected const int floors = 4;
        protected const int countRoomsOnEachFloor = 25;
        public const double roomSalary = 1180;
        public const double NDS = 47.20;
        private int countRoomFree { get; set; }
        private int countOccupied { get; set; }
        protected static int[,] hotel = new int[floors, countRoomsOnEachFloor];
        public Hostel()
        {
        }
        public Hostel(string HostelName, int stars)
        {
            this.HostelName = HostelName;
            this.stars = stars;
            for (int i = 0; i < floors; i++)
                for (int j = 0; j < countRoomsOnEachFloor; j++) hotel[i, j] = 0;
        }

        //Метод, расчитывающий количество свободных мест
        private int NumberOfFreePlaces(ref int[,] hotel)
        {
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if (hotel[i, j] == 0) countRoomFree++;
                }
            }
            return countRoomFree;
        }
        //Метод, расчитывающий количество занятых мест
        private int NumberOfOccupiedRooms(ref int[,] hotel)
        {
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if (hotel[i, j] == 1) countOccupied++;
                }
            }
            return countOccupied;
        }
        //Вывод информации о отеле
        public void OutputInfoAboutHotel()
        {
            WriteLine("Наименование: " + HostelName);
            WriteLine("Количество звёзд: " + stars);
            WriteLine("Количество свободных номеров: " + NumberOfFreePlaces(ref hotel));
            WriteLine("Количество занятых номеров: " + NumberOfOccupiedRooms(ref hotel));
        }

        // Вывод всего отеля
        public void OutputInHotel()
        {
            for (int i = 0; i < floors; i++)
            {
                Write($"{i + 1} этаж: ");
                for(int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    Write($"{j + 1}: ");
                    if (hotel[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(String.Format("{0, 3}", hotel[i, j]));
                        Console.ResetColor();
                        Console.Write("; ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0, 3}", hotel[i, j]));
                        Console.ResetColor();
                        Console.Write("; ");
                    }
                }
                WriteLine();
                WriteLine();
            }
        }

        //Расчет стоимости проживания в номере
        public double RoomRate(double rSal, DateTime dateOfArrivalAtHotel, DateTime departureDate)
        {
            int date = departureDate.Day - dateOfArrivalAtHotel.Day;
            return rSal * date + NDS;
        }
    }
}
