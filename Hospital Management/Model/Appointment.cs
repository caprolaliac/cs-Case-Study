using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.Model
{
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Appointment ID: {AppointmentId}\n" +
                   $"Patient ID: {PatientId}\n" +
                   $"Doctor ID: {DoctorId}\n" +
                   $"Appointment Date: {AppointmentDate}\n" +
                   $"Description: {Description}";
        }
    }
}
