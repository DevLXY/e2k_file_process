using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace e2k_file_process
{
    public class Read_E2K
    {
        private List<string> data = new List<string>();
        private int lines01ProgramInformation
        {
            get
            {
                return data.IndexOf(@"$ PROGRAM INFORMATION");
            }
        }
        private int lines02Controls
        {
            get
            {
                return data.IndexOf(@"$ CONTROLS");
            }
        }
        private int lines03Stories
        {
            get
            {
                return data.IndexOf(@"$ STORIES - IN SEQUENCE FROM TOP");
            }
        }
        private int lines04DiaphragmNames
        {
            get
            {
                return data.IndexOf(@"$ DIAPHRAGM NAMES");
            }
        }
        private int lines05MaterialProperties
        {
            get
            {
                return data.IndexOf(@"$ MATERIAL PROPERTIES");
            }
        }
        private int lines06FrameSections
        {
            get
            {
                return data.IndexOf(@"$ FRAME SECTIONS");
            }
        }
        private int lines07NonprismaticSections
        {
            get
            {
                return data.IndexOf(@"$ NONPRISMATIC SECTIONS");
            }
        }



        public Read_E2K(string path)
        {
            data.AddRange(File.ReadAllLines(path));



        }
    }
}
