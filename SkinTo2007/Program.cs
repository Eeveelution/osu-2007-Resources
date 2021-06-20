using System;
using System.IO;

namespace SkinTo2007
{
    class Program
    {
        static void ErrorCheckedCopy(string filename1, string filename2)
        {
            try
            {
                Console.WriteLine("Copying <" + filename1 + "> to <" + filename2 + ">");
                File.Copy(filename1, filename2, true);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Not Found: " + filename1);
            }
        }
        static void Main(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine("Usage: <Path to osu! Skin Folder> <Skin Name> <Invisible 300s (true/false)>");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Keep in Mind not all skins Translate well into the osu!2007 Clients\n Some notable limitaions are:\n\t1. No Hitsound Changes (You cant Override hitsounds)\n\t2. Static Sliderballs, (2007 Only Supports 9 Frames of Animation, so because not every skin has that, we chose to make this static)\n\t3. Reverse Arrows Not Working,\n");

                string SkinPath = args[0];
                string SkinName = args[1];

                string[] Skin_ini = new string[]
                {
                    "[General]",
                    "Name: " + SkinName,
                    "Author: SkinTo2007",
                    "",
                    "[Colours]",
                    "Combo1 : 248,152,0",
                    "Combo2 : 252,158,205",
                    "Combo3 : 0,248,248",
                    "Combo4 : 248,0,0"

                };

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Copying Files...");

                if (!Directory.Exists(SkinName)) Directory.CreateDirectory(SkinName);

                ErrorCheckedCopy(SkinPath + "/approachcircle.png",  SkinName + "/approachcircle.png");
                ErrorCheckedCopy(SkinPath + "/followpoint.png",     SkinName + "/followpoint.png");
                ErrorCheckedCopy(SkinPath + "/hit0.png",            SkinName + "/hit0.png");
                ErrorCheckedCopy(SkinPath + "/hit50.png",           SkinName + "/hit50.png");
                ErrorCheckedCopy(SkinPath + "/hit100.png",          SkinName + "/hit100.png");
                ErrorCheckedCopy(SkinPath + "/hit100k.png",         SkinName + "/hit100k.png");
                if (args[2] == "false")
                {
                    ErrorCheckedCopy(SkinPath + "/hit300.png", SkinName + "/hit300.png");
                    ErrorCheckedCopy(SkinPath + "/hit300g.png", SkinName + "/hit300g.png");
                    ErrorCheckedCopy(SkinPath + "/hit300k.png", SkinName + "/hit300k.png");
                }else
                {
                    ErrorCheckedCopy("empty.png", SkinName + "/hit300.png");
                    ErrorCheckedCopy("empty.png", SkinName + "/hit300g.png");
                    ErrorCheckedCopy("empty.png", SkinName + "/hit300k.png");

                }
                ErrorCheckedCopy(SkinPath + "/hitcircle.png",       SkinName + "/hitcircle.png");
                ErrorCheckedCopy(SkinPath + "/hitcircleoverlay.png",SkinName + "/hitcircleoverlay.png");
                ErrorCheckedCopy(SkinPath + "/arrow-warning.png",   SkinName + "/play-warningarrow.png");
                ErrorCheckedCopy(SkinPath + "/scorebar-bg.png",     SkinName + "/scorebar-bg.png");

                if(File.Exists(SkinPath+"/scorebar-colour.png")) ErrorCheckedCopy(SkinPath + "/scorebar-colour.png", SkinName + "/scorebar-colour.png");
                else ErrorCheckedCopy(SkinPath + "/scorebar-colour-0.png", SkinName + "/scorebar-colour.png");


                if (File.Exists(SkinPath + "/play-skip.png")) ErrorCheckedCopy(SkinPath + "/play-skip.png", SkinName + "/play-skip.png");
                else ErrorCheckedCopy(SkinPath + "/play-skip-0.png", SkinName + "/play-skip.png");
                for (int i = 0; i != 10; i++)
                {
                    ErrorCheckedCopy(SkinPath + "/sliderb.png", SkinName + "/sliderb" + i.ToString()+".png");
                }
                ErrorCheckedCopy(SkinPath + "/scorebar-ki.png", SkinName + "/scorebar-ki.png.png");
                ErrorCheckedCopy(SkinPath + "/scorebar-kidanger.png", SkinName + "/scorebar-kidanger.png");
                ErrorCheckedCopy(SkinPath + "/scorebar-kidanger2.png", SkinName + "/scorebar-kidanger2.png");
                ErrorCheckedCopy("empty.png", SkinName + "/spinner-osu.png");
                ErrorCheckedCopy(SkinPath + "/spinner-background.png", SkinName + "/spinner-background.png");
                ErrorCheckedCopy(SkinPath + "/spinner-circle.png", SkinName + "/spinner-circle.png");
                ErrorCheckedCopy(SkinPath + "/spinner-metre.png", SkinName + "/spinner-metre.png");
                ErrorCheckedCopy(SkinPath + "/sliderscorepoint.png", SkinName + "/sliderscorepoint.png");

                File.WriteAllLines(SkinName + "/skin.ini", Skin_ini);

            }
        }
    }
}
