﻿using System;
using ClinicaData;
using ClinicaEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicaBussines
{
    public class DoctorBl
    {
        private static volatile DoctorBl _instance;
        private static readonly object SyncRoot = new Object();

        private DoctorBl() { }

        public static DoctorBl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new DoctorBl();
                    }
                }
                return _instance;
            }
        }

        public List<Doctor> List()
        {
            using (var context = new DataContext())
            {
                return context.Doctores
                    .ToList();
            }
        }
    }
}
