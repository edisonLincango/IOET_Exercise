using PaymentCalculation.ConsoleAPP.Models;
using PaymentCalculation.ConsoleAPP.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentCalculation.ConsoleAPP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Enter the path of the file containing the employee data:");
            String filePath = System.Console.ReadLine();

            if (File.Exists(filePath))
            {
                if (Path.GetExtension(filePath).ToUpper() == ".TXT")
                {
                    LoadFile loadFile = new LoadFile(filePath);
                    
                    List<WorkedTimeDTO> workedTime = loadFile.ReadFile();

                    System.Console.Write(Environment.NewLine + "*******WORKED HOURS******" + Environment.NewLine);

                    foreach (WorkedTimeDTO workedTimeDTO in workedTime)
                    {

                        System.Console.Write("Name: " + workedTimeDTO.Name + Environment.NewLine);

                        foreach (WorkedHourDTO WorkedHourDTO in workedTimeDTO.hours)
                        {
                            System.Console.Write("Day: " + WorkedHourDTO.Day + " From :" + WorkedHourDTO.InitialHour.ToString() + " To :" + WorkedHourDTO.FinalHour.ToString() + Environment.NewLine);
                        }

                    }

                    System.Console.Write(Environment.NewLine);
                    System.Console.Write("*******PAYMENT******" + Environment.NewLine);

                    List<PaymentDTO> payments = await CallCalculatePaymentAsync(workedTime);                    

                    foreach (PaymentDTO paymentDTO in payments)
                    {
                        System.Console.Write("The amount to pay " + paymentDTO.Name + "  is: " + paymentDTO.Value.ToString() + " USD" + Environment.NewLine);
                    }

                    System.Console.Write(Environment.NewLine);

                }
                else
                {
                    System.Console.Write("Extension file is incorrect");
                }

            }
            else
            {
                System.Console.Write("Error reading the file");
            }

            System.Console.Write("Press any key to close the app...");
            System.Console.ReadKey();
        }

        private static async Task<List<PaymentDTO>> CallCalculatePaymentAsync(List<WorkedTimeDTO> listWorkedTimeDTO)
        {
                                    
            HttpClient client = new HttpClient();                     
            client.BaseAddress = new Uri("https://localhost:44373/");
            JsonContent content = JsonContent.Create(listWorkedTimeDTO);            
            HttpResponseMessage httpResponseMessage = await client.PostAsync("Employee", content);

            if (httpResponseMessage != null && httpResponseMessage.IsSuccessStatusCode)
            {
                JsonDocument jsonDocument = JsonDocument.Parse(await httpResponseMessage.Content.ReadAsStringAsync());
                Response<List<PaymentDTO>> result = JsonSerializer.Deserialize<Response<List<PaymentDTO>>>(jsonDocument, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
                return result.Object;
            }

            return null;
            
        }

    }

}
