using System;
using System.Threading.Tasks;
using WiringPi;

namespace TestServo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Servo on Wiring Pi.");
            var app = new Program();
            app.Go(args);
            Console.ReadKey();
        }
        public async void Go(string[] args)
        {
            int ret = Init.WiringPiSetupGpio();
            if (ret == -1)
            {
                Console.WriteLine("Init failed: {0}", ret);
                return;
            }


            SoftPwm.Create(18, 0, 100);
            for (int i = 0; i < 5; i++)
            {
                for ( int j=0; j<10; j++ )
                {
                    SoftPwm.Write(18, j*10);
                    await Task.Delay(100);
                }
                for (int j = 10; j > 0; j--)
                {
                    SoftPwm.Write(18, j * 10);
                    await Task.Delay(100);
                }
            }
            SoftPwm.Stop(18);
        }
    }
}

