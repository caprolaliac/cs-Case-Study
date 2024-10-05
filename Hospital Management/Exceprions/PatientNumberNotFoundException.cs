using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.Exceprions
{
    internal class PatientNumberNotFoundException : Exception
    {
        public int PatientId { get; }
        public PatientNumberNotFoundException(int patientId) : base($"Patient with ID {patientId} was not found.")
        {
            PatientId = patientId;
        }
    }
}
