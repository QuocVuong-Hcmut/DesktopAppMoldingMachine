using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model
{

    public class ShiftReport
    {



        public ShiftReport ( )
        {

        }

        public ShiftReport (DateTime date,EShift shiftNumber,string employeeId,string machineId,string productId,double injectionCycle,int cavity,int totalQuantity,DateTime startTime,DateTime stopTime,double workTime,double pauseTime,string note,List<Shot> shots)
        {
            Date=date;
            ShiftNumber=shiftNumber;
            EmployeeId=employeeId;
            MachineId=machineId;
            ProductId=productId;
            InjectionCycle=injectionCycle;
            Cavity=cavity;
            TotalQuantity=totalQuantity;
            StartTime=startTime;
            StopTime=stopTime;
            WorkTime=workTime;
            PauseTime=pauseTime;
            Note=note;
            Shots=shots;
        }

        public DateTime Date { get; set; }
        public EShift ShiftNumber { get; set; }
        public string EmployeeId { get; set; }
        public string MachineId { get; set; }
        public string ProductId { get; set; }
        public double InjectionCycle { get; set; }
        public int Cavity { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public double WorkTime { get; set; }
        public double PauseTime { get; set; }
        public string Note { get; set; }
        public List<Shot> Shots { get; set; } = new List<Shot>( );
    }
    }
