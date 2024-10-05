using Hospital_Management.Model;
using Hospital_Management.Repository;
using System;
using System.Collections.Generic;
using Hospital_Managment.Util;

namespace Hospital_Management.Main
{
    internal class HospitalMgmtApp
    {
        private static HospitalRepo hospitalRepo = new HospitalRepo();


        public HospitalMgmtApp()
        {
            hospitalRepo = new HospitalRepo();
        }

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\nHospital Management System\n");
                Console.WriteLine("1. View Appointment by Appointment ID");
                Console.WriteLine("2. Get Patients Appointment By Patient Id");
                Console.WriteLine("3. Get Doctors Appointment by Doctor Id");
                Console.WriteLine("4. Schedule an Appointment");
                Console.WriteLine("5. Update an Appointment");
                Console.WriteLine("6. Cancel an Appointment");
                Console.WriteLine("7. Exit");
                Console.Write("\nEnter Your Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nView Appointment by ID");
                        Console.Write("\nEnter Your Appointment Id: ");
                        int appointmentId = int.Parse(Console.ReadLine());
                        try
                        {
                            Appointment appointment = hospitalRepo.getAppointmentById(appointmentId);

                            if (appointment != null)
                            {
                                Console.WriteLine($"\nAppointment Details: {appointment}");
                            }
                            else
                            {
                                Console.WriteLine("\nAppointment not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        break;

                    case "2":
                        Console.WriteLine("\nGet Patients Appointment By Patient Id");
                        Console.Write("\nEnter Your Patient Id: ");
                        int patientId = int.Parse(Console.ReadLine());

                        List<Appointment> appointments = hospitalRepo.getAppointmentsForPatient(patientId);

                        if (appointments.Count > 0)
                        {
                            foreach (var i in appointments)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo appointments found for the given patient.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nGet Doctors Appointment By Doctor Id");
                        hospitalRepo.DisplayAllDoctors();
                        Console.Write("\nEnter Your Doctor Id: ");
                        int doctorId = int.Parse(Console.ReadLine());

                        List<Appointment> docAppointments = hospitalRepo.getAppointmentsForDoctor(doctorId);

                        if (docAppointments.Count > 0)
                        {
                            foreach (var i in docAppointments)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo appointments found for the given doctor.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nSchedule an Appointment");

                        Appointment newAppointment = new Appointment();

                        Console.Write("\nEnter Patient ID: ");
                        newAppointment.PatientId = int.Parse(Console.ReadLine());

                        Console.Write("\nEnter Doctor ID: ");
                        newAppointment.DoctorId = int.Parse(Console.ReadLine());

                        Console.Write("\nEnter Appointment Date (e.g. 2024-12-30 14:30): ");
                        newAppointment.AppointmentDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("\nEnter Description: ");
                        newAppointment.Description = Console.ReadLine();

                        bool isScheduled = hospitalRepo.scheduleAppointment(newAppointment);

                        if (isScheduled)
                        {
                            Console.WriteLine($"\nAppointment is Scheduled Successfully on {newAppointment.AppointmentDate}");
                        }
                        else
                        {
                            Console.WriteLine("\nCould not schedule the appointment.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("\nUpdate an Appointment");

                        Appointment updatedAppointment = new Appointment();

                        Console.Write("\nEnter Appointment ID: ");
                        updatedAppointment.AppointmentId = int.Parse(Console.ReadLine());

                        Console.Write("\nEnter new Patient ID: ");
                        updatedAppointment.PatientId = int.Parse(Console.ReadLine());

                        hospitalRepo.DisplayAllDoctors();
                        Console.Write("\nEnter new Doctor ID: ");
                        updatedAppointment.DoctorId = int.Parse(Console.ReadLine());

                        Console.Write("\nEnter new Appointment Date (e.g. 2024-12-30 14:30): ");
                        updatedAppointment.AppointmentDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("\nEnter new Description: ");
                        updatedAppointment.Description = Console.ReadLine();

                        bool isUpdated = hospitalRepo.updateAppointment(updatedAppointment);

                        if (isUpdated)
                        {
                            Console.WriteLine("\nAppointment Updated Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nCould not update the appointment.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("\nCancel an Appointment");
                        Console.Write("\nEnter Appointment ID: ");
                        int cancelAppointmentId = int.Parse(Console.ReadLine());

                        bool isCancelled = hospitalRepo.cancelAppointment(cancelAppointmentId);

                        if (isCancelled)
                        {
                            Console.WriteLine("\nAppointment Cancelled Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nCould not cancel the appointment.");
                        }
                        break;

                    case "7":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
    }
}
