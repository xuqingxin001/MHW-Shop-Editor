using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MHWShopEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public static readonly string[] DEFAULT_ITEMS = {"0001", "0005", "000D", "0011", "001C", "0046", "0047", "0048", "004A", "004B", "004F", "0055", "0056", "0057", "0058", "0059", "005A", "005C", "0066", "0067", "008A", "008B", "008C", "008D", "008E", "008F", "0090", "0091", "0092", "0093", "0095", "0096", "0098", "0099", "009A", "009B", "009D", "009E", "009F", "00A0", "00A1", "00A2", "00A3", "00A4", "00A5", "00A6", "00A7", "00A8", "00A9", "00AE", "00AF", "00B0", "00B1", "00B2", "00B4", "03E8" };
        public static readonly string[] CONSUMABLES = { "0001", "0002", "0003", "0004", "0005", "0006", "0007", "0008", "0009", "000A", "000B", "000C", "000D", "000E", "000F", "0010", "0011", "0012", "0013", "0014", "0015", "0016", "0017", "0018", "0019", "001A", "001B", "001C", "001D", "001E", "001F", "0020", "0021", "0022", "0023", "0024", "0025", "0026", "0027", "0028", "0029", "002A", "002B", "002C", "002D", "002E", "002F", "0030", "0031", "0032", "0033", "0034", "0035", "0036", "0037", "0038", "0039", "003A", "003B", "003C", "003D", "003E", "003F", "0040", "0041", "0042", "0043", "0044", "0045", "0046", "0047", "0048", "0049", "004A", "004B", "004C", "004D", "004F", "0050", "0051", "0052", "0053", "0054", "0055", "0056", "0057", "0058", "0059", "005A", "005B", "005C", "005D", "005E", "005F", "0060", "0061", "0062", "0063", "0064", "0065", "0066", "0067", "0068", "0069", "006A", "006B", "006C", "006D", "006E", "006F", "0070", "0071", "008A", "008B", "008C", "008D", "008E", "008F", "0090", "0091", "0092", "0093", "0094", "0095", "0096", "0097", "0098", "0099", "009A", "009B", "009C", "009D", "009E", "009F", "00A0", "00A1", "00A2", "00A3", "00A4", "00A5", "00A6", "00A7", "00A8", "00A9", "00AA", "00AB", "00AE", "00AF", "00B0", "00B1", "00B2", "00B3", "00B4", "00B5", "00B6", "00B7", "00B8", "00B9", "00BA", "00BB", "00BC", "00BD", "00BE", "00BF", "00C0", "00C1", "00C2", "00C3", "00C4", "00C5", "00C6", "00C7", "00C8", "00C9", "03AC", "03AD", "03AE", "03AF", "03B0", "03E8", "03EE", "03EF", "03F0", "05AE" };
        public static readonly string[] HRGEMS = { "02D7", "02D8", "02D9", "02DA", "02DB", "02DC", "02DD", "02DE", "02DF", "02E0", "02E1", "02E2", "02E3", "02E4", "02E5", "02E6", "02E7", "02E8", "02E9", "02EA", "02EB", "02EC", "02ED", "02EE", "02EF", "02F0", "02F1", "02F2", "02F3", "02F4", "02F5", "02F6", "02F7", "02F8", "02F9", "02FA", "02FB", "02FC", "02FD", "02FE", "02FF", "0300", "0301", "0302", "0303", "0304", "0305", "0306", "0307", "0308", "0309", "030A", "030B", "030C", "030D", "030E", "030F", "0310", "0311", "0312", "0313", "0314", "0315", "0316", "0317", "0318", "0319", "031A", "031B", "031C", "031D", "031E", "031F", "0320", "0321", "0322", "0323", "0324", "0325", "0326", "0327", "0328", "0329", "032A", "032B", "032C", "032D", "032E", "032F", "0330", "0331", "0332", "0333", "0334", "0335", "0336", "0337", "0338", "0339", "033A", "033B", "033C", "033D", "033E", "033F", "0340", "0341", "0342", "0343", "0344", "0345", "0346", "0347", "0348", "0349", "034A", "036A", "036B", "036C", "036D", "036E", "07B0", "07B1", "07B2", "08DE", "08E0" };
        public static readonly string[] PLUSGEMS = { "07B3", "07B4", "07B5", "07B6", "07B7", "07B8", "07B9", "07BA", "07BB", "07BC", "07BD", "07BE", "07BF", "07C0", "07C6", "07C7", "07C8", "07C9", "07CA", "07CB", "07CC", "07CD", "07CE", "07CF", "07D0", "07D1", "07D2", "07D6", "07D7", "07D8", "07D9", "07DA", "07DB", "07DC", "07DD", "07DE", "07E2", "07E3", "07E6", "07E7", "07E8", "07E9", "07EA", "07EB", "07EC", "07ED", "07EE", "07EF", "07F0", "07F1", "07F2", "07F3" };
        public static readonly string[] FOURGEMS = { "07C1", "07C2", "07C3", "07C4", "07C5", "07D3", "07D4", "07D5", "07DF", "07E0", "07E1", "07E4", "07E5", "07F4", "07F5", "07F6", "07F7", "07F8", "07F9", "07FA", "07FB", "07FC", "07FD", "07FE", "07FF", "0800", "0801", "0802", "0803", "0804", "0805", "0806", "0807", "0808", "0809", "080A", "080B", "080C", "080D", "080E", "080F", "0810", "0811", "0812", "0813", "0814", "0815", "0816", "0817", "0818", "0819", "081A", "081B", "081C", "081D", "081E", "081F", "0820", "0821", "0822", "0823", "0824", "0825", "0826", "0827", "0828", "0829", "082A", "082B", "082C", "082D", "082E", "082F", "0830", "0831", "0832", "0833", "0834", "0835", "0836", "0837", "0838", "0839", "083A", "083B", "083C", "083D", "083E", "083F", "0840", "0841", "0842", "0843", "0844", "0845", "0846", "0847", "0848", "0849", "084A", "084B", "084C", "084D", "084E", "084F", "0850", "0851", "0852", "0853", "0854", "0855", "0856", "0857", "0858", "0859", "085A", "085B", "085C", "085D", "085E", "085F", "0860", "0861", "0862", "0863", "0864", "0865", "0866", "0867", "0868", "0869", "086A", "086B", "086C", "086D", "086E", "086F", "0870", "0871", "0872", "0873", "0874", "0875", "0876", "0877", "0878", "0879", "087A", "087B", "087C", "087D", "087E", "087F", "0880", "0881", "0882", "0883", "0884", "0885", "0886", "0887", "0888", "0889", "088A", "088B", "088C", "088D", "088E", "088F", "0890", "0891", "0892", "0893", "0894", "0895", "0896", "0897", "0898", "0899", "089A", "089B", "089C", "089D", "089E", "089F", "08A0", "08A1", "08A2", "08A3", "08A4", "08A5", "08A6", "08A7", "08A8", "08A9", "08AA", "08AB", "08AC", "08AD", "08AE", "08AF", "08B0", "08B1", "08B2", "08B3", "08B4", "08B5", "08B6", "08B7", "08B8", "08B9", "08BA", "08BB", "08BC", "08BD", "08BE", "08BF", "08C0", "08C1", "08C2", "08C3", "08C4", "08C5", "08C6", "08C7", "08C8", "08C9", "08CA", "08CB", "08CC", "08CD", "08CE", "08CF", "08D0", "08D1", "08D2", "08D3", "08D4", "08D5", "08D6", "08D7", "08D8", "08D9", "08DA", "08DB", "08DC", "08DD" };
        public static readonly string[] LR_MATERIALS = { "00CD", "00CE", "00CF", "00D2", "00D3", "00D5", "00D8", "00E1", "00E2", "00E3", "00E4", "00E5", "00E6", "00EA", "00EB", "00EC", "00ED", "00EE", "00F3", "00F5", "00F7", "00F9", "00FB", "00FD", "00FF", "0101", "0103", "0108", "0109", "010B", "010D", "010F", "0110", "0111", "0114", "0115", "0118", "011C", "011D", "0121", "0122", "0125", "0126", "0129", "012A", "012B", "012E", "012F", "0130", "0131", "0135", "0136", "0137", "0138", "013D", "013E", "013F", "0140", "0141", "0146", "0147", "0148", "0149", "014A", "014B", "014F", "0150", "0151", "0152", "0157", "0158", "0159", "015A", "015B", "0160", "0161", "0162", "0163", "0164", "0165", "016B", "016C", "016D", "016E", "016F", "0176", "0177", "0178", "0179", "017E", "017F", "0180", "0181", "0186", "0187", "0188", "0189", "018A", "018F", "0190", "0191", "0192", "0194", "0198", "0199", "019A", "019B", "019C", "019D", "01A3", "01A4", "01A5", "01A6", "01A7", "01A8", "01AE", "01AF", "01B0", "01B1", "01B2", "01B3", "01B4", "01BE", "01BF", "01C0", "01C1", "01C2", "01C3", "01CB", "01CC", "01CD", "01CE", "01D3", "01D4", "01D5", "01D6", "01D8" };
        public static readonly string[] HR_MATERIALS = { "00D0", "00D1", "00D4", "00D6", "00D7", "00D9", "00DA", "00DB", "00E7", "00E8", "00E9", "00EF", "00F0", "00F1", "00F2", "00F4", "00F6", "00F8", "00FA", "00FC", "00FE", "0100", "0102", "0104", "0105", "0106", "0107", "010A", "010C", "010E", "0112", "0113", "0116", "0117", "0119", "011A", "011B", "011E", "011F", "0120", "0123", "0124", "0127", "0128", "012C", "012D", "0132", "0133", "0134", "0139", "013A", "013B", "013C", "0142", "0143", "0144", "0145", "014C", "014D", "014E", "0153", "0154", "0155", "0156", "015C", "015D", "015E", "015F", "0166", "0167", "0168", "0169", "016A", "0170", "0171", "0172", "0173", "0174", "0175", "017A", "017B", "017C", "017D", "0182", "0183", "0184", "0185", "018B", "018C", "018D", "018E", "0195", "0196", "0197", "019E", "019F", "01A0", "01A1", "01A2", "01A9", "01AA", "01AB", "01AC", "01AD", "01B5", "01B6", "01B7", "01B8", "01B9", "01BA", "01BB", "01BC", "01BD", "01C4", "01C5", "01C6", "01C7", "01C8", "01C9", "01CA", "01CF", "01D0", "01D1", "01D9", "01DA", "01DB", "01DC", "01DD", "01DE", "01DF", "01E0", "01E1", "01E2", "01E3", "01E4", "01E5", "01E6", "01E7", "01E8", "01E9", "01EA", "01EB", "01EC", "01ED", "01EE", "01EF", "01F0", "01F1", "01F2", "01F4", "01F5", "01F6", "01F7", "01F8", "01F9", "01FA", "01FB", "01FC", "01FD", "01FE", "01FF", "0201", "0202", "0203", "0204", "0205", "0206", "0207", "0208", "0209", "020A", "020B", "020C", "020D", "020E", "020F", "0210", "0211", "0212", "0213", "0214", "0215", "0216", "0217", "0218", "0219", "036F", "0370", "0371", "0372", "0373", "0374", "0375", "0376", "0377", "0378", "0379", "037A", "037B", "037C", "037F", "0380", "0381", "0382", "0383", "0384", "0385", "0386", "0387", "0388", "0389", "038A", "03D3", "03D4", "03D5", "03D6", "03D9", "03DA", "03DB" };
        public static readonly string[] MR_MATERIALS = { "0406", "0407", "0408", "040A", "040C", "040D", "040E", "040F", "0410", "0411", "0412", "0413", "0414", "0418", "0419", "041A", "041B", "041D", "041E", "041F", "0420", "0421", "0422", "0423", "0424", "0425", "0426", "0427", "0428", "0429", "042A", "042C", "0431", "0433", "0434", "0435", "0436", "0438", "0439", "0441", "0443", "0581", "0582", "0583", "0597", "0598", "0599", "0703", "0704", "0705", "0706", "0707", "0708", "0709", "0710", "0711", "0712", "0720", "0721", "0722", "0723", "0724", "0725", "0726", "0727", "0728", "0729", "0733", "0734", "0735", "0736", "0738", "0739", "073A", "073B", "073C", "073D" };
        public static readonly string[] MR_MONSTER_MATS = { "042D", "042F", "043B", "0445", "0446", "0447", "0448", "0449", "044A", "044B", "044C", "044D", "044E", "044F", "0450", "0451", "0452", "0453", "0454", "0455", "0456", "0457", "0458", "0459", "045A", "045B", "045C", "045D", "045E", "045F", "0460", "0461", "0462", "0463", "0464", "0465", "0466", "0467", "0468", "0469", "046A", "046B", "046C", "046D", "046E", "046F", "0470", "0471", "0472", "0473", "0474", "0475", "0476", "0477", "0478", "0479", "047A", "047B", "047C", "047D", "047E", "047F", "0480", "0481", "0482", "0483", "0484", "0485", "0486", "0487", "0488", "0489", "048A", "048B", "048C", "048D", "048E", "048F", "0490", "0491", "0492", "0493", "0494", "0495", "0496", "0497", "0498", "0499", "049A", "049B", "049C", "049D", "049E", "049F", "04A0", "04A1", "04A2", "04A4", "04A5", "04A6", "04A9", "04AA", "04AB", "04AC", "04AD", "04AE", "04AF", "04B0", "04B1", "04B2", "04B3", "04B4", "04B5", "04B6", "04B7", "04B8", "04B9", "04BA", "04BB", "04BC", "04BD", "04BE", "04BF", "04C0", "04C1", "04C2", "04C3", "04C4", "04C5", "04C6", "04C7", "04C8", "04C9", "04CA", "04CB", "04CC", "04CD", "04CE", "04CF", "04D0", "04D1", "04D2", "04D3", "04D4", "04D5", "04D6", "04D7", "04D8", "04D9", "04DA", "04DB", "04DC", "04DD", "04DE", "04DF", "04E0", "04E1", "04E2", "04E3", "04E4", "04E5", "04E6", "04E7", "04E8", "04E9", "04EA", "04EB", "04EC", "04F1", "04F2", "04F3", "04F4", "04F5", "04F6", "04F7", "04F8", "04F9", "04FA", "04FB", "04FC", "04FD", "04FF", "0500", "0501", "0502", "0503", "0504", "0505", "0521", "0522", "0523", "0524", "0525", "0526", "0527", "0528", "0529", "052B", "052C", "052D", "052E", "052F", "0539", "053A", "053B", "053C", "0543", "0544", "0545", "0546", "0547", "0548", "0549", "054A", "054B", "054C", "054D", "054E", "054F", "0550", "0551", "0552", "0553", "0554", "0555", "0556", "0557", "0558", "0559", "055A", "055B", "055C", "055D", "055E", "055F", "0560", "0561", "0562", "0563", "0564", "0566", "0567", "0568", "0569", "0573", "0574", "0576", "0577", "0578", "0579" };
        public static readonly string[] GL_MONSTER_MATS = { "04ED", "04EE", "04EF", "04F0", "050A", "050B", "050C", "050D", "050E", "050F", "0510", "0511", "0512", "0513", "0514", "0515", "0516", "0517", "0518", "0530", "0531", "0532", "0533", "0534", "0536", "053D", "053E", "053F", "0540", "0541", "0542", "06FF", "073E", "0740", "0742", "0743", "0744", "0745", "0746", "0747", "074C", "074D", "0750", "0751", "0752", "0753", "0754", "0755", "0756", "0757", "0758", "0759", "075A", "075C", "075D", "075E", "075F", "0760", "0762", "0763", "0764", "0765", "0766", "0767", "0768", "0769", "076C", "076D", "076E", "076F", "0772", "0773", "0774", "0775", "0776", "0777", "0778", "0779", "077A", "077B", "077C", "077D", "077E", "077F", "0780", "0781", "0782", "0783", "0784", "0785", "0786", "0787", "0788", "0789", "078A", "078B", "078C", "078D", "078E", "078F", "0790", "0791", "0792", "0793", "0794", "0795", "0796", "0797", "0798", "0799", "079A", "079B", "079C", "079D", "079E", "07A0", "07A1", "07A2", "07A3", "07A6", "07A7" };
        public static readonly string UNAVAILABLE = "UNAVAILABLE";
        public static readonly string HARDUMMY = "HARDUMMY";
        private static Item[] hiddenList = (Item[]) Application.Current.FindResource("itemsList");
        private static List<Item> listBoxIn = new List<Item>();
        private static List<Item> listBoxOut = new List<Item>();
        private static string inputFilterText = "";
        private static string outputFilterText = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            Title = Title + " v" + getVersion();
            if (Properties.Settings.Default.SaveDirectory == "")
            {
                Properties.Settings.Default.SaveDirectory = AppDomain.CurrentDomain.BaseDirectory;
            }
            InsertMethod.SelectedIndex = Properties.Settings.Default.InsertMethod;
            SortMethod.SelectedIndex = Properties.Settings.Default.SortMethod;
            Language.SelectedIndex = Properties.Settings.Default.Language;
            FilterMethod.SelectedIndex = Properties.Settings.Default.FilterMethod;
            InitBoxes();
        }

        private void PopulateBoxes(List<string> items)
        {
            Item[] itemlist = new Item[listBoxIn.Count];
            listBoxIn.CopyTo(itemlist, 0);
            if (listBoxOut.Count + items.Count > 255)
            {
                TooManyItemsError();
            }
            else
            {
                if (Properties.Settings.Default.InsertMethod == 0)
                {
                    items.Reverse();
                    foreach (string item in items)
                    {
                        var result = itemlist.SingleOrDefault(x => x.Key.Substring(4) == item);
                        if (result != null)
                        {
                            listBoxIn.Remove(result);
                            listBoxOut.Insert(0, result);
                        }
                    }
                }
                else
                {
                    foreach (string item in items)
                    {
                        var result = itemlist.SingleOrDefault(x => x.Key.Substring(4) == item);
                        if (result != null)
                        {
                            listBoxIn.Remove(result);
                            listBoxOut.Add(result);
                        }
                    }
                }
                Refresh();
            }
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "shopList",
                DefaultExt = ".slt",
                Filter = "Shop List file | *.slt",
                InitialDirectory = Properties.Settings.Default.SaveDirectory
            };
            if (dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;
                Properties.Settings.Default.SaveDirectory = System.IO.Path.GetDirectoryName(filename);
                Properties.Settings.Default.Save();
                byte[] input = System.IO.File.ReadAllBytes(filename);
                Console.WriteLine(input[0]);
                byte[] buffer = new byte[2];
                List<string> items = new List<string>();
                if (input[0] == 0x01)
                {
                    for (int i = 14; i < input.Length - 1; i += 14)
                    {
                        buffer[0] = input[i + 1];
                        buffer[1] = input[i];
                        items.Add(BitConverter.ToString(buffer).Replace("-", ""));  // New File Format
                    }
                } else
                {
                    for (int i = 10; i < input.Length - 1; i += 12)
                    {
                        buffer[0] = input[i + 1];
                        buffer[1] = input[i];
                        items.Add(BitConverter.ToString(buffer).Replace("-", ""));  // Legacy File Format
                    }
                }
                
                PopulateBoxes(items);
            }
        }

        private async void SaveFile(object sender, RoutedEventArgs e)
        {
            System.IO.Stream fs;
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = "shopList",
                DefaultExt = ".slt",
                Filter = "Shop List file | *.slt",
                InitialDirectory = Properties.Settings.Default.SaveDirectory
            };


            if (dlg.ShowDialog() == true)
            {
                if ((fs = dlg.OpenFile()) != null)
                {
                    Properties.Settings.Default.SaveDirectory = System.IO.Path.GetDirectoryName(dlg.FileName);
                    Properties.Settings.Default.Save();
                    byte[] legacyHeader = new byte[] { 0x18, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    byte[] legacyBuffer = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    byte[] newHeader = new byte[] { 0x01, 0x10, 0x09, 0x18, 0x19, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    byte[] newBuffer = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    List<byte> items = newHeader.ToList();
                    foreach (Item item in listBoxOut)
                    {
                        string hex = item.Key.Substring(4);
                        items.Add(Convert.ToByte(int.Parse(hex.Substring(2), System.Globalization.NumberStyles.HexNumber)));
                        items.Add(Convert.ToByte(int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber)));
                        items.AddRange(newBuffer);
                    }
                    byte[] output = items.ToArray();
                    await fs.WriteAsync(output, 0, output.Length);
                    fs.Close();
                }
            }
        }

        private void LanguageChanged(object sender, SelectionChangedEventArgs e)
        {
                ResourceDictionary dict = new ResourceDictionary();

                switch (((sender as ComboBox).SelectedItem as ComboBoxItem).Tag.ToString())
                {
                    case "ara":
                        dict.Source = new Uri("Lang/ara.xaml", UriKind.Relative);
                        break;
                    case "chS":
                        dict.Source = new Uri("Lang/chS.xaml", UriKind.Relative);
                        break;
                    case "chT":
                        dict.Source = new Uri("Lang/chT.xaml", UriKind.Relative);
                        break;
                    case "eng":
                        dict.Source = new Uri("Lang/eng.xaml", UriKind.Relative);
                        break;
                    case "fre":
                        dict.Source = new Uri("Lang/fre.xaml", UriKind.Relative);
                        break;
                    case "ger":
                        dict.Source = new Uri("Lang/ger.xaml", UriKind.Relative);
                        break;
                    case "ita":
                        dict.Source = new Uri("Lang/ita.xaml", UriKind.Relative);
                        break;
                    case "jpn":
                        dict.Source = new Uri("Lang/jpn.xaml", UriKind.Relative);
                        break;
                    case "kor":
                        dict.Source = new Uri("Lang/kor.xaml", UriKind.Relative);
                        break;
                    case "pol":
                        dict.Source = new Uri("Lang/pol.xaml", UriKind.Relative);
                        break;
                    case "ptB":
                        dict.Source = new Uri("Lang/ptB.xaml", UriKind.Relative);
                        break;
                    case "rus":
                        dict.Source = new Uri("Lang/rus.xaml", UriKind.Relative);
                        break;
                    case "spa":
                        dict.Source = new Uri("Lang/spa.xaml", UriKind.Relative);
                        break;
                    default:
                            break;
                }
                Application.Current.Resources.MergedDictionaries.Add(dict);
                hiddenList = (Item[])Application.Current.FindResource("itemsList");
                Clear();
                InitBoxes();
                Properties.Settings.Default.Language = Language.SelectedIndex;
                Properties.Settings.Default.Save();
        }

        private void DefaultItems(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(DEFAULT_ITEMS.ToList());
        }

        private void ClearItems(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            List<Item> itemlist = new List<Item>();
            foreach (Item item in listBoxOut)
            {
                listBoxIn.Add(item);
                itemlist.Add(item);
            }
            foreach (Item item in itemlist)
            {
                listBoxOut.Remove(item);
            }
            Sort();
            Refresh();
        }

        private void HRGems(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(HRGEMS.ToList());
        }

        private void PlusGems(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(PLUSGEMS.ToList());
        }

        private void FourGems(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(FOURGEMS.ToList());
        }

        private void AllConsumables(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(CONSUMABLES.ToList());
        }

        private void LRMaterials(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(LR_MATERIALS.ToList());
        }

        private void HRMaterials(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(HR_MATERIALS.ToList());
        }

        private void MRMaterials(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(MR_MATERIALS.ToList());
        }

        private void MRParts(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(MR_MONSTER_MATS.ToList());
        }

        private void GLMaterials(object sender, RoutedEventArgs e)
        {
            PopulateBoxes(GL_MONSTER_MATS.ToList());
        }

        private void InitBoxes()
        {
            listBoxIn.Clear();
            Item[] itemlist = new Item[hiddenList.Count()];
            hiddenList.CopyTo(itemlist, 0);
            foreach (Item item in itemlist)
            {
                listBoxIn.Add(item);
            }
            Sort();
        }

        private void Sort()
        {
            if (SortMethod.SelectedIndex == 0)
            {
                listBoxIn.Sort((x, y) => x.Hex.CompareTo(y.Hex));
#if DEBUG
                listBoxOut.Sort((x, y) => x.Hex.CompareTo(y.Hex));
#endif
                Refresh();
            }
            else
            {
                listBoxIn.Sort((x, y) => x.Value.CompareTo(y.Value));
#if DEBUG
                listBoxOut.Sort((x, y) => x.Value.CompareTo(y.Value));
#endif
                Refresh();
            }
        }

        private void SendOut(object sender, RoutedEventArgs e)
        {
#if DEBUG
            String arr = "";
            foreach (Item item in input.SelectedItems)
            {
                arr += "\"" + item.Key.Substring(4) + "\", ";
            }
            Console.WriteLine(arr);
#endif
            if (input.SelectedItems != null && input.SelectedItems.Count + listBoxOut.Count < 256)
            {
                Item[] selecteditems = new Item[input.SelectedItems.Count];
                input.SelectedItems.CopyTo(selecteditems, 0);
                List<Item> itemlist = new List<Item>();
                if (Properties.Settings.Default.InsertMethod == 0)
                {
                    Array.Reverse(selecteditems);
                    foreach (Item item in selecteditems)
                    {
                        listBoxOut.Insert(0, item);
                        itemlist.Add(item);
                    }
                }
                else
                {
                    foreach (Item item in selecteditems)
                    {
                        listBoxOut.Add(item);
                        itemlist.Add(item);
                    }

                }
                foreach (Item item in itemlist)
                {
                    listBoxIn.Remove(item);
                }
                Refresh();
            }
            else
            {
                TooManyItemsError();
            }
        }

        private void SendIn(object sender, RoutedEventArgs e)
        {
#if DEBUG
            String arr = "";
            foreach (Item item in output.SelectedItems)
            {
                arr += "\"" + item.Key.Substring(4) + "\", ";
            }
            Console.WriteLine(arr);
#endif
            if (output.SelectedItems != null)
            {
                List<Item> itemlist = new List<Item>();
                foreach (Item item in output.SelectedItems)
                {
                    itemlist.Add(item);
                    listBoxIn.Add(item);
                }
                foreach (Item item in itemlist)
                {
                    listBoxOut.Remove(item);
                }
                Sort();
                Refresh();
            }
        }

        private void InsertMethodChanged(object sender, SelectionChangedEventArgs e)
        {
                Properties.Settings.Default.InsertMethod = InsertMethod.SelectedIndex;
                Properties.Settings.Default.Save();
        }

        private void SortMethodChanged(object  sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.SortMethod = SortMethod.SelectedIndex;
            Properties.Settings.Default.Save();
            Sort();
        }

        private void FilterMethodChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.FilterMethod = FilterMethod.SelectedIndex;
            Properties.Settings.Default.Save();
            Refresh();
        }

        private void TooManyItemsError()
        {
            MessageBox.Show("已选择的道具过多！ 无法加载此预设.", "错误");
        }

        public ObservableCollection<Item> filteredInput
        {
            get
            {
                if (String.IsNullOrEmpty(inputFilterText))
                {
                    results.Text = listBoxIn.Count().ToString();
                    return new ObservableCollection<Item>(listBoxIn.Where(x => !x.Value.ToUpper().Contains(UNAVAILABLE))  // Do not show unavailable items
                        .Where(x => !x.Value.ToUpper().Contains(HARDUMMY)));  // Do not show HARDUMMY items
                }
                var filtered = listBoxIn.Where(x => true);
                if (FilterMethod.SelectedIndex == 0)
                {
                    filtered = listBoxIn.Where(x => x.Value.ToUpper().Contains(inputFilterText.ToUpper())); // Contains Word
                } else if (FilterMethod.SelectedIndex == 1)
                {
                    filtered = listBoxIn.Where(x => x.Value.ToUpper().StartsWith(inputFilterText.ToUpper()));  // Match Word
                } else
                {
                    filtered = listBoxIn.Where(x => !x.Value.ToUpper().Contains(inputFilterText.ToUpper()));  // Exclude Word
                }
                filtered = filtered.Where(x => !x.Value.ToUpper().Contains(UNAVAILABLE))
                    .Where(x => !x.Value.ToUpper().Contains(HARDUMMY));  // Do not match unavailable or HARDUMMY
                results.Text = filtered.Count().ToString();
                return new ObservableCollection<Item>(filtered);
            }
        }

        public string filterInputText
        {
            get { return inputFilterText; }
            set
            {
                inputFilterText = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("filteredInput"));
                    PropertyChanged(this, new PropertyChangedEventArgs("filteredOutput"));
                }
            }
        }

        public ObservableCollection<Item> filteredOutput
        {
            get
            {
                if (String.IsNullOrEmpty(outputFilterText))
                {
                    return new ObservableCollection<Item>(listBoxOut);
                }
                var filtered = listBoxOut.Where(x => true);
                if (FilterMethod.SelectedIndex == 0)
                {
                    filtered = listBoxOut.Where(x => x.Value.ToUpper().Contains(outputFilterText.ToUpper())); // Contains Word
                }
                else if (FilterMethod.SelectedIndex == 1)
                {
                    filtered = listBoxOut.Where(x => x.Value.ToUpper().StartsWith(outputFilterText.ToUpper()));  // Match Word
                }
                else
                {
                    filtered = listBoxOut.Where(x => !x.Value.ToUpper().Contains(outputFilterText.ToUpper()));
                }
                return new ObservableCollection<Item>(filtered);
            }
        }

        public string filterOutputText
        {
            get { return outputFilterText; }
            set
            {
                outputFilterText = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("filteredInput"));
                    PropertyChanged(this, new PropertyChangedEventArgs("filteredOutput"));
                }
            }
        }

        public void Refresh()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("filteredInput"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("filteredOutput"));
            itemCount.Text = listBoxOut.Count.ToString();
        }

        private void InputDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SendOut(sender, new RoutedEventArgs());
        }

        private void OutputDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SendIn(sender, new RoutedEventArgs());
        }

        public String getVersion()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
        }

    }

    public class Item
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Hex { get { return Convert.ToInt32(this.Key.Substring(4), 16); } }
        public override string ToString()
        {
            return Value;
        }
    }
}
