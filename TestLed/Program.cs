using System;
using WiringPi;
using System.Threading.Tasks;
namespace TestLed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LED on Wiring Pi.");
            var app = new Program();
            app.Go(args);
            Console.ReadKey();
        }

        public async void Go( string[] args )
        {
            int ret = Init.WiringPiSetupGpio();
            if (ret == -1)
            {
                Console.WriteLine("Init failed: {0}", ret);
                return;
            }

            GPIO.pinMode(27, (int)GPIO.GPIOpinmode.Output);
            for (int i = 0; i < 5; i++)
            {
                GPIO.digitalWrite(27, 1);
                await Task.Delay(500);
                GPIO.digitalWrite(27, 0);
                await Task.Delay(500);
            }

        }
    }
}
