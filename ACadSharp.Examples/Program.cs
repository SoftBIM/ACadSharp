using ACadSharp.Entities;
using ACadSharp.IO;
using ACadSharp.IO.DWG;
using ACadSharp.IO.DXF;
using System;
using System.Diagnostics;
using System.IO;
using ACadSharp.Tables;

namespace ACadSharp.Examples
{
	class Program
	{
		static string PathSamples = "../../../../samples/local";

		static void Main(string[] args)
		{
			//ReadDxf();
			ReadDwg();
		}

		static void ReadDxf()
		{
			string file = Path.Combine(PathSamples, "ascii.dxf");
			DxfReader reader = new DxfReader(file, onNotification);
			reader.Read();
		}

		static void ReadDwg()
		{
			//string file = Path.Combine(PathSamples, "dwg/cad_v2013.dwg");
			//using (DwgReader reader = new DwgReader(file, onNotification))
			//{
			//	CadDocument doc = reader.Read();
			//}

			//string[] files = Directory.GetFiles(PathSamples + "/dwg/", "*.dwg");
            string file = @"D:\API\CAD\ACadSharp\samples\sample_base\sample_base.dwg";
            using (DwgReader reader = new DwgReader(file, onNotification))
            {
                CadDocument doc = reader.Read();
                foreach (Layer docLayer in doc.Layers)
                {
                    Console.WriteLine(docLayer.ObjectName);
                }
            }
            Console.WriteLine($"file read : {file}");
            Console.ReadLine();
        }

		private static void onNotificationFail(object sender, NotificationEventArgs e)
		{
			Debug.Fail(e.Message);
		}

		private static void onNotification(object sender, NotificationEventArgs e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
