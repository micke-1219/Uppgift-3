using Microsoft.Azure.Devices.Client;
using SharedLibrary.Models;
using SharedLibrary.Services;
using System;

namespace IotConsoleApp
{
    class Program
    {
        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=micke-1219.azure-devices.net;DeviceId=IotConsoleApp;SharedAccessKey=0axcU1TXYGUu+c3Y8aeiV9851uPYwVO7/DD3GWeHaCs=", TransportType.Mqtt);
        static void Main(string[] args)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
            DeviceService.ReceiveMessageAsync(deviceClient).GetAwaiter();
            Console.ReadKey();
        }
    }
}
