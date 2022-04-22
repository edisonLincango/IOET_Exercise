using PaymentCalculation.ConsoleAPP.Models;
using System.Collections.Generic;

namespace PaymentCalculation.ConsoleAPP.Utils
{
    public class LoadFile
    {
        private string FilePath { get; set; }

        public LoadFile(string filePath)
        {
            FilePath = filePath;
        }

        public List<WorkedTimeDTO> ReadFile() {
            List<WorkedTimeDTO> workedTimes = new List<WorkedTimeDTO>();

            foreach (string line in System.IO.File.ReadLines(FilePath))
            {
                if (line.Trim() != string.Empty) {
                    WorkedTimeDTO workedTimeDTO = new WorkedTimeDTO();

                    string[] mainSplit = line.Split('=');
                    workedTimeDTO.Name = mainSplit[0];

                    workedTimeDTO.hours = new List<WorkedHourDTO>();

                    string[] hoursSplit = mainSplit[1].Split(',');

                    foreach (string hour in hoursSplit) {
                        WorkedHourDTO workedHourDTO = new WorkedHourDTO();
                        workedHourDTO.Day = hour.Substring(0, 2);

                        string[] hoursDetail = hour.Substring(2, hour.Length - 2).Split('-');

                        workedHourDTO.InitialHour = int.Parse(hoursDetail[0].Substring(0, 2));
                        workedHourDTO.FinalHour = int.Parse(hoursDetail[1].Substring(0, 2));
                        workedTimeDTO.hours.Add(workedHourDTO);
                    }
                    workedTimes.Add(workedTimeDTO);
                }                               
            }
            return workedTimes;
        }

    }
}
