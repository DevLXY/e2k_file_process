using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace e2k_file_process
{
    public class Read_E2K
    {
        private List<string> data = new List<string>();

        #region 各标题的行数属性
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
        private int lines08RebarDefinitions
        {
            get
            {
                return data.IndexOf(@"$ REBAR DEFINITIONS");
            }
        }
        private int lines09ConcreteSections
        {
            get
            {
                return data.IndexOf(@"$ CONCRETE SECTIONS");
            }
        }
        private int lines10SectionDesignerSections
        {
            get
            {
                return data.IndexOf(@"$ SECTION DESIGNER SECTIONS");
            }
        }
        private int lines11WallSlabDeckProperties
        {
            get
            {
                return data.IndexOf(@"$ WALL/SLAB/DECK PROPERTIES");
            }
        }
        private int lines12LinkProperties
        {
            get
            {
                return data.IndexOf(@"$ LINK PROPERTIES");
            }
        }
        private int lines13PierSpandrelNames
        {
            get
            {
                return data.IndexOf(@"$ PIER/SPANDREL NAMES");
            }
        }
        private int lines14PointCoordinates
        {
            get
            {
                return data.IndexOf(@"$ POINT COORDINATES");
            }
        }
        private int lines15LineConnectivities
        {
            get
            {
                return data.IndexOf(@"$ LINE CONNECTIVITIES");
            }
        }
        private int lines16AreaConnectivities
        {
            get
            {
                return data.IndexOf(@"$ AREA CONNECTIVITIES");
            }
        }
        private int lines17PointAssigns
        {
            get
            {
                return data.IndexOf(@"$ POINT ASSIGNS");
            }
        }
        private int lines18LineAssigns
        {
            get
            {
                return data.IndexOf(@"$ LINE ASSIGNS");
            }
        }
        private int lines19AreaAssigns
        {
            get
            {
                return data.IndexOf(@"$ AREA ASSIGNS");
            }
        }
        private int lines20StaticLoads
        {
            get
            {
                return data.IndexOf(@"$ STATIC LOADS");
            }
        }
        private int lines21PointObjectLoads
        {
            get
            {
                return data.IndexOf(@"$ POINT OBJECT LOADS");
            }
        }
        private int lines22LineObjectLoads
        {
            get
            {
                return data.IndexOf(@"$ LINE OBJECT LOADS");
            }
        }
        private int lines23AreaObjectLoads
        {
            get
            {
                return data.IndexOf(@"$ AREA OBJECT LOADS");
            }
        }
        private int lines24AnalysisOptions
        {
            get
            {
                return data.IndexOf(@"$ ANALYSIS OPTIONS");
            }
        }
        private int lines25Functions
        {
            get
            {
                return data.IndexOf(@"$ FUNCTIONS");
            }
        }
        private int lines26ResponceSpectrumCases
        {
            get
            {
                return data.IndexOf(@"$ RESPONSE SPECTRUM CASES");
            }
        }
        private int lines27DevelopedElevations
        {
            get
            {
                return data.IndexOf(@"$ DEVELOPED ELEVATIONS");
            }
        }
        private int lines28Log
        {
            get
            {
                return data.IndexOf(@"$ LOG");
            }
        }
        private int lines29End
        {
            get
            {
                return data.IndexOf(@"$END OF MODEL FILE");
            }
        }
        #endregion

        public Read_E2K(string path)
        {
            data.AddRange(File.ReadAllLines(path));

        }
        /// <summary>
        /// 按比例缩放层高
        /// </summary>
        /// <param name="times">缩放倍数</param>
        public void ScaleStoryHeight(decimal times)
        {
            for (int i = lines03Stories-1; i < lines04DiaphragmNames; i++)
            {
                Match m = Regex.Match(data[i], @"(?<=\bHEIGHT\s +)\d +\b");
                string s = ((decimal.Parse(m.ToString())) / times).ToString();
                data[i] = Regex.Replace(data[i], @"(?<=\bHEIGHT\s+)\d+\b", (decimal.Parse(Regex.Match(data[i], @"(?<=\bHEIGHT\s +)\d +\b").ToString())/times).ToString());
            }
        }


    }
}
