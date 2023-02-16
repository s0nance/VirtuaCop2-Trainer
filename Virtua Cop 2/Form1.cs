﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;

namespace Virtua_Cop_2_trainer
{
    public partial class Form1 : Form
    {

        #region Global variables
        Memory oMemory = new Memory();
        bool IsGameAvailable = false;

        bool unlimitedAmmo = false;
        string ammoPtr = "004CF1AC";
        int[] AmmoOffset = {0x28};
        int AmmoToFill = 6;



        #endregion 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsGameAvailable)
            {
                if (unlimitedAmmo)
                {
                    unlimitedAmmo= false;
                    UnlimAmmoBTN.Text = "1.OFF";
                } else
                {
                    unlimitedAmmo= true;
                    UnlimAmmoBTN.Text = "1.ON";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GameAvailabilityTimer_Tick(object sender, EventArgs e)
        {
            // TODO Implement the new way of handling process opening
            if (oMemory.OpenProcessOldWay("PPJ2DD"))
            {
                //Console.WriteLine("\tBASE ADDRESS: 0x" + oMemory.Hex(oMemory.BaseAddress()) + "\n"); ACCESS DENIED
                IsGameAvailable = true;
                statusLabel.Text = "Status : Process found";
                statusLabel.ForeColor = Color.LimeGreen;
            } else
            {
                IsGameAvailable = false;
                statusLabel.Text = "Status : Process not found";
                statusLabel.ForeColor = Color.Red;
            }
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCheatTimer_Tick(object sender, EventArgs e)
        {
            if (IsGameAvailable)
            {
                #region Unlimited Ammo
                if (unlimitedAmmo)
                {
                    oMemory.OpenOldWay();
                    //int ptrAddr = HexToDec(ammoPtr);
                    int[] ptrOffset = AmmoOffset;
                    int bytesWritten;
                    byte[] valueToWrite = BitConverter.GetBytes(AmmoToFill);
                    if (oMemory.Write(oMemory.Dec(ammoPtr), ptrOffset, valueToWrite))
                    {
                        Console.WriteLine("Successfully writing");

                    } else
                    {
                        Console.WriteLine("Error writing");
                    }

                    //string writtenAddr = oMemory.PointerWrite((IntPtr)ptrAddr, valueToWrite, ptrOffset, out bytesWritten);
                   /* if (bytesWritten == valueToWrite.Length)  
                    {
                        System.Console.WriteLine("Wrote {0} to address {1}", BitConverter.ToString(valueToWrite), writtenAddr);
                    } else
                    {
                        System.Console.WriteLine("Error writing {0} to address {1}", BitConverter.ToString(valueToWrite), writtenAddr);
                        System.Console.WriteLine("BytesWritten are equal to {0} and valueToWrite length is {1}", bytesWritten, valueToWrite.Length);
                    }*/
                    /*myMemory.CloseHandle();*/
                }
                #endregion
            }
        }

        public static int HexToDec(string Hex)
        {
            return int.Parse(Hex, NumberStyles.Number);
        }

        public static string DecToHex(int Dec)
        {
            return Dec.ToString("X");
        }
    }
}