using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Staff
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patr { get; set; }
        public DateTime date_of_birth { get; set; }
        public int p_series { get; set; }
        public int p_number { get; set; }
        public string phone { get; set; }
        public int positionId { get; set; }
        public Staff() { }
        public Staff(string surname, string name, string patr, DateTime date_of_birth, int p_series, int p_number, string phone, int positionId)
        {
            this.surname = surname;
            this.name = name;
            this.patr = patr;
            this.date_of_birth = date_of_birth;
            this.p_series = p_series;
            this.p_number = p_number;
            this.phone = phone;
            this.positionId = positionId;
        }
    }
}
