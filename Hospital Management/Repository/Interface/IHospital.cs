using Hospital_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.Repository.Interface
{
    internal interface IHospital
    {
        Appointment getAppointmentById(int appointmentId);
        List<Appointment> getAppointmentsForPatient(int patientId);
        List<Appointment> getAppointmentsForDoctor(int doctorId);
        bool scheduleAppointment(Appointment appointment);
        bool updateAppointment(Appointment appointment);
        bool cancelAppointment(int appointmentId);

        public void DisplayAllDoctors();

    }
}
