using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PipiApp.Models
{
    public class Toilet : BaseEntity, IEquatable<Toilet>
    {
        [Key]
        public string RecordId { get; private set; }
        public int Toilets { get; private set; }
        public int Urinals { get; private set; }
        public string Status { get; set; }
        public string Address { get; private set; }
        public string? Description { get; private set; }
        public float Longitude { get; private set; }
        public float Latitude { get; set; }
        public string? Comments { get; set; }
        public bool IsDeleted { get; private set; }
        public string OpenHours { get; set; }
        public bool IsOpen { get; set; }
        public string OpenMessage { get; set; }


        public Toilet(string recordId, int toilets, int urinals, string status, string address, string description, float longitude, float latitude)
        {
            this.RecordId = recordId;
            this.Toilets = toilets;
            this.Urinals = urinals;
            this.Address = address;
            this.Status = status;
            this.Description = description;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
        public Toilet(string recordId, int toilets, int urinals, string status, string address, string description, float longitude, float latitude, string openHours)
        {
            this.RecordId = recordId;
            this.Toilets = toilets;
            this.Urinals = urinals;
            this.Address = address;
            this.Status = status;
            this.Description = description;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.OpenHours = openHours;
            this.OpenMessage = "";
            CalculateIsOpen();
        }

        public bool Equals(Toilet? other)
        {
            return this.RecordId == other?.RecordId;
        }
        public void Delete()
        {
            this.IsDeleted = true;
        }
        public void Update(int toilets, int urinals, string status, string description)
        {
            this.Toilets = toilets;
            this.Urinals = urinals;
            this.Status = status;
            this.Description = description;
        }
        public void AddComment(string commentId)
        {
            if (Comments == null)
            {
                Comments = "";
            }
            Comments += commentId + ", ";
        }
        public void RemoveComment(string commentId)
        {
            if (Comments == null)
            {
                Comments = "";
            }
            if (Comments.Contains(commentId + ", "))
            {
                Comments = Comments.Replace(commentId, "");
            }
        }
        public void CalculateIsOpen()
        {
            if (this.Status == "Gepland")
            {
                this.IsOpen = false;
                this.OpenMessage = "Gepland";
            }
            else if (this.Status != "Open")
            {
                this.IsOpen = false;
                this.OpenMessage = "Gesloten";
                return;
            }
            this.OpenHours.Replace(" en ", "-");
            string[] dagen = this.OpenHours.Split("\n");
            string[][] uren = dagen.Select(elm => elm.Split(" ")).ToArray();

            DayOfWeek dateNow = DateTime.Now.DayOfWeek;
            switch (dateNow)
            {
                case DayOfWeek.Monday:
                    if (uren[0].Length > 3)
                    {
                        this.CalculateIsOpen(uren[0][2] + "-" + uren[0][4]);
                    }
                    else this.CalculateIsOpen(uren[0][2]);
                    break;
                case DayOfWeek.Tuesday:
                    if (uren[1].Length > 3)
                    {
                        this.CalculateIsOpen(uren[1][2] + "-" + uren[1][4]);
                    }
                    else this.CalculateIsOpen(uren[1][2]);
                    break;
                case DayOfWeek.Wednesday:
                    if (uren[2].Length > 3)
                    {
                        this.CalculateIsOpen(uren[2][2] + "-" + uren[2][4]);
                    }
                    else this.CalculateIsOpen(uren[2][2]);
                    break;
                case DayOfWeek.Thursday:
                    if (uren[3].Length > 3)
                    {
                        this.CalculateIsOpen(uren[3][2] + "-" + uren[3][4]);
                    }
                    else this.CalculateIsOpen(uren[3][2]);
                    break;
                case DayOfWeek.Friday:
                    if (uren[4].Length > 3)
                    {
                        this.CalculateIsOpen(uren[4][2] + "-" + uren[4][4]);
                    }
                    else this.CalculateIsOpen(uren[4][2]);
                    break;
                case DayOfWeek.Saturday:
                    if (uren[5].Length > 3)
                    {
                        this.CalculateIsOpen(uren[5][2] + "-" + uren[5][4]);
                    }
                    else this.CalculateIsOpen(uren[5][2]);
                    break;
                case DayOfWeek.Sunday:
                    if (uren[6].Length > 3)
                    {
                        this.CalculateIsOpen(uren[6][2] + "-" + uren[6][4]);
                    }
                    else this.CalculateIsOpen(uren[6][2]);
                    break;
            }
            if (this.IsOpen) { this.OpenMessage = "OPEN"; }
            else { this.OpenMessage = "GESLOTEN"; }
        }
        private void CalculateIsOpen(string uren)
        {
            string[] urenSplit = uren.Split("-");

            int hourNow = DateTime.Now.Hour;
            int minuteNow = DateTime.Now.Minute;

            if (urenSplit.Contains("gesloten"))
            {
                this.IsOpen = false;
                return;
            }
            if (urenSplit.Length <= 2)
            {
                int openUur = Int32.Parse(urenSplit[0].Split(":")[0]);
                int sluitUur = Int32.Parse(urenSplit[1].Split(":")[0]);

                int openMinuut = Int32.Parse(urenSplit[0].Split(":")[1]);
                int sluitMinuut = Int32.Parse(urenSplit[1].Split(":")[1]);

                this.checkHourAndMinute(hourNow, minuteNow, openUur, sluitUur, openMinuut, sluitMinuut);


            }
            else
            {
                int openUur1 = Int32.Parse(urenSplit[0].Split(":")[0]);
                int sluitUur1 = Int32.Parse(urenSplit[1].Split(":")[0]);

                int openMinuut1 = Int32.Parse(urenSplit[0].Split(":")[1]);
                int sluitMinuut1 = Int32.Parse(urenSplit[1].Split(":")[1]);

                if (!this.checkHourAndMinute(hourNow, minuteNow, openUur1, sluitUur1, openMinuut1, sluitMinuut1))
                {
                    int openUur2 = Int32.Parse(urenSplit[2].Split(":")[0]);
                    int sluitUur2 = Int32.Parse(urenSplit[3].Split(":")[0]);

                    int openMinuut2 = Int32.Parse(urenSplit[2].Split(":")[1]);
                    int sluitMinuut2 = Int32.Parse(urenSplit[3].Split(":")[1]);
                    this.checkHourAndMinute(hourNow, minuteNow, openUur2, sluitUur2, openMinuut2, sluitMinuut2);
                }

            }
        }
        private bool checkHourAndMinute(int hourNow, int minuteNow, int openUur, int sluitUur, int openMinuut, int sluitMinuut)
        {
            if (hourNow > openUur && hourNow < sluitUur)
            {
                this.IsOpen = true;
            }
            else if ((hourNow == openUur || hourNow == sluitUur) && minuteNow > openMinuut && minuteNow < sluitMinuut) {
                this.IsOpen = true;
            }
            return this.IsOpen;
        }
    }
}

