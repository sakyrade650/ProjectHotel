using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace Hotel
{
    class Clients : Hostel
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }
        private DateTime DateBithday { get; set; }
        private char Sex { get; set; }
        private int FloorNumber { get; set; }
        private int RoomNumber { get; set; }
        private double MoneyForRoom { get; set; }
        public DateTime dateOfArrivalAtHotel { get; set; }
        public DateTime departureDate { get; set; }
        public Clients(int FloorNumber, int RoomNumber)
        {
            this.FloorNumber = FloorNumber;
            this.RoomNumber = RoomNumber;
        }
        public Clients(string Name, string Surname, string LastName, int Age, DateTime dB, char Sex)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.LastName = LastName;
            this.Age = Age;
            this.DateBithday = dB;
            this.Sex = Sex;
        }

        //Удаление этажа и номера из массива
        public void deleteFloorAndRoom(int floor, int room)
        {
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if ((floor - 1) == i && (room - 1) == j)
                    {
                        hotel[i, j] = 0;
                        this.FloorNumber = 0;
                        this.RoomNumber = 0;
                        break;
                    }
                }
            }
        }

        //Чтение этажа и номера из файла и занесение в массив
        public void readFloorAndRoom(int floor, int room)
        {
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if ((floor - 1) == i && (room - 1) == j)
                    {
                        hotel[i, j] = 1;
                        this.FloorNumber = i + 1;
                        this.RoomNumber = j + 1;
                        break;
                    }
                }
            }
        }
        //Бронирование номера
        public bool ReservationRoom(int FloorNumber, int RoomNumber)
        {
            bool reservationComplete = false;
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if ((FloorNumber - 1) == i && (RoomNumber - 1) == j)
                    {
                        if (hotel[i, j] == 0)
                        {
                            reservationComplete = true;
                            hotel[i, j] = 1;
                            this.FloorNumber = i + 1;
                            this.RoomNumber = j + 1;
                            break;

                        }
                        else
                        {
                            reservationComplete = false;
                            WriteLine("Этот номер уже занят.");
                        }
                    }
                }
            }
            return reservationComplete;
        }
    }
}
