using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Builder
{
    public class Program
    {

        public class Options
        {
            [Option('s', "sourceFolder", Required = false, HelpText = "Set the source file folder")]
            public string SourceFolder { get; set; }

            [Option('d', "desFolder", Required = false, HelpText = "Set the destination file folder, use to save source code we builded.")]
            public string DesFolder { get; set; }

        }

        public static string ClassTemplate =
            "";

        public static string ICOTemplate =
 //"@inherits LuanNiao.Blazor.Core.LNBCBase" +
 "<span role=\"img\" aria-label=\"{0}\" class=\"anticon antico-{0}\">" +
     "<svg viewBox =\"64 64 896 896\" focusable=\"false\" data-icon=\"{0}\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\">" +
         "<defs>" +
             "<style type =\"text/css\" ></style >" +
         "</defs>" +
             "{1}" +
         "</svg>" +
 "</span>";
        private static string _sourceFolderPath = "";
        private static string _desFolderPath = @"./RazorFiles";
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
                  {
                      if (string.IsNullOrWhiteSpace(o.SourceFolder))
                      {
                          throw new ArgumentNullException("Please set the source file's folder use:-s");
                      }
                      _sourceFolderPath = o.SourceFolder;
                      if (string.IsNullOrWhiteSpace(o.DesFolder))
                      {
                          _desFolderPath = @"./RazorFiles";
                      }

                  });
            BuildFile();
        }


        private static void BuildFile()
        {


            foreach (var item in Directory.EnumerateFiles(_sourceFolderPath, "*.svg", SearchOption.AllDirectories))
            {

                var fi = new FileInfo(item);
                Console.WriteLine($"found file:{fi.Name} in folder:{fi.Directory.Name}");
                var iconName = string.Join("",
                    System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(fi.Name.Replace(fi.Extension, "")).Split('-'));
                var componentName = string.Join("",
                    iconName
                    ,
                    System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(fi.Directory.Name)
                    );
                var doc = XElement.Load(item);
                var pathStr = string.Join(" ", doc.Elements().ToList());
                var razorContext = string.Format(ICOTemplate, fi.Name.Replace(fi.Extension, ""), pathStr);
                var razorFileName = $"{componentName}.razor";
                var classFileName = $"{componentName}.cs";
                Console.WriteLine($"The LuanNiao.Blazor.Component.Antd's icon file creating..{razorFileName}");
                Directory.CreateDirectory(_desFolderPath);
                var razorFile = new FileInfo($"{_desFolderPath}/{razorFileName}");
                using var razorFileStream = razorFile.OpenWrite();
                razorFileStream.Write(Encoding.UTF8.GetBytes(razorContext));
            }

        }
    }
}
