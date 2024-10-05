using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hospital_Management.Model;
using Hospital_Management.Repository.Interface;
using Hospital_Managment.Util;

namespace Hospital_Management.Repository
{
    internal class HospitalRepo : IHospital
    {
        public HospitalRepo()
        {
            //cmd = new SqlCommand();
        }

        public bool cancelAppointment(int appointmentId)
        {
            using (var connection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("delete from appointment where appointmentId = @AppointmentId", connection))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Console.WriteLine($"Appointment with Id {appointmentId} is cancelled successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Could not cancel the Appointment.");
                            return false;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public void DisplayAllDoctors()
        {
            using (var connection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("select * from doctor", connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Available Doctors:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"Doctor Id: {reader["doctorid"]}, Doctor Name: {reader["firstname"]} {reader["lastname"]}, Specialization: {reader["specialization"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Appointment getAppointmentById(int appointmentId)
        {
            using (var connection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("select * from appointment where appointmentid = @AppointmentId", connection))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Appointment
                                {
                                    AppointmentId = (int)reader["appointmentId"],
                                    PatientId = (int)reader["patientId"],
                                    DoctorId = (int)reader["doctorId"],
                                    AppointmentDate = (DateTime)reader["appointmentDate"],
                                    Description = reader["description"].ToString()
                                };
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public List<Appointment> getAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (var connection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("select * from appointment where doctorid = @DoctorId", connection))
                    {
                        cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var appointment = new Appointment
                                {
                                    AppointmentId = (int)reader["appointmentId"],
                                    PatientId = (int)reader["patientId"],
                                    DoctorId = (int)reader["doctorId"],
                                    AppointmentDate = (DateTime)reader["appointmentDate"],
                                    Description = reader["description"].ToString()
                                };
                                appointments.Add(appointment);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return appointments;
        }

        public List<Appointment> getAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (var connection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("select * from appointment where patientId = @PatientId", connection))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", patientId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var appointment = new Appointment
                                {
                                    AppointmentId = (int)reader["appointmentId"],
                                    PatientId = (int)reader["patientId"],
                                    DoctorId = (int)reader["doctorId"],
                                    AppointmentDate = (DateTime)reader["appointmentDate"],
                                    Description = reader["description"].ToString()
                                };
                                appointments.Add(appointment);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return appointments;
        }

        public bool scheduleAppointment(Appointment appointment)
        {
            using (var connection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("insert into appointment (patientId, doctorId, appointmentDate, description) values (@PatientId, @DoctorId, @AppointmentDate, @Description)", connection))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                        cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                        cmd.Parameters.AddWithValue("@Description", appointment.Description);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool updateAppointment(Appointment appointment)
        {
            using (var connection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("update appointment set patientId = @PatientId, doctorId = @DoctorId, appointmentDate = @AppointmentDate, description = @Description where appointmentId = @AppointmentId", connection))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                        cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                        cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                        cmd.Parameters.AddWithValue("@Description", appointment.Description);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
