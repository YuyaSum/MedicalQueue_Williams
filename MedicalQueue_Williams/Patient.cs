using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalQueue_Williams
{
    class Patient
    {
        private string name;
        private int priority;

        public Patient(string name, int priority) {
            this.name = name;
            this.priority = priority;
        }

        public string Name {
            get { return name; } 
        }
        public int Priority {
            get { return priority; }
        }
    }
}
