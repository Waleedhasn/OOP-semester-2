﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    public class Student : Person
    {
        private string program;
        private int year;
        private double fee;

        public Student(string name, string address, string program, int year, double fee)
            : base(name, address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }

        public string GetProgram() => program;
        public void SetProgram(string program) => this.program = program;
        public int GetYear() => year;
        public void SetYear(int year) => this.year = year;
        public double GetFee() => fee;
        public void SetFee(double fee) => this.fee = fee;

        public override string ToString() =>
            $"Student[name={name}, address={address}, program={program}, year={year}, fee={fee}]";
    }
}
