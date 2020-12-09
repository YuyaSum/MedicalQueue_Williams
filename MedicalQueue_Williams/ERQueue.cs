using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MedicalQueue_Williams
{
    class ERQueue
    {
        private List<Patient> patients = new List<Patient>();
        
        public int Enqueue(Patient person) 
        {
            if (listSize() >= 13)
            {
                return -1;
            }
            else {

                patients.Add(person);
                List<Patient> patients2 = patients.OrderBy(patients => patients.Priority).ToList();

                patients = patients2;


                return listSize();
            }
            
        }

        public string Dequeue() {
            string remove = "x";
            if (listSize() <= 0)
            {
                return remove;
            }
            else { 
                remove = patients[0].Name;
                patients.RemoveAt(0);
                return remove;
            }
        }

        override public string ToString() {
            string list = "";
            foreach (Patient person in patients) {
                list += "Name: " + person.Name + "\nPriorty: " + person.Priority + "\n\n"; 
            }
            return list;
        }

        //listSize checks to see if the list is 13.
        public int listSize() {
            return patients.Count;
        }
    }
}
