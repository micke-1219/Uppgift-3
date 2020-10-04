using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedLibrary.Models;

namespace SharedLibrary.Services
{
    public static class DeviceService
    {
        public static Random rnd = new Random();
        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {
                var json = JsonConvert.SerializeObject(new TemperatureModel(rnd.Next(10, 30), rnd.Next(0, 100)));
                var payload = new Message(Encoding.UTF8.GetBytes(json));
                await deviceClient.SendEventAsync(payload);
                Console.WriteLine($"Message sent: {json}");
                await Task.Delay(60000);
            }
        }
        public static async Task ReceiveMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {
                var payload = await deviceClient.ReceiveAsync();
                if(payload == null)
                {
                    continue;
                }
                Console.WriteLine($"Message received: {Encoding.UTF8.GetString(payload.GetBytes())}");
                await deviceClient.CompleteAsync(payload);
            }
        }
    }
}
