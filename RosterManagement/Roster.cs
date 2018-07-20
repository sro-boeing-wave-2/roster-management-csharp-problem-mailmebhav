using System;
using System.Linq;
using System.Collections.Generic;

namespace RosterManagement
{
    public class CodeSchool
    {
        Dictionary<int, List<string>> _roster;

        public CodeSchool()
        {
            _roster = new Dictionary<int, List<String>>();
        }
        
        /// <summary>
        /// Should be able to Add Student to a Particular Wave
        /// </summary>
        /// <param name="cadet">Refers to the name of the Cadet</param>
        /// <param name="wave">Refers to the Wave number</param>
        public void Add(string cadet, int wave)
        {
            List<string> list = new List<string>();
            if(_roster.ContainsKey(wave))
            {
                list = _roster[wave];
                list.Add(cadet);
                _roster[wave] = list;
            }
            else
            {
                list.Add(cadet);
                _roster.Add(wave, list);
            }
        }

        /// <summary>
        /// Returns all the Cadets in a given wave
        /// </summary>
        /// <param name="wave">Refers to the wave number from where cadet list is to be fetched</param>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Grade(int wave)
        {
            var list = new List<string>();
            if(_roster.Count == 0)
            {
                return list;
            }
            else
            {
                list = _roster[wave];
                list = list.OrderBy(q => q).ToList();
            }
            return list;
        }

        /// <summary>
        /// Return all the cadets in the CodeSchool
        /// </summary>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Roster()
        {
            var cadets = new List<string>();
            foreach(int wave in _roster.Keys.OrderBy(p => p).ToList())
            {
                var list = new List<string>();
                list = _roster[wave];
                list = list.OrderBy(q => q).ToList();
                cadets.AddRange(list);
            }
            return cadets;
        }
    }
}
